using System;
using System.Collections.Generic;

namespace Utils
{
    public static class ListExtensions
    {
        public static T FindItem<T>(this List<T> list, Predicate<T> match)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (match == null) throw new ArgumentNullException(nameof(match));

            int counter = list.Count;
            for (int i = 0; i < counter; i++)
            {
                if (match(list[i]))
                {
                    return list[i];
                }
            }
            return default;
        }

        public static List<T> OrderByCondition<T, TKey>(this List<T> list, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            list.Sort((x, y) => keySelector(x).CompareTo(keySelector(y)));
            return list;
        }

        public static List<T> WhereCondition<T>(this List<T> list, Predicate<T> match)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (match == null) throw new ArgumentNullException(nameof(match));

            List<T> result = new List<T>();
            foreach (T item in list)
            {
                if (match(item))
                    result.Add(item);
            }

            return result;
        }

        public static List<TResult> SelectCondition<T, TResult>(this List<T> list, Func<T, TResult> selector)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            List<TResult> result = new List<TResult>();
            foreach (T item in list)
                result.Add(selector(item));

            return result;
        }
    }
}