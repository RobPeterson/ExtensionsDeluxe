using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StringExtension
{
    public static class StringCryptography
    {
        /// <summary>
        /// This will return the MD5 Hash of a string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMd5(this string myString)
        {
            if (myString == null) return "";
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(myString));
            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            var sBuilder = new StringBuilder();
            md5Hash.Dispose();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (var i = 0; i < data.Length; i++)
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
        public static byte[] GetSha1(this string myString)
        {
            var data = myString.ToBytes();
            SHA1 sha = new SHA1CryptoServiceProvider();
            var result = sha.ComputeHash(data);
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
            var data = myString.ToBytes();
            SHA512 shaM = new SHA512Managed();
            var result = shaM.ComputeHash(data);
            shaM.Dispose();
            return result;
        }







    }
}
