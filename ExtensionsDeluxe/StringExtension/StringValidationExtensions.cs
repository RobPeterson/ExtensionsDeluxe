﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringExtension;
using System.Xml;
using System.Net;
using System.IO;
using System.Net.Http;

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
        /// 
        

       
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
        /// This will return true if two English spoken strings sound alike based on Double Metaphone primary key.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="target"></param>
        /// <returns>Returns true if the SoundEx difference = 4.</returns>
        public static bool IsHomophone(this string myString, string target)
        {
            if (myString == null || target == null) return false;

            //return (myString.SoundExDifference(target) == 4)
            var primaryMetaphone1 = DoubleMetaphone.GetDoubleMetaphone(myString).Primary;
            var primaryMetaphone2 = DoubleMetaphone.GetDoubleMetaphone(target).Primary;
            return (primaryMetaphone1 == primaryMetaphone2);

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
            var words = myString.GetDefinitions();
            if (words.Count > 0)
                return true;
            else return false;  
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

        /// <summary>
        /// This will return true if my string and prefix is not null and myString begins with the given prefix;
        /// otherwise false is returned.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static bool HasPrefix(this string myString, string prefix)
        {
            if (myString == null) return false;
            if (prefix == null) return false;
            if (myString.Length < prefix.Length) return false;
            return (myString.Left(prefix.Length) == prefix);
        }

        /// <summary>
        /// This will return true if my string and prefix si not null and myString ends with the given suffix;
        /// otherise false is returned.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static bool HasSuffix(this string myString, string suffix)
        {
            if (myString == null) return false;
            if (suffix == null) return false;
            if (myString.Length < suffix.Length) return false;
            return (myString.Right(suffix.Length) == suffix);
        }

        /* If it is a known given name return true; false otherwise. */
        public static bool IsGivenName(this string myString)
        {
            ProperNameCollection names = new ProperNameCollection();
            return names.IsGivenName(myString);
        }

        public static bool IsGivenNameFemale(this string myString)
        {
            return true;
        }

        public static bool IsGivenNameMale(this string myString)
        {
            return true;
        }

        /* If it is a known surname return ture; false otherwise.*/
        public static bool IsSurname(this string myString)
        {
            ProperNameCollection names = new ProperNameCollection();
            return names.IsSurname(myString);
        }

        /* TODO:  Implement the first name last validation.  Try to do in memory. May need to create a series of small name collections as subsets of the whole
       I would prefer to hit a web service to do this,
        but so far have not found an existing one.
        
        Also, consider adding a grammar check. http://www.afterthedeadline.com/api.slp
        
        Also, consider adding a location name check.
        
        Also, consider a Google search to see if there are any hits.*/

        public static bool IsAddress(this string myString)
        {
            /* So, try a google hack.
            Search for an address and if a map appears it found an address.
            in the returned html look for an image with the id=lu_map.
            the alt tag on the image has "Map of " and then the address that matched up. 
            https://www.google.com/#safe=off&q=14435+Penrod+Detroit+MI+48223
            */
            var queryString = "/search?sclient=psy-ab&site=&source=hp&q=" + GetQueryStringFormat(myString);
            var url = "https://www.google.com" + queryString;
            //var queryString = "q=" + GetQueryStringFormat(myString);
            //var url = "https://maps.google.com/maps?" + queryString;
            //Task taskCheckGoogle = new Task(()=>StringValidationExtensions.Checkaddress(url));
            //taskCheckGoogle.Start();

            Task<string> result = Checkaddress(url);
            var content = result.Result;
            //return content.Contains("lu_map");
            var pattern = "ll=-?\\d+(\\.\\d+)?";
            /* if it is real address, there will be a lattitude and longitude number
            in the query string to google maps, if not there will not be a longitude or a latitude*/ 
            return System.Text.RegularExpressions.Regex.IsMatch(content, pattern);
        }

        async static Task<string> Checkaddress(string url)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private static string GetQueryStringFormat(string aString)
        {
            var sb = new StringBuilder();
            var lastAdded = '*';
            aString = aString.Trim();
            foreach (var a in aString)
            {

                if (char.IsLetterOrDigit(a))
                {
                    sb.Append(a);
                    lastAdded = a;
                }
                else
                {
                    if (lastAdded == '+') continue;
                    sb.Append('+');
                    lastAdded = '+';
                }
            }
            return sb.ToString();
        }

    }






}
