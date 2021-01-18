using System.Collections.Generic;

namespace OnTrial
{
    public static class DictionaryExentions
    {
        /// <summary>
        /// Checks if the given dictionary is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="pData"></param>
        /// <returns>true if the dictionary is null or empty</returns>
        public static bool IsNullOrEmpty<T, F>(this Dictionary<T, F> pData)
        {
            return (pData == null || pData.Count == 0);
        }

        /// <summary>
        /// Will set the value of the key if it exists. If not, then it will add the key to the dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="pData"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        public static void Set<T, F>(this Dictionary<T, F> pData, T pKey, F pValue)
        {
            if (pData.ContainsKey(pKey))
                pData[pKey] = pValue;
            else
                pData.Add(pKey, pValue);
        }
    }
}
