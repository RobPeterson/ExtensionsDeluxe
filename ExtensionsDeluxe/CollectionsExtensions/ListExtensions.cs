using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExtensions
{
    public static class ListExtensions
    {
        private static readonly Random random = new Random();


        /// <summary>
        ///     This will return the object with the minumum value in a given property.
        ///     Fons Sonnemans
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FindMin<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate)
            where TValue : IComparable<TValue>
        {
            var result = list.FirstOrDefault();
            if (result == null) return result;
            var bestMin = predicate(result);
            foreach (var item in list.Skip(1))
            {
                var v = predicate(item);
                if (v.CompareTo(bestMin) >= 0) continue;
                bestMin = v;
                result = item;
            }
            return result;
        }

        /// <summary>
        ///     This will return the object with the minumum value in a given property.
        ///     Fons Sonnemans
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FindMax<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate)
            where TValue : IComparable<TValue>
        {
            var result = list.FirstOrDefault();
            if (result == null) return result;
            var bestMax = predicate(result);
            foreach (var item in list.Skip(1))
            {
                var v = predicate(item);
                if (v.CompareTo(bestMax) <= 0) continue;
                bestMax = v;
                result = item;
            }
            return result;
        }


        /// <summary>
        ///     Returns a queue with all of the elements in the list enqueued.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Queue<T> ToQueue<T>(this IEnumerable<T> list)
        {
            var queue = new Queue<T>();
            foreach (var item in list)
                queue.Enqueue(item);
            return queue;
        }

        /// <summary>
        ///     Returns the list an a different order.
        ///     Wes Caldwell
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var r = new Random((int) DateTime.Now.Ticks);
            var shuffledList =
                list.Select(x => new {Number = r.Next(), Item = x}).OrderBy(x => x.Number).Select(x => x.Item);
            return shuffledList.ToList();
        }

        /// <summary>
        ///     Return a random element from the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static T SelectRandom<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException();

            if (!sequence.Any())
                throw new ArgumentException("The sequence is empty.");

            //optimization for ICollection<T>
            var collection = sequence as ICollection<T>;
            if (collection != null)
            {
                var col = collection;
                return col.ElementAt(random.Next(col.Count));
            }

            var count = 1;
            var selected = default(T);

            foreach (var element in sequence)
                if (random.Next(count++) == 0)
                    selected = element;

            return selected;
        }



        /// <summary>
        ///     Async create of a System.Collections.Generic.List
        ///     <T>
        ///         from an
        ///         System.Collections.Generic.IQueryable<T>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="list">
        ///     The System.Collections.Generic.IEnumerable
        ///     <T>
        ///         to create a System.Collections.Generic.List<T> from.
        /// </param>
        /// <returns>
        ///     A System.Collections.Generic.List
        ///     <T>
        ///         that contains elements
        ///         from the input sequence.
        /// </returns>
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> list)
        {
            return Task.Run(() => list.ToList());
        }

        /// <summary>
        ///     This will return a comma separated string for the given collection with unique values.
        ///     Each unique value will only be included in the string once.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="getValuesFunc">Function to select the calculate the string.</param>
        /// <param name="maxLength">Default to -1, If set greater than zero, it will limit the length to that many spaces.</param>
        /// <returns></returns>
        public static string ToUniqueCommaSeparatedString<T>(this IList<T> list, Func<T, string> getValuesFunc,
            int maxLength = -1)
        {
            if (maxLength == 0)
                throw new Exception("You can't pass zero to this function.  What would be the point?");
            var valueSet = new HashSet<string>();
            var valueSb = new StringBuilder();
            foreach (var a in list)
            {
                var value = getValuesFunc(a);
                if (valueSet.Contains(value)) // Don't do duplicates.
                    continue;
                valueSet.Add(value);
                valueSb.Append(value);
                valueSb.Append(",");
            }
            var valueStr = valueSb.ToString();
            if (valueStr.Length > 0) // pop off the last comma
                valueStr = valueStr.Substring(0, valueStr.Length - 1);
            if ((valueStr.Length > maxLength) && (maxLength >= 0))
                valueStr = valueStr.Substring(0, maxLength);
            return valueStr;
        }

        /// <summary>
        ///     This will return a comma separated string for the given collection.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="getValuesFunc">Function to select the calculate the string.</param>
        /// <param name="maxLength">Default to -1, If set greater than zero, it will limit the length to that many spaces.</param>
        /// <returns></returns>
        public static string ToCommaSeparatedString<T>(this IList<T> list, Func<T, string> getValuesFunc,
            int maxLength = -1)
        {
            if (maxLength == 0)
                throw new Exception("You can't pass zero to this function.  What would be the point?");
            var valueSb = new StringBuilder();
            foreach (var a in list)
            {
                var value = getValuesFunc(a);
                valueSb.Append(value);
                valueSb.Append(",");
            }
            var valueStr = valueSb.ToString();
            if (valueStr.Length > 0) // pop off the last comma
                valueStr = valueStr.Substring(0, valueStr.Length - 1);
            if ((valueStr.Length > maxLength) && (maxLength >= 0))
                valueStr = valueStr.Substring(0, maxLength);
            return valueStr;
        }
    }
}