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
        public static void RemoveNonDigits(this string myString)
        {
            if (myString == null) return;
            var sb = new StringBuilder();
            foreach (char c in myString.Where(c => Char.IsDigit(c)))
            {
                sb.Append(c);
            }
            myString = sb.ToString();
        }

        /// <summary>
        /// Remove any characters that are not letters in the alphabet.
        /// </summary>
        /// <param name="myString"></param>
        public static void RemoveNonAlpha(this string myString)
        {
            if (myString == null) return;
            var sb = new StringBuilder();
            foreach (var c in myString.Where(Char.IsLetter))
            {
                sb.Append(c);
            }
            myString = sb.ToString();
        }

        /// <summary>
        /// This will remove all characters that are not letters or digits. 
        /// </summary>
        /// <param name="myString"></param>
        public static void RemoveAllNonAlphaOrNonDigit(this string myString)
        {
            if (myString == null) return;
            var sb = new StringBuilder();
            foreach (var c in myString.Where(c => Char.IsLetter(c) || Char.IsDigit(c)))
            {
                sb.Append(c);
            }
            myString = sb.ToString();
        }

        /// <summary>
        /// Remove any characters that are punctuation.
        /// </summary>
        /// <param name="myString"></param>
        public static void RemovePunctuation(this string myString)
        {
            if (myString == null) return;
            var sb = new StringBuilder();
            foreach (char c in myString.Where(c => !Char.IsPunctuation(c)))
            {
                sb.Append(c);
            }
            myString = sb.ToString();
        }

        /// <summary>
        /// Remove any white space characters.
        /// </summary>
        /// <param name="myString"></param>
        public static void RemoveWhiteSpace(this string myString)
        {
            if (myString == null) return;
            var sb = new StringBuilder();
            foreach (var c in myString.Where(c => !Char.IsWhiteSpace(c)))
            {
                sb.Append(c);
            }
            myString = sb.ToString();
        }

        /// <summary>
        /// This will perform a non-cryptographic shuffle of the string contents.
        /// </summary>
        /// <param name="myString"></param>
        public static void Shuffle(this string myString)
        {
            if (myString == null) return;
            var sb = new StringBuilder();
            var randomizer = new Random();
            while (myString.Length > 0)
            {
                var index = randomizer.Next(myString.Length);
                sb.Append(myString[index]);
                myString.Remove(index, 1);
            }
            myString = sb.ToString();
        }

        /// <summary>
        /// This will reverse the order of the contents of the string.
        /// </summary>
        /// <param name="myString"></param>
        public static void Reverse(this string myString)
        {
            if (myString == null) return;
            var sb = new StringBuilder();
            var index = 0;
            index = myString.Length - 1;
            while (index > -1)
                sb.Append(myString[index--]);
            myString = sb.ToString();
        }

        /// <summary>
        /// This will keep the left part of the string up to number of characters specified.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="numberOfCharacters"></param>
        public static void KeepLeft(this string myString, int numberOfCharacters)
        {
            if (myString == null) return;
            if (myString.Length <= numberOfCharacters)
                return;
            myString = myString.Substring(0, numberOfCharacters);
        }

        /// <summary>
        /// This will the right part of the string up to the number of characters specified.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="numberOfCharacters"></param>
        public static void KeepRight(this string myString, int numberOfCharacters)
        {
            if (myString == null) return;
            if (myString.Length <= numberOfCharacters || myString.Length == 0)
                return;
            var startIndex = 0;
            startIndex = myString.Length - numberOfCharacters - 1;
            myString = myString.Substring(startIndex, numberOfCharacters);
        }


        /// <summary>
        /// Rotate the string one character to the right.
        /// </summary>
        /// <param name="myString"></param>
        public static void RotateRight(this string myString)
        {
            if (myString.Length < 2) return;
            var last = myString.GetLastCharacterAsString();
            myString = last + myString.Substring(0, myString.Length - 1);
        }

        /// <summary>
        /// This will rotate the characters of a string about a pivot point.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="pivot">The length of characters from the left to pivot.</param>
        public static void Rotate(this string myString, int pivot)
        {
            if (pivot > myString.Length) throw new ArgumentOutOfRangeException("pivot cannot be greater than the length of string");
            if (pivot < 0) throw new ArgumentOutOfRangeException("pivot cannot be less than zero.");
            if (pivot == myString.Length)
                return;
            var left = myString.Left(pivot);
            var right = myString.Substring(pivot + 1, myString.Length);
            myString = right + left;
        }

        /// <summary>
        /// Rotate the string one character to the left.
        /// </summary>
        /// <param name="myString"></param>
        public static void RotateLeft(this string myString)
        {
            if (myString.Length < 2) return;
            var first = myString.GetFirstCharacterAsString();
            myString = myString.Substring(2, myString.Length - 2);

        }
    }
}
