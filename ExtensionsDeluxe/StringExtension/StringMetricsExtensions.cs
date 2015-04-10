using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringExtension;

namespace StringExtension
{
    public static class StringMetricsExtensions
    {
        /// <summary>
        /// This will compute the Damerau-Levenshteing Distaince.
        /// http://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance
        /// between two strings, i.e., finite sequence of symbols, given by counting the minimum number
        /// of operations needed to transform one string into the other, where an operation is defined as an 
        /// insertion, deletion, or substitution of a single character, or a transposition 
        /// of two adjacent characters.
        /// In otherwords, this is one measure score the "likeness" of two strings allowing for single character typo graphical errors.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int DamerauLevenshteinDistance(this string source, string target)
        {
            if (String.IsNullOrEmpty(source))
            {
                return String.IsNullOrEmpty(target) ? 0 : target.Length;
            }
            else if (String.IsNullOrEmpty(target))
            {
                return source.Length;
            }

            var score = new int[source.Length + 2, target.Length + 2];

            var inf = source.Length + target.Length;
            score[0, 0] = inf;
            for (var i = 0; i <= source.Length; i++) { score[i + 1, 1] = i; score[i + 1, 0] = inf; }
            for (var j = 0; j <= target.Length; j++) { score[1, j + 1] = j; score[0, j + 1] = inf; }

            var sd = new SortedDictionary<char, int>();
            foreach (var letter in (source + target).Where(letter => !sd.ContainsKey(letter)))
            {
                sd.Add(letter, 0);
            }

            for (var i = 1; i <= source.Length; i++)
            {
                var db = 0;
                for (var j = 1; j <= target.Length; j++)
                {
                    var i1 = sd[target[j - 1]];
                    var j1 = db;

                    if (source[i - 1] == target[j - 1])
                    {
                        score[i + 1, j + 1] = score[i, j];
                        db = j;
                    }
                    else
                    {
                        score[i + 1, j + 1] = Math.Min(score[i, j], Math.Min(score[i + 1, j], score[i, j + 1])) + 1;
                    }

                    score[i + 1, j + 1] = Math.Min(score[i + 1, j + 1], score[i1, j1] + (i - i1 - 1) + 1 + (j - j1 - 1));
                }

                sd[source[i - 1]] = i;
            }

            return score[source.Length + 1, target.Length + 1];

        }

        /// <summary>
        /// The Levenshtein distance between two strings is defined as the minimum number of edits needed to transform one string into the other, with the allowable edit operations being insertion, deletion, or substitution of a single character.
        /// http://www.dotnetperls.com/levenshtein
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>Returns the number of character edits (removals, inserts, replacements) that must occur to get from this string to string target.</returns>
        public static int LevenshteinDistance(this string source, string target)
        {
            if (String.IsNullOrEmpty(source))
            {
                return String.IsNullOrEmpty(target) ? 0 : target.Length;
            }
            else if (String.IsNullOrEmpty(target))
            {
                return source.Length;
            }

            var n = source.Length;
            var m = target.Length;
            var d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (var i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (var j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (var i = 1; i <= n; i++)
            {
                //Step 4
                for (var j = 1; j <= m; j++)
                {
                    // Step 5
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        /// <summary>
        /// Returns the SoundEx Metric for the current string.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SoundEx(this string data)
        {
            // Zach Smith -- http://www.techrepublic.com/blog/programming-and-development/how-do-i-implement-the-soundex-function-in-c/656

            var result = new StringBuilder();

            if (!string.IsNullOrEmpty(data))
            {
                string previousCode = "", currentCode = "", currentLetter = "";
                result.Append(data.Substring(0, 1));

                for (int i = 1; i < data.Length; i++)
                {
                    currentLetter = data.Substring(i, 1).ToLower();
                    currentCode = "";

                    if ("bfpv".IndexOf(currentLetter, System.StringComparison.Ordinal) > -1)
                        currentCode = "1";
                    else if ("cgjkqsxz".IndexOf(currentLetter, System.StringComparison.Ordinal) > -1)
                        currentCode = "2";
                    else if ("dt".IndexOf(currentLetter, System.StringComparison.Ordinal) > -1)
                        currentCode = "3";
                    else if (currentLetter == "l")
                        currentCode = "4";
                    else if ("mn".IndexOf(currentLetter, System.StringComparison.Ordinal) > -1)
                        currentCode = "5";
                    else if (currentLetter == "r")
                        currentCode = "6";
                    if (currentCode != previousCode)
                        result.Append(currentCode);
                    if (result.Length == 4)
                        break;
                    if (currentCode != "")
                        previousCode = currentCode;
                }
            }
            if (result.Length < 4)
                result.Append(new String('0', 4 - result.Length));
            return result.ToString().ToUpper();
        }

        /// <summary>
        /// Returns the difference of two SoundEx phonetic scores.
        /// 4 is the closest match.  Smaller numbers are less of a match.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int SoundExDifference(this string s1, string s2)
        {
            // Zach Smith -- http://www.techrepublic.com/blog/programming-and-development/how-do-i-implement-the-soundex-function-in-c/656
            var result = 0;

            var soundex1 = s1.SoundEx();
            var soundex2 = s2.SoundEx();
            if (soundex1 == soundex2)
                result = 4;
            else
            {
                var sub1 = soundex1.Substring(1, 3);
                var sub2 = soundex1.Substring(2, 2);
                var sub3 = soundex1.Substring(1, 2);
                var sub4 = soundex1.Substring(1, 1);
                var sub5 = soundex1.Substring(2, 1);
                var sub6 = soundex1.Substring(3, 1);

                if (soundex2.IndexOf(sub1, System.StringComparison.Ordinal) > -1)
                    result = 3;
                else if (soundex2.IndexOf(sub2, System.StringComparison.Ordinal) > -1)
                    result = 2;
                else if (soundex2.IndexOf(sub3, System.StringComparison.Ordinal) > -1)
                    result = 2;
                else
                {
                    if (soundex2.IndexOf(sub4, System.StringComparison.Ordinal) > -1)
                        result++;
                    if (soundex2.IndexOf(sub5, System.StringComparison.Ordinal) > -1)
                        result++;
                    if (soundex2.IndexOf(sub6, System.StringComparison.Ordinal) > -1)
                        result++;
                }
                if (soundex1.Substring(0, 1) == soundex2.Substring(0, 1))
                    result++;
            }
            return (result == 0) ? 1 : result;
        }

        /// <summary>
        /// Calculate the Jaro-Winkler Similarity metric for two strings.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static double JaroWinkler(this string source, string target)
        {
            double result = 0;
            var jw = new JaroWinkler();
            result = jw.GetDistance(source, target);
            jw = null;
            return result;

        }

        /// <summary>
        /// This will return the number of times as substring occurs within a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static int SubstringFrequency(this string myString, string subString)
        {
            if (myString == null)
                return 0;
            if (String.IsNullOrEmpty(subString))
                return 0;
            if (subString.Length > myString.Length)
                return 0;
            var count = 0;
            var indexOf = -1;
            var copy = new String(myString.ToCharArray());
            indexOf = copy.IndexOf(subString, System.StringComparison.Ordinal);
            while (indexOf >= 0)
            {
                count++;
                if (indexOf + 2 * subString.Length < copy.Length)
                    copy = copy.Substring(indexOf + subString.Length, copy.Length - 1 - subString.Length);
                indexOf = copy.IndexOf(subString, System.StringComparison.Ordinal);
            }
            return count;
        }
    }
}
