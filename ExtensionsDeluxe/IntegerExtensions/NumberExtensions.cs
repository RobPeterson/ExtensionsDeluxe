﻿using System;
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
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(this int n)
        {
            return NumberExtensionsGenerics.IsPrime(n);
        }


        /// <summary>
        /// This will return true if this is a perfect square; false otherwise
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsPerfectSquare(this int a)
        {
            return NumberExtensionsGenerics.IsPerfectSquare(a);
        }

        public static bool IsPerfectSquare(this ulong a)
        {
            return NumberExtensionsGenerics.IsPerfectSquare(a);
        }


        /// <summary>
        /// This will return true if this is a Fibinoncci number.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsFibonacci(this ulong a)
        {
            return NumberExtensionsGenerics.IsFibonacci(a);
        }

        public static bool IsFibonacci(this int a)
        {
            return NumberExtensionsGenerics.IsFibonacci(a);
        }



        /// <summary>
        /// Returns the greatest common denominator.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static ulong GreatestCommonDenominator(this ulong value1, ulong value2)
        {
            return NumberExtensionsGenerics.GreatestCommonDenominator(value1,value2);
        }

        public static ulong GreatestCommonDenominator(this int value1, int value2)
        {
            return NumberExtensionsGenerics.GreatestCommonDenominator(value1, value2);
        }


        /// <summary>
        /// This will return the least common multiple of two numbers.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static ulong LeastCommonMultiple(this ulong value1, ulong value2)
        {
            return NumberExtensionsGenerics.LeastCommonMultiple(value1,value2);
        }

        public static ulong LeastCommonMultiple(this int value1, int value2)
        {
            return NumberExtensionsGenerics.LeastCommonMultiple(value1, value2);
        }


        /// <summary>
        /// This will return all of the digits of a long number to an array.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static long[] ToArray(this long number)
        {
            return NumberExtensionsGenerics.ToArray(number);
        }


        /// <summary>
        /// This returns an array of the digits in a number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static long[] ToArray(this int number)
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
            return NumberExtensionsGenerics.Length(number);
        }

        public static int Length(this int number)
        {
            return NumberExtensionsGenerics.Length(number);
        }



        /// <summary>
        /// Return true if the number is even.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsEven(this long number)
        {
            return NumberExtensionsGenerics.IsEven(number);
        }

        public static bool IsEven(this int number)
        {
            return NumberExtensionsGenerics.IsEven(number);
        }


        public static bool IsOdd(this long number)
        {
            return NumberExtensionsGenerics.IsOdd(number);
        }

        public static bool IsOdd(this int number)
        {
            return NumberExtensionsGenerics.IsOdd(number);
        }

        public static double GetFractionalPart(this double value)
        {

            return value - Math.Floor(value);

        }

        public static decimal GetFractionalPart(this decimal value)
        {
            return value - Math.Floor(value);
        }

        public static double GetIntegerPart(this double value)
        {
            return (Math.Floor(value));
        }

        public static double GetIntegerPart(this decimal value)
        {
            return (Math.Floor((double)value));
        }
    }
}
