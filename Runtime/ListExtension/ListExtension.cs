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

            List<T> sortedList = new List<T>(list);
            sortedList.Sort((x, y) => keySelector(x).CompareTo(keySelector(y)));

            list.Sort((x, y) => keySelector(x).CompareTo(keySelector(y)));
            return sortedList;
        }
    }
}