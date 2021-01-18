using System.Collections.Generic;

namespace OnTrial
{
    public static class GenericExtensions
    {
        public static List<T> ToEntityList<T>(this T pEntity) where T : class
        {
            return new List<T> { pEntity };
        }
    }
}