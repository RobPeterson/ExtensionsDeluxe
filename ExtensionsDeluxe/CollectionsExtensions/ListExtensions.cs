using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExtensions
{
    public static class ListExtensions
    {


            /// <summary>
            /// This will return the object with the minumum value in a given property.
            /// Fons Sonnemans
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
            /// This will return the object with the minumum value in a given property.
            /// Fons Sonnemans
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
            /// Returns a queue with all of the elements in the list enqueued.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="list"></param>
            /// <returns></returns>
            public static Queue<T> ToQueue<T>(this IEnumerable<T> list)
            {
                var queue = new Queue<T>();
                foreach (T item in list)
                    queue.Enqueue(item);
                return queue;

            }

            /// <summary>
            /// Returns the list an a different order.
            /// Wes Caldwell
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="list"></param>
            /// <returns></returns>
            public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
            {
                var r = new Random((int)DateTime.Now.Ticks);
                var shuffledList = list.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item);
                return shuffledList.ToList();
            }

            private static Random random = new Random();

            /// <summary>
            /// Return a random element from the list.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="sequence"></param>
            /// <returns></returns>
            public static T SelectRandom<T>(this IEnumerable<T> sequence)
            {
                if (sequence == null)
                {
                    throw new ArgumentNullException();
                }

                if (!sequence.Any())
                {
                    throw new ArgumentException("The sequence is empty.");
                }

                //optimization for ICollection<T>
                if (sequence is ICollection<T>)
                {
                    var col = (ICollection<T>)sequence;
                    return col.ElementAt(random.Next(col.Count));
                }

                var count = 1;
                T selected = default(T);

                foreach (T element in sequence)
                {
                    if (random.Next(count++) == 0)
                    {
                        //Select the current element with 1/count probability
                        selected = element;
                    }
                }

                return selected;
            }

            /// <summary>
            /// This will reverse the order of a list.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="items"></param>
            /// <returns></returns>
            public static IEnumerable<T> Reverse<T>(this IEnumerable<T> items)
            {
                var list = (IList<T>)items;

                if (list == null)
                    yield return default(T);

                for (var i = list.Count - 1; i >= 0; i--)
                {
                    yield return list[i];
                }
            }

            /// <summary>
            /// Async create of a System.Collections.Generic.List<T> from an 
            /// System.Collections.Generic.IQueryable<T>.
            /// </summary>
            /// <typeparam name="T">The type of the elements of source.</typeparam>
            /// <param name="list">The System.Collections.Generic.IEnumerable<T> 
            /// to create a System.Collections.Generic.List<T> from.</param>
            /// <returns> A System.Collections.Generic.List<T> that contains elements 
            /// from the input sequence.</returns>
            public static Task<List<T>> ToListAsync<T>(this IQueryable<T> list)
            {
                return Task.Run(() => list.ToList());
            }
        }
    }


