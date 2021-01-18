using System;
using System.Collections.Generic;
using System.Linq;

namespace OnTrial
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this List<T> pData)
        {
            return (pData == null || pData.Count == 0);
        }

        public static string MostCommon<T>(this List<T> pData)
        {
            return pData.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First().ToString();
        }

        public static int IndexOf<T>(this IList<T> source, Func<T, bool> predicate) where T : IEquatable<T>
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    return i;
            }

            throw new ArgumentException("List doesn't contain such an element");
        }
    }
}