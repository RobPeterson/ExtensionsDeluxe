/* This will provide a collection of extension methods for strings to make life easier for developers.
 * It make lead go unnecessary code bloat.
 * Some ideas:
 *  StringFormatting
 *  Randomize
 *  Cryptographic Shuffle.
 *  MD5
 *  Sha1, Sha2 Checksum
 *  RemoveMarkup
 *  Encrypt
 *  Reverse
 *  ToMorseCodeTones i.e make sounds.
 *  String Analysts, SoundEx, Levenstein,
 *  Tweet
 *  FBPost
 */

using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace StringExtension
{
    public static class StringModifyingExtensions
    {
        /// <summary>
        /// Remove any characters that are not digits.
        /// </summary>
        /// <param name="myString"></param>
        public static string RemoveNonDigits(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            foreach (char c in myString.Where(c => Char.IsDigit(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Remove any characters that are not letters in the alphabet.
        /// </summary>
        /// <param name="myString"></param>
        public static string RemoveNonAlpha(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            foreach (var c in myString.Where(Char.IsLetter))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// This will remove all characters that are not letters or digits. 
        /// </summary>
        /// <param name="myString"></param>
        public static string RemoveAllNonAlphaOrNonDigit(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            foreach (var c in myString.Where(c => Char.IsLetter(c) || Char.IsDigit(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Remove any characters that are punctuation.
        /// </summary>
        /// <param name="myString"></param>
        public static string RemovePunctuation(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            foreach (char c in myString.Where(c => !Char.IsPunctuation(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Remove any white space characters.
        /// </summary>
        /// <param name="myString"></param>
        public static string RemoveWhiteSpace(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            foreach (var c in myString.Where(c => !Char.IsWhiteSpace(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// This will perform a non-cryptographic shuffle of the string contents.
        /// </summary>
        /// <param name="myString"></param>
        public static string Shuffle(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            var randomizer = new Random();
            var currString = myString;
            while (currString.Length > 0)
            {
                var index = randomizer.Next(currString.Length);
                sb.Append(currString[index]);
                currString = currString.Remove(index, 1);
            }
            return sb.ToString();
        }

        /// <summary>
        /// This will reverse the order of the contents of the string.
        /// </summary>
        /// <param name="myString"></param>
        public static string Reverse(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            var index = 0;
            index = myString.Length - 1;
            while (index > -1)
                sb.Append(myString[index--]);
            return sb.ToString();
        }

        /// <summary>
        /// This will keep the left part of the string up to number of characters specified.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="numberOfCharacters"></param>
        public static string KeepLeft(this string myString, int numberOfCharacters)
        {
            if (myString == null) return null;
            if (myString.Length <= numberOfCharacters)
                return myString;
            return myString.Substring(0, numberOfCharacters);
        }

        /// <summary>
        /// This will return the right part of the string up to the number of characters specified.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="numberOfCharacters"></param>
        public static string KeepRight(this string myString, int numberOfCharacters)
        {
            if (myString == null) return null;
            if (myString.Length <= numberOfCharacters || myString.Length == 0)
                return myString;
            var startIndex = 0;
            startIndex = myString.Length - numberOfCharacters;
            return myString.Substring(startIndex, numberOfCharacters);
        }


        /// <summary>
        /// Rotate the string one character to the right.
        /// </summary>
        /// <param name="myString"></param>
        public static string RotateRight(this string myString)
        {
            if (myString.Length < 2) return myString;
            var last = myString.GetLastCharacterAsString();
            return last + myString.Substring(0, myString.Length - 1);
        }

        /// <summary>
        /// Rotate the string one character to the left.
        /// </summary>
        /// <param name="myString"></param>
        public static string RotateLeft(this string myString)
        {
            if (myString.Length < 2) return myString;
            var first = myString.GetFirstCharacterAsString();
            return myString.Substring(1, myString.Length - 1) + first;
        }

        /// <summary>
        /// This will rotate the characters of a string about a pivot point.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="pivot">The length of characters from the left to pivot.</param>
        public static string Rotate(this string myString, int pivot)
        {
            if (pivot > myString.Length) throw new ArgumentOutOfRangeException("pivot cannot be greater than the length of string");
            if (pivot < 0) throw new ArgumentOutOfRangeException("pivot cannot be less than zero.");
            if (pivot == myString.Length)
                return myString;
            var left = myString.Left(pivot);
            var right = myString.Substring(pivot, myString.Length - pivot);
            return right + left;
        }

        /// <summary>
        /// This remove will remove a sub string and replace it with a new substring.
        /// </summary>
        /// <param name="input">Current string.</param>
        /// <param name="start">First index of the substring to remove.</param>
        /// <param name="length">The number of characters the substring to remove.</param>
        /// <param name="replaceWith">The new substring.</param>
        /// <returns></returns>
        public static string Stuff(this string input, int start, int length, string replaceWith)
        {
            // Trying to mimic the stuff function that is available in MS SQL Server.
            return input.Remove(start, length).Insert(start, replaceWith);
        }
    }
}
