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
        public static bool IsPrime(this ulong n)
        {
            //Saeed Amiri http://stackoverflow.com/questions/4236673/sample-code-for-fast-primality-testing-in-c-sharp
            ulong[] ar;
            if (n < 4759123141) ar = new ulong[] {2, 7, 61};
            else if (n < 341550071728321) ar = new ulong[] {2, 3, 5, 7, 11, 13, 17};
            else ar = new ulong[] {2, 3, 5, 7, 11, 13, 17, 19, 23};
            ulong d = n - 1;
            int s = 0;
            while ((d & 1) == 0)
            {
                d >>= 1;
                s++;
            }
            int i, j;
            for (i = 0; i < ar.Length; i++)
            {
                ulong a = Math.Min(n - 2, ar[i]);
                ulong now = Pow(a, d, n);
                if (now == 1) continue;
                if (now == n - 1) continue;
                for (j = 1; j < s; j++)
                {
                    now = Mul(now, now, n);
                    if (now == n - 1) break;
                }
                if (j == s) return false;
            }
            return true;
        }

        private static ulong Mul(ulong a, ulong b, ulong mod)
        {
            int i;
            ulong now = 0;
            for (i = 63; i >= 0; i--) if (((a >> i) & 1) == 1) break;
            for (; i >= 0; i--)
            {
                now <<= 1;
                while (now > mod) now -= mod;
                if (((a >> i) & 1) == 1) now += b;
                while (now > mod) now -= mod;
            }
            return now;
        }

        private static ulong Pow(ulong a, ulong p, ulong mod)
        {
            if (p == 0) return 1;
            return p%2 == 0 ? Pow(Mul(a, a, mod), p/2, mod) : Mul(Pow(a, p - 1, mod), a, mod);
        }

        /// <summary>
        /// This will return true if this is a perfect square; false otherwise
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsPerfectSquare(this ulong a)
        {
            var s = (ulong) Math.Sqrt(a);
            return (s*s == a);
        }

        /// <summary>
        /// This will return true if this is a Fibinoncci number.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsFibonacci(this ulong a)
        {
            return ((5*a*a + 4).IsPerfectSquare() || (5*a*a - 4).IsPerfectSquare());

        }

        /// <summary>
        /// Returns the greatest common denominator.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static ulong GreatestCommonDenominator(this ulong value1, ulong value2)
        {
            /* Jeff Reddy
             * http://extensionmethod.net/csharp/int32/lcm
             */

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
        /// Returns the least commong multiplier.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static ulong LeastCommonMultiplier(this ulong[] values)
        {
            /* Jeff Reddy
            * http://extensionmethod.net/csharp/int32/lcm
            */
            var retval = values[0];
            for (var i = 1; i < values.Length; i++)
            {
                retval = GreatestCommonDenominator(retval, values[i]);
            }
            return retval;
        }

        /// <summary>
        /// This will return all of the digits of a long number to an array.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static long[] ToArray(this long number)
        {
            /*waldyrfelix
             * http://extensionmethod.net/csharp/int32/toarray
             */

            if (number == 0)
            {
                return new long[0];
            }
            else if (number < 0)
            {
                number = -1*number;
            }

            var list = new List<long>();
            while (number > 0)
            {
                list.Add(number%10);
                number = number/10;
            }
            list.Reverse();

            return list.ToArray();
        }

        /// <summary>
        /// Get the length of a number, if were represented as a string.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Length(this long number)
        {
            var s = number.ToString(CultureInfo.InvariantCulture);
            return s.Length;
        }

        /// <summary>
        /// Return true if the number is even.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsEven(this long number)
        {
            return (number%2 == 0);
        }

        public static bool IsOdd(this long number)
        {
            return (number%2 == 1);
        }
    



}
}
