using System;
using System.Collections.Generic;
using OnTrial.Utilities;

namespace OnTrial
{
    public static class ArrayExtensions
    {
        public static T[] Append<T>(this T[] pSource, params T[] pItems)
        {
            var list = new List<T>(pSource);
            list.AddRange(pItems);
            return list.ToArray();
        }

        public static T[] Prepend<T>(this T[] pSource, params T[] pItems)
        {
            var list = new List<T>(pItems);
            list.AddRange(pSource);
            return list.ToArray();
        }

        public static T Random<T>(this T[] pSource)
        {
            if (pSource == null)
                throw new NullReferenceException();

            if (pSource.Length == 1)
                throw new ArgumentException("Argument cannot contain only one value.");

            return pSource[RandomUtils.Int(pSource.Length)];
        }
    }
}
