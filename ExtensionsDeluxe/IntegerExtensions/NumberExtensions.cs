using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerExtensions
{
    public static class NumberExtensions
    {

        /// <summary>
        /// This will return true if an number is prime; false otherwise.
        /// This implements the Miller Rabin algorithm for primality.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(this int n)
        {
            return NumberExtensionsGenerics.IsPrime<int>(n);
        }


        /// <summary>
        /// This will return true if this is a perfect square; false otherwise
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsPerfectSquare(this int a)
        {
            return NumberExtensionsGenerics.IsPerfectSquare<int>(a);
        }

        public static bool IsPerfectSquare(this ulong a)
        {
            return NumberExtensionsGenerics.IsPerfectSquare<ulong>(a);
        }


        /// <summary>
        /// This will return true if this is a Fibinoncci number.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsFibonacci(this ulong a)
        {
            return NumberExtensionsGenerics.IsFibonacci<ulong>(a);
        }

        public static bool IsFibonacci(this int a)
        {
            return NumberExtensionsGenerics.IsFibonacci<int>(a);
        }



        /// <summary>
        /// Returns the greatest common denominator.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static ulong GreatestCommonDenominator(this ulong value1, ulong value2)
        {
            return NumberExtensionsGenerics.GreatestCommonDenominator<ulong>(value1,value2);
        }




        /// <summary>
        /// Returns the least commong multiplier.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static ulong LeastCommonMultiplier(this ulong[] values)
        {
            return NumberExtensionsGenerics.LeastCommonMultiplier(values);
        }



        /// <summary>
        /// This will return all of the digits of a long number to an array.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static long[] ToArray(this long number)
        {
            return NumberExtensionsGenerics.ToArray<long>(number);
        }



        /// <summary>
        /// Get the length of a number, if were represented as a string.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Length(this long number)
        {
            return NumberExtensionsGenerics.Length<long>(number);
        }



        /// <summary>
        /// Return true if the number is even.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsEven(this long number)
        {
            return NumberExtensionsGenerics.IsEven<long>(number);
        }



        public static bool IsOdd(this long number)
        {
            return NumberExtensionsGenerics.IsOdd<long>(number);
        }
    }
}
