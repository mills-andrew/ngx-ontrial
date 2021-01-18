using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnTrial
{
    public static class IEnumerableExtensions
    {
        public static string Flatten<T>(this IEnumerable<T> pList, string pSeparator)
        {
            if (pList == null)
                return null;

            StringBuilder sb = new StringBuilder();
            foreach (object item in pList)
            {
                if (sb.Length > 0)
                    sb.Append(pSeparator);

                sb.Append(item);
            }

            return sb.ToString();
        }

        public static int IndexOf<T>(this IEnumerable<T> pList, Predicate<T> pCondition)
        {
            int i = -1;
            return pList.Any(x =>
            {
                i++;
                return pCondition(x);
            }) ? i : -1;
        }
    }
}
