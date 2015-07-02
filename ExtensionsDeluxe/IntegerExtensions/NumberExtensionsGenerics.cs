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
            //Saeed Amiri http://stackoverflow.com/questions/4236673/sample-code-for-fast-primality-testing-in-c-sharp
            var n = UInt64.Parse(value.ToString());
            ulong[] ar;
            if ((ulong)n < 4759123141) ar = new ulong[] { 2, 7, 61 };
            else if (n < 341550071728321) ar = new ulong[] { 2, 3, 5, 7, 11, 13, 17 };
            else ar = new ulong[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
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
            return p % 2 == 0 ? Pow(Mul(a, a, mod), p / 2, mod) : Mul(Pow(a, p - 1, mod), a, mod);
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

        public static ulong LeastCommonMultiplier<T>(T[] values)
        {
            /* Jeff Reddy
            * http://extensionmethod.net/csharp/int32/lcm
            */
            var retval = UInt64.Parse(values[0].ToString());
            for (var i = 1; i < values.Length; i++)
            {
                retval = GreatestCommonDenominator((T)Convert.ChangeType(retval, typeof(T)), values[i]);
            }
            return retval;
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
