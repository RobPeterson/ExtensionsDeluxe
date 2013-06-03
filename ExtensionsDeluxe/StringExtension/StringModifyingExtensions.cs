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
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
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
            StringBuilder sb = new StringBuilder();
            foreach (char c in myString)
            {
                if (Char.IsDigit(c))
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
            StringBuilder sb = new StringBuilder();
            foreach (char c in myString)
            {
                if (Char.IsLetter(c))
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
            StringBuilder sb = new StringBuilder();
            foreach (char c in myString)
            {
                if (Char.IsLetter(c) || Char.IsDigit(c))
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
            StringBuilder sb = new StringBuilder();
            foreach (char c in myString)
            {
                if (!Char.IsPunctuation(c))
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
            StringBuilder sb = new StringBuilder();
            foreach (char c in myString)
            {
                if (!Char.IsWhiteSpace(c))
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
            StringBuilder sb = new StringBuilder();
            Random randomizer = new Random();
            while (myString.Length > 0)
            {
                int index = randomizer.Next(myString.Length);
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
            StringBuilder sb = new StringBuilder();
            int index = 0;
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
            int startIndex = 0;
            startIndex = myString.Length - numberOfCharacters - 1;
            myString = myString.Substring(startIndex, numberOfCharacters);
        }

    }
}
