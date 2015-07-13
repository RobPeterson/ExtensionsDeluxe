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


        /// <summary>
        /// This will return true if the string is a word in the dictionary, false if it is not a word in the dictionary,
        /// and null if it cannot be determined.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static bool? IsDictionaryWord(this string myString)
        {
            //TODO:  Try using a web service.
            // One possiblility is http://services.aonaware.com/DictService/DictService.asmx?op=Match
            bool? result = null;
            // TODO: Handle web connectivity issues.
            DictionaryService.DictServiceSoapClient client = new DictionaryService.DictServiceSoapClient();
            DictionaryService.DictionaryWord[] words;
            words = client.Match(myString,"exact");
            result = words.Length > 0;


            return result;
        }

        /// <summary>
        /// This will validate the credit card number using the Lunh (Mod 10) algorithm.
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns></returns>
        public static bool Mod10Check(this string creditCardNumber)
        {
            // http://www.codeproject.com/Tips/515367/Validate-credit-card-number-with-Mod-algorithm
            //// check whether input string is null or empty
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            /* 1.	Starting with the check digit double the value of every other digit 
             2.	If doubling of a number results in a two digits number, add up
               the digits to get a single digit number. This will results in eight single digit numbers                    
             3. Get the sum of the digits
             */
            var sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);


            //// If the final sum is divisible by 10, then the credit card number
            //   is valid. If it is not divisible by 10, the number is invalid.            
            return sumOfDigits % 10 == 0;
        }

    }


}
