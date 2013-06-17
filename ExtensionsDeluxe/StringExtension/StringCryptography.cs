using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StringExtensions
{
    public static class StringCryptography
    {
        /// <summary>
        /// This will return the MD5 Hash of a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMD5(this string myString)
        {
            if (myString == null) return "";
            MD5 md5hash = MD5.Create();
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(myString));
            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            md5hash.Dispose();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        /// <summary>
        /// This will return the SHA-1 has of a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static byte[] GetSHA1(this string myString)
        {
            byte[] data = myString.ToBytes();
            byte[] result;
            SHA1 sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);
            sha.Dispose();
            return result;
        }


        /// <summary>
        /// This will return the 512 bit SHA-2 hash.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static byte[] GetSHA2_512(this string myString)
        {
            byte[] data = myString.ToBytes();
            byte[] result;
            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(data);
            shaM.Dispose();
            return result;
        }







    }
}
