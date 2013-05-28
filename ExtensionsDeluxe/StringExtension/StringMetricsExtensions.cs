using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
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
                if (String.IsNullOrEmpty(target))
                {
                    return 0;
                }
                else
                {
                    return target.Length;
                }
            }
            else if (String.IsNullOrEmpty(target))
            {
                return source.Length;
            }

            var score = new int[source.Length + 2, target.Length + 2];

            var INF = source.Length + target.Length;
            score[0, 0] = INF;
            for (var i = 0; i <= source.Length; i++) { score[i + 1, 1] = i; score[i + 1, 0] = INF; }
            for (var j = 0; j <= target.Length; j++) { score[1, j + 1] = j; score[0, j + 1] = INF; }

            var sd = new SortedDictionary<char, int>();
            foreach (var letter in (source + target))
            {
                if (!sd.ContainsKey(letter))
                    sd.Add(letter, 0);
            }

            for (var i = 1; i <= source.Length; i++)
            {
                var DB = 0;
                for (var j = 1; j <= target.Length; j++)
                {
                    var i1 = sd[target[j - 1]];
                    var j1 = DB;

                    if (source[i - 1] == target[j - 1])
                    {
                        score[i + 1, j + 1] = score[i, j];
                        DB = j;
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
                if (String.IsNullOrEmpty(target))
                {
                    return 0;
                }
                else
                {
                    return target.Length;
                }
            }
            else if (String.IsNullOrEmpty(target))
            {
                return source.Length;
            }

            int n = source.Length;
            int m = target.Length;
            int[,] d = new int[n + 1, m + 1];

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
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

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

            StringBuilder result = new StringBuilder();

            if (data != null && data.Length > 0)
            {
                string previousCode = "", currentCode = "", currentLetter = "";
                result.Append(data.Substring(0, 1));

                for (int i = 1; i < data.Length; i++)
                {
                    currentLetter = data.Substring(i, 1).ToLower();
                    currentCode = "";

                    if ("bfpv".IndexOf(currentLetter) > -1)
                        currentCode = "1";
                    else if ("cgjkqsxz".IndexOf(currentLetter) > -1)
                        currentCode = "2";
                    else if ("dt".IndexOf(currentLetter) > -1)
                        currentCode = "3";
                    else if (currentLetter == "l")
                        currentCode = "4";
                    else if ("mn".IndexOf(currentLetter) > -1)
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
            int result = 0;

            string soundex1 = s1.SoundEx();
            string soundex2 = s2.SoundEx();
            if (soundex1 == soundex2)
                result = 4;
            else
            {
                string sub1 = soundex1.Substring(1, 3);
                string sub2 = soundex1.Substring(2, 2);
                string sub3 = soundex1.Substring(1, 2);
                string sub4 = soundex1.Substring(1, 1);
                string sub5 = soundex1.Substring(2, 1);
                string sub6 = soundex1.Substring(3, 1);

                if (soundex2.IndexOf(sub1) > -1)
                    result = 3;
                else if (soundex2.IndexOf(sub2) > -1)
                    result = 2;
                else if (soundex2.IndexOf(sub3) > -1)
                    result = 2;
                else
                {
                    if (soundex2.IndexOf(sub4) > -1)
                        result++;
                    if (soundex2.IndexOf(sub5) > -1)
                        result++;
                    if (soundex2.IndexOf(sub6) > -1)
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
            JaroWinkler jw = new JaroWinkler();
            result = jw.GetDistance(source, target);
            jw = null;
            return result;

        }

    }
}
