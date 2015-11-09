using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringExtension;
using System.Xml;
using System.Net;
using System.IO;

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
            // One possiblility is http://services.aonaware.com/DictService/DictService.asmx?op=Match

            string url = "http://services.aonaware.com/DictService/DictService.asmx";
            string action = "http://services.aonaware.com/webservices/Match";


            StringBuilder request = new StringBuilder();
            request.AppendLine("<?xml version = \"1.0\" encoding = \"utf-8\" ?>");
            request.AppendLine("<soap:Envelope xmlns:xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd = \"http://www.w3.org/2001/XMLSchema\" xmlns:soap = \"http://schemas.xmlsoap.org/soap/envelope/\" >");
            request.AppendLine("<soap:Body>");
            request.AppendLine("<Match xmlns = \"http://services.aonaware.com/webservices/\" >");
            request.AppendLine("<word>");
            request.Append(myString);
            request.Append("</word>");
            request.AppendLine("<strategy>");
            request.Append("exact");
            request.Append("</strategy>");
            request.AppendLine("</Match>");
            request.AppendLine("</soap:Body>");
            request.AppendLine("</soap:Envelope>");
            string x = request.ToString(); ;

            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(x);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelop.Save(stream);
            }


            // Submit Request
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }

            }

            // parse the definitions into a list.
            XmlDocument soapResultXML = new XmlDocument();
            soapResultXML.LoadXml(soapResult);

            var words = soapResultXML.GetElementsByTagName("DictionaryWord");

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
    }





}
