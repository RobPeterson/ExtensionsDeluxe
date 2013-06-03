﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public static class StringFactoryExtensions
    {
        public static string ToMorseCode(this string myString)
        {
            if (myString == null) return null;
            StringBuilder sb = new StringBuilder();
            string morseChar;
            foreach (char c in myString)
            {
                morseChar = TranslateCharToMorseCode(c);
                if (!String.IsNullOrEmpty(morseChar))
                {
                    sb.Append(morseChar);
                    sb.Append(" ");
                }
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
            if (c == 'a' || c == 'A') return "·–";
            if (c == 'b' || c == 'B') return "–···";
            if (c == 'c' || c == 'C') return "–·–·";
            if (c == 'd' || c == 'D') return "–··";
            if (c == 'e' || c == 'E') return "·";
            if (c == 'f' || c == 'F') return "··–·";
            if (c == 'g' || c == 'G') return "––·";
            if (c == 'h' || c == 'H') return "····";
            if (c == 'i' || c == 'I') return "··";
            if (c == 'j' || c == 'J') return "·–––";
            if (c == 'k' || c == 'K') return "–·–";
            if (c == 'l' || c == 'L') return "·–··";
            if (c == 'm' || c == 'M') return "––";
            if (c == 'n' || c == 'N') return "–·";
            if (c == 'o' || c == 'O') return "–––";
            if (c == 'p' || c == 'P') return "·––·";
            if (c == 'q' || c == 'Q') return "––·–";
            if (c == 'r' || c == 'R') return "·–·";
            if (c == 's' || c == 'S') return "···";
            if (c == 't' || c == 'T') return "–";
            if (c == 'u' || c == 'U') return "··–";
            if (c == 'v' || c == 'V') return "···–";
            if (c == 'w' || c == 'W') return "·––";
            if (c == 'x' || c == 'X') return "–··–";
            if (c == 'y' || c == 'Y') return "–·––";
            if (c == 'z' || c == 'Z') return "––··";
            if (c == '1') return "·––––";
            if (c == '2') return "··–––";
            if (c == '3') return "···––";
            if (c == '4') return "····–";
            if (c == '5') return "·····";
            if (c == '6') return "–····";
            if (c == '7') return "––···";
            if (c == '8') return "–––··";
            if (c == '9') return "––––·";
            if (c == '0') return "–––––";
            if (c == '.') return "·–·–·–";
            if (c == ',') return "––··––";
            if (c == '?') return "··––··";
            if (c == '\'') return "·––––·";
            if (c == '!') return "–·–·––";
            if (c == '/') return "–··–·";
            if (c == '(') return "–·––·";
            if (c == ')') return "–·––·–";
            if (c == '&') return "·–···";
            if (c == ':') return "–––···";
            if (c == ';') return "–·–·–·";
            if (c == '=') return "–···–";
            if (c == '+') return "·–·–·";
            if (c == '-') return "–····–";
            if (c == '_') return "··––·–";
            if (c == '"') return "·–··–·";
            if (c == '$') return "···–··–";
            if (c == '@') return "·––·–·";
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
            string result = "";
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
            string result = "";
            int startIndex = 0;
            if (myString.Length <= numberOfCharacters || myString.Length == 0)
            {
                return myString;
            }
            startIndex = myString.Length - numberOfCharacters - 1;
            result = myString.Substring(startIndex, numberOfCharacters);
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
            string result = "";
            int netLength = 0;
            if (myString.Length == 0) return "";
            if (myString.Length <= endIndex)
                endIndex = myString.Length - 1;
            netLength = startIndex - endIndex;
            result = myString.Substring(startIndex, netLength);
            return result;
        }

    }
}
