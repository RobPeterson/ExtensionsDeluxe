/* This will provide a collection of extension methods for strings to make life easier for developers.
 * It make lead go unnecessary code bloat.
 * Some ideas:
 *  StringFormatting
 *  String Analysts, SoundEx, Levenstein,
 *  Tweet
 *  FBPost
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public class StringModifyingExtensions
    {
        /// <summary>
        /// Remove any characters that are not digits.
        /// </summary>
        /// <param name="myString"></param>
        public void RemoveNonDigits(this string myString)
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
        public void RemoveNonAlpha(this string myString)
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
        /// Remove any characters that are punctuation.
        /// </summary>
        /// <param name="myString"></param>
        public void RemovePunctuation(this string myString)
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
        public void RemoveWhiteSpace(this string myString)
        {
            if (myString == null) return;
            StringBuilder sb = new StringBuilder();
            foreach (char c in myString)
            {
                if (!Char.IsWhiteSpace(c))
                    sb.Append(c);
            }
        }


    }
}
