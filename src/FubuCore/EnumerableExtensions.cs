using System.Diagnostics;
using System.Linq;

namespace System.Collections.Generic
{
    public static class GenericEnumerableExtensions
    {
        public static void Fill<T>(this IList<T> list, T value)
        {
            if (list.Contains(value)) return;
            list.Add(value);
        }

        public static string Join(this IEnumerable<string> strings, string separator)
        {
            string[] array = strings.ToArray();
            return string.Join(separator, array);
        }

        /// <summary>
        /// Performs an action with a counter for each item in a sequence and provides
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="values">The sequence to iterate</param>
        /// <param name="eachAction">The action to performa on each item</param>
        /// <returns></returns>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> values, Action<T, int> eachAction)
        {
            int index = 0;
            foreach (T item in values)
            {
                eachAction(item, index++);
            }

            return values;
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Each<T>(this IEnumerable<T> values, Action<T> eachAction)
        {
            foreach (T item in values)
            {
                eachAction(item);
            }

            return values;
        }

        [DebuggerStepThrough]
        public static IEnumerable Each(this IEnumerable values, Action<object> eachAction)
        {
            foreach (object item in values)
            {
                eachAction(item);
            }

            return values;
        }

        public static TReturn FirstValue<TItem, TReturn>(this IEnumerable<TItem> enumerable, Func<TItem, TReturn> func)
            where TReturn : class
        {
            foreach (TItem item in enumerable)
            {
                TReturn @object = func(item);
                if (@object != null) return @object;
            }

            return null;
        }

        public static IList<T> AddMany<T>(this IList<T> list, params T[] items)
        {
            return list.AddRange(items);
        }

        public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            items.Each(t => list.Add(t));
            return list;
        }
    }
}