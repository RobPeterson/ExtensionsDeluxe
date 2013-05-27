using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bool hasUpper = false;
            bool hasLower = false;
            bool hasNumber = false;
            bool hasPunctuation = false;
            const int minimumLength = 6; 
            int index = 0;
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
            return  (hasUpper && hasLower && hasNumber && hasPunctuation);
        }

        // TODO:  Make a password strength method that take requirements as arguments.

    }
}
