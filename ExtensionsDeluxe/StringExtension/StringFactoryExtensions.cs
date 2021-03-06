﻿using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace StringExtension
{
    public static class StringFactoryExtensions
    {
        public static string ToMorseCode(this string myString)
        {
            if (myString == null) return null;
            var sb = new StringBuilder();
            foreach (var morseChar in myString.Select(TranslateCharToMorseCode).Where(morseChar => !String.IsNullOrEmpty(morseChar)))
            {
                sb.Append(morseChar);
                sb.Append(" ");
            }
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Convert a character to a morse code representation.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string TranslateCharToMorseCode(char c)
        {
        // http://en.wikipedia.org/wiki/Morse_code#Letters.2C_numbers.2C_punctuation
            if (c == 'a' || c == 'A') return ".-";
            if (c == 'b' || c == 'B') return "-...";
            if (c == 'c' || c == 'C') return "-.-.";
            if (c == 'd' || c == 'D') return "-..";
            if (c == 'e' || c == 'E') return ".";
            if (c == 'f' || c == 'F') return "..-.";
            if (c == 'g' || c == 'G') return "--.";
            if (c == 'h' || c == 'H') return "....";
            if (c == 'i' || c == 'I') return "..";
            if (c == 'j' || c == 'J') return ".---";
            if (c == 'k' || c == 'K') return "-.-";
            if (c == 'l' || c == 'L') return ".-..";
            if (c == 'm' || c == 'M') return "--";
            if (c == 'n' || c == 'N') return "-.";
            if (c == 'o' || c == 'O') return "---";
            if (c == 'p' || c == 'P') return ".--.";
            if (c == 'q' || c == 'Q') return "--.-";
            if (c == 'r' || c == 'R') return ".-.";
            if (c == 's' || c == 'S') return "...";
            if (c == 't' || c == 'T') return "-";
            if (c == 'u' || c == 'U') return "..-";
            if (c == 'v' || c == 'V') return "...-";
            if (c == 'w' || c == 'W') return ".--";
            if (c == 'x' || c == 'X') return "-..-";
            if (c == 'y' || c == 'Y') return "-.--";
            if (c == 'z' || c == 'Z') return "--..";
            if (c == '1') return ".----";
            if (c == '2') return "..---";
            if (c == '3') return "...--";
            if (c == '4') return "....-";
            if (c == '5') return ".....";
            if (c == '6') return "-....";
            if (c == '7') return "--...";
            if (c == '8') return "---..";
            if (c == '9') return "----.";
            if (c == '0') return "-----";
            if (c == '.') return ".-.-.-";
            if (c == ',') return "--..--";
            if (c == '?') return "..-..";
            if (c == '\'') return ".----.";
            if (c == '!') return "-.-.--";
            if (c == '/') return "-..-.";
            if (c == '(') return "-.--.";
            if (c == ')') return "-.--.-";
            if (c == '&') return ".-...";
            if (c == ':') return "---...";
            if (c == ';') return "-.-.-.";
            if (c == '=') return "-...-";
            if (c == '+') return ".-.-.";
            if (c == '-') return "-....-";
            if (c == '_') return "..--.-";
            if (c == '"') return ".-..-.";
            if (c == '$') return "...-..-";
            if (c == '@') return ".--.-.";
            return "";
        }


        /// <summary>
        /// This will return the left part of the string up to the number of characters specified.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="numberOfCharacters"></param>
        /// <returns></returns>
        public static string Left(this string myString, int numberOfCharacters)
        {
            if (myString == null) return null;
            var result = "";
            if (numberOfCharacters >= myString.Length)
            {
                result = myString;
                return result;
            }
            result = myString.Substring(0, numberOfCharacters);
            return result;
        }

        /// <summary>
        /// This will return the right part of the string up to the number of characters specified.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="numberOfCharacters"></param>
        /// <returns></returns>
        public static string Right(this string myString, int numberOfCharacters)
        {
            if (myString == null) return null;
            var result = "";
            var startIndex = 0;
            if (myString.Length <= numberOfCharacters || myString.Length == 0)
            {
                return myString;
            }
            startIndex = myString.Length - numberOfCharacters;
            result = myString.Substring(startIndex, numberOfCharacters);
            return result;
        }

        /// <summary>
        /// This will return the right part of a string to the right of the given index.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string RightOf(this string myString, int index)
        {
            if (myString == null) return null;
            var result = "";
            if (index == 0 || myString.Length == 0)
            {
                return myString;
            }
            if (index >= myString.Length - 1)
            {
                return result;
            }
     
            result = myString.Substring(index + 1, myString.Length - index - 1);
            return result;
        }

        /// <summary>
        /// This will return the Left part of a string to the left of the given index.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string LeftOf(this string myString, int index)
        {
            if (myString == null) return null;
            var result = "";
            if (index >= myString.Length || myString.Length == 0)
            {
                return myString;
            }
            if (index >= myString.Length - 1)
            {
                return result;
            }

            result = myString.Substring(0, index);
            return result;
        }

        /// <summary>
        /// This will return the substring between (inclusive) the startIndex and the endIndex.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static string Middle(this string myString, int startIndex, int endIndex)
        {
            if (myString == null) return null;
            var result = "";
            var netLength = 0;
            if (myString.Length == 0) return "";
            if (myString.Length <= endIndex)
                endIndex = myString.Length - 1;
            netLength = endIndex - startIndex + 1;
            result = myString.Substring(startIndex, netLength);
            return result;
        }

        /// <summary>
        /// This will return the contents of the string as a byte array.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string myString)
        {
            var bytes = new byte[myString.Length * sizeof(char)];
            System.Buffer.BlockCopy(myString.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Convert enum description to enum value.
        /// </summary>
        /// <typeparam name="T">T should be an Enum type</typeparam>
        /// <param name="description">The name of an element in the enum.</param>
        /// <returns>Type of T</returns>
        public static T GetEnumValueFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        /// <summary>
        /// This will return true if the description value can be translated to an enum value of type T; 
        /// Otherwise false will be returned.
        /// </summary>
        /// <typeparam name="T">T should be an enum</typeparam>
        /// <param name="description"> The description is the name or description of an element in the enum.</param>
        /// <param name="anEnumValue">The value that corresponds to the element in the enum.</param>
        /// <returns>True if the description is successfully translated to a value or false if the value is defaulted.</returns>
        public static bool TryGetEnumValueFromDescription<T>(this string description, out T anEnumValue)
        {
            var result = true;
            anEnumValue = default(T);

            try
            {
                anEnumValue = GetEnumValueFromDescription<T>(description);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }


        // TODO:  Test the parsing methods and perhaps move to the validation project since this is not really a factory method.

        /// <summary>
        /// This will use reflection to parse a string into the type of T.  It will return true if it parsed; false otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse<T>(this string s, out T result)
        {
            result = default(T);
            var parsed = false;
            try
            {
                Type type;
               
                type = Nullable.GetUnderlyingType(typeof(T));
                if(type == null)
                {
                    type = typeof(T);
                }   
                var m = type.GetMethod("Parse", new Type[] { typeof(string) });
                if (m != null) { result = (T)m.Invoke(null, new object[] { s }); }
                parsed = true;

            }
            catch (Exception)
            {

                parsed = false;
            }

            return parsed;
        }


        /// <summary>
        /// This will return true if the string is null or empty and the type of T is nullable.
        /// </summary>
        /// <typeparam name="T">The type you are trying to parse to.</typeparam>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryNullableParse<T> (this String s, out T result)
        {
            result = default(T);
            var parsed = false;
            var type = typeof (T);
            try
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable))
                {
                    if (String.IsNullOrEmpty(s))
                        return true;
                }
                parsed = s.TryParse<T>(out result);

            }
            catch (Exception)
            {
                parsed = false;
            }

            return parsed;

        }


        /// <summary>
        /// This will return the last character of a string as a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetLastCharacterAsString(this string myString)
        {
            if (myString.Length == 0) return "";
            if (myString.Length == 1)
                return myString;
            else
            {
                var a = myString[myString.Length - 1];
                return a.ToString(CultureInfo.InvariantCulture);
            }

        }

        /// <summary>
        /// This will return the first character of a string as a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetFirstCharacterAsString(this string myString)
        {
            if (myString.Length == 0) return "";
            if (myString.Length == 1)
                return myString;
            else
            {
                return myString[0].ToString(CultureInfo.InvariantCulture);;
            }
        }

        ///// <summary>
        ///// This will remove the left most character of the string and return it like a pop of a queue.
        ///// </summary>
        ///// <param name="myString"></param>
        ///// <returns></returns>
        //public static string PopLeft(this string myString)
        //{
            
        //    if (myString == null) return null;
        //    if (myString == "") return "";
        //    if (myString.Length == 1)
        //    {
        //        var result = myString;
        //        myString = "";
        //        return result;
        //    }
        //    else
        //    {
                
        //        var result = myString.GetFirstCharacterAsString();
        //        myString = myString.Substring(1, myString.Length - 1);
        //        return result;
        //    }
        //}

        ///// <summary>
        ///// This will remove the right most character of the string and return it like a pop of a queue.
        ///// </summary>
        ///// <param name="myString"></param>
        ///// <returns></returns>
        //public static string PopRight(this string myString)
        //{

        //    if (myString == null) return null;
        //    if (myString == "") return "";
        //    if (myString.Length == 1)
        //    {
        //        var result = myString;
        //        myString = "";
        //        return result;
        //    }
        //    else
        //    {
        //        var result = myString.GetLastCharacterAsString();
        //        myString = myString.Substring(0, myString.Length - 1);
        //        return result;
        //    }
        
        //}

        /// <summary>
        /// Return all characters to the right of the first occurence of the search text.
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static string RightOfFirst(this string myString, string subString)
        {
            var startIndex = myString.IndexOf(subString, System.StringComparison.Ordinal);
            return startIndex == 0 ? String.Empty : myString.RightOf(startIndex + subString.Length -1);
        }


        /// <summary>
        /// Return all characters to the left of the first occurence of the 
        /// </summary>
        /// <param name="myString"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static string LeftOfFirst(this string myString, string subString)
        {
            var startIndex = myString.IndexOf(subString, System.StringComparison.Ordinal);
            return startIndex == 0 ? String.Empty : myString.Left(startIndex);
        }

        /// <summary>
        /// Return all perfect anagrams of a given string.
        /// This may include known Acronyms that appear in the dictionary.
        /// This also only works for single words and does not generate phrases.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static List<string> GetAnagrams(this string myString)
        {
            var result = new List<string>();
            var permutations = myString.GetPermutations();
            foreach(var candidateWord in permutations)
            {
                var isWord = candidateWord.IsDictionaryWord();
                if(isWord.HasValue && isWord.Value)
                {
                    result.Add(candidateWord);
                }
            }
            return result;
        }

        /// <summary>
        /// This will return any name Given Names or Surnames that can be generated by the given letters.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static List<string> GetNameAnagrams(this string myString)
        {
            var result = new List<string>();
            var lowered = myString.ToLower();

            var properNames =  new ProperNameCollection();
            var permutations = lowered.GetPermutations();
            foreach (var candidateName in from candidateName in permutations let isName = properNames.IsGivenName(candidateName) || properNames.IsSurname(candidateName) where isName where !result.Contains(candidateName.GetCapitalized()) select candidateName)
            {
                result.Add(candidateName.GetCapitalized());
            }
            return result;
        } 


        /// <summary>
        /// This will get a list of dictionary definitions for the given string if one exists.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static List<string> GetDefinitions(this string myString)
        {
            string baseURI = "https://api.dictionaryapi.dev/api/v2/entries/en_US/";
            string URL = $"{baseURI}{myString}";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            List<string> result = new List<string>();


            // List data response.
            HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var content = response.Content.ReadAsStringAsync().Result;
                var googleDictionaryResultList = System.Text.Json.JsonSerializer.Deserialize<List<GoogleDictionaryResult>>(content);

                 foreach (var googleDictionaryResult in googleDictionaryResultList)
                 {
                    foreach (var meaning in googleDictionaryResult.meanings)
                        foreach (var definition in meaning.definitions)
                            result.Add(definition.definition);
                 }
                
            }
            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return result;
        }


        /// <summary>
        /// This will get all permutations of a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static List<string> GetPermutations(this string myString)
        {
            // There should be n! permutations of a string where n is the number of elements (characters).
            var output = new HashSet<string>(); // Use a hashset to prevent duplicates.
            if (myString.Length == 1)
            {
                output.Add(myString);
            }
            else
            {
                foreach (var c in myString)
                {
                    // Remove one occurrence of the char (not all)
                    var tail = myString.Remove(myString.IndexOf(c), 1);
                    foreach (var tailPerms in tail.GetPermutations())
                    {
                        output.Add(c + tailPerms);
                    }
                }
            }
            return output.ToList<string>();
        }

        /// <summary>
        /// This will capitalize the first letter of the workd.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetCapitalized(this string myString)
        {
            var result = myString;
            if (string.IsNullOrEmpty(myString))
                return "";
            var first = myString.GetFirstCharacterAsString();
            if (!char.IsLetter(first[0])) return result;
            first = first.ToUpper();
            result = first + myString.Substring(1, myString.Length - 1);
            return result;

        }

        /// <summary>
        /// Get the number of unique substrings in a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static List<string> GetDistinctSubstrings(this string myString)
        {

            var all = new HashSet<string>();
            var last = new HashSet<StringBuilder>();

            foreach (var t in myString)
            {
                foreach (var sb in last)
                {
                    sb.Append(t);
                    if (!all.Contains(sb.ToString()))
                    {
                        all.Add(sb.ToString());
                    }
                }
                if (!all.Contains(t + ""))
                {
                    all.Add(myString + "");
                }
                last.Add(new StringBuilder(t + ""));
            }
            return all.ToList();
        }
    

    }
}
