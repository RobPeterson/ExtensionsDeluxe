using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* TODO:  Make a smart number class to select appropriate primitive types to avoid unnecessarily using ulong, long and avoid extra casting.
 * This should improve performance.
 * */
namespace IntegerExtensions
{
    public static class NumberExtensionsGenerics
    {
        public static bool IsPrime<T>(T value)
        {
            bool bIsPrime = true;
            ulong number = 0;
            if(!ulong.TryParse(value.ToString(), out number))
            return false; // Negative numbers are not null.
           
            // Assume that the integer supplied is actually a prime, then test for
            // statements that make this condition false
            ulong lSquareRoot = (ulong)(Math.Sqrt(number));

            for (ulong l = 2; l <= lSquareRoot; l++)
            {
                //  If the result of this calculation is greater than zero, then we will consider the integer to be prime
                //  If we encounter one zero result in this loop, we will consider the integer to NOT be prime

                bIsPrime = ((long)(number % l) > 0);

                if (bIsPrime == false)
                {
                    // Break out of the loop
                    break;
                }
            }

            return bIsPrime; 
        }




        public static bool IsPerfectSquare<T>(T value)
        {
            var a = UInt64.Parse(value.ToString());
            var s = (ulong)Math.Sqrt(a);
            return (s * s == a);
        }

        public static bool IsFibonacci<T>(T value)
        {
            var a = UInt64.Parse(value.ToString());
            return ((5 * a * a + 4).IsPerfectSquare() || (5 * a * a - 4).IsPerfectSquare());
        }

        public static ulong GreatestCommonDenominator<T>(T a, T b)
        {
            /* Jeff Reddy
             * http://extensionmethod.net/csharp/int32/lcm
             */
            var value1 = UInt64.Parse(a.ToString());
            var value2 = UInt64.Parse(b.ToString());

            while (value1 != 0 && value2 != 0)
            {
                if (value1 > value2)
                    value1 %= value2;
                else
                    value2 %= value1;
            }
            return Math.Max(value1, value2);
        }

        /// <summary>
        /// This will return the least common multiple of two numbers.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static ulong LeastCommonMultiple<T>(T value1, T value2)
        {
            var number1 = ulong.Parse(value1.ToString());
            var number2 = ulong.Parse(value2.ToString());
            
            return (number1 / GreatestCommonDenominator<T>((T)Convert.ChangeType(number1,typeof(T)), (T)Convert.ChangeType(number2,typeof(T)))) * number2;
        }

 


        public static long[] ToArray<T>(T value)
        {
            /*waldyrfelix
                         * http://extensionmethod.net/csharp/int32/toarray
                         */
            var number = Int64.Parse(value.ToString());
            if (number == 0)
            {
                return new long[0];
            }
            else if (number < 0)
            {
                number = -1 * number;
            }

            var list = new List<long>();
            while (number > 0)
            {
                list.Add(number % 10);
                number = number / 10;
            }
            list.Reverse();

            return list.ToArray();
        }

        /// <summary>
        /// This returns the number of digits in number.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Length<T>(T value)
        {
            var number = Int64.Parse(value.ToString());
            var s = number.ToString(CultureInfo.InvariantCulture);
            return s.Length;
        }

        public static bool IsEven<T>(T value)
        {
            ulong number;
            long signedNumber;
            if (ulong.TryParse(value.ToString(),out number))
                return (number % 2 == 0);
            if (long.TryParse(value.ToString(), out signedNumber))
                return (number % 2 == 0);
            return false;
        }

        public static bool IsOdd<T>(T value)
        {
            ulong number;
            long signedNumber;
            if (ulong.TryParse(value.ToString(), out number))
                return (number % 2 == 1);
            if (long.TryParse(value.ToString(), out signedNumber))
                return (number % 2 == 1);
            return false;
        }
    }
}
