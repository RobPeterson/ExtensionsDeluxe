using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringExtension;

namespace StringExtension
{
    public static class StringValidationExtensions
    {
        /// <summary>
        /// This will return true if the string satisfies a certain minimum pre-defined password strength.
        /// Must contain both uppper and lower case characters, number, and symbol, and be at least 6 characters long.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static bool IsPasswordMinimumCriteria(this string myString)
        {
            var hasUpper = false;
            var hasLower = false;
            var hasNumber = false;
            var hasPunctuation = false;
            const int minimumLength = 6; 
            var index = 0;
            if (myString ==  null)
                return false;
            if (myString.Length < minimumLength)
                return false;
            while(index < myString.Length || !(hasUpper && hasLower && hasNumber && hasPunctuation))
            {
                if (Char.IsDigit(myString[index]))
                    hasNumber = true;
                if (Char.IsLower(myString[index]))
                    hasLower = true;
                if (Char.IsUpper(myString[index]))
                    hasUpper = true;
                if (Char.IsPunctuation(myString[index]))
                    hasPunctuation = true; // TODO:  Maybe this should be has symbol.
            }
            return  (true);
        }

        // TODO:  Make a password strength method that take requirements as arguments.

        /// <summary>
        /// This will return true if two English spoken strings sound alike based on SoundEx Difference.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="target"></param>
        /// <returns>Returns true if the SoundEx difference = 4.</returns>
        public static bool IsHomophone(this string myString, string target)
        {
            if (myString == null || target == null) return false;

            return (myString.SoundExDifference(target) == 4);
        }

        
        /// <summary>
        /// This will return true if the string is a palindrome; false otherwise.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static bool IsPalindrome(this string myString)
        {
            if (myString == null) return false;
            string reverse = String.Copy(myString);
            reverse.Reverse();
            return (reverse == myString);
        }

    }
}
