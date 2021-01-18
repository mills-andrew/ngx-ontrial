using System;
using System.Collections.Generic;

namespace OnTrial
{
    public class DataCache
    {
        public Dictionary<string, object> Data { get; set; }

        public T Cache<T>(string pKey, Func<object> pFunc)
        {
            try
            {
                if (Data != null)
                {
                    if (!Data.TryGetValue(pKey, out object result))
                    {
                        result = pFunc();
                        Data.Add(pKey, result);
                    }
                    return result is T ? (T)result : (T)Convert.ChangeType(result, typeof(T));
                }
                else
                {
                    object result = pFunc();
                    return result is T ? (T)result : (T)Convert.ChangeType(result, typeof(T));
                }
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }

        public void ClearCache()
        {
            Data.Clear();
        }

        public void CreateCache()
        {
            Data = new Dictionary<string, object>();
        }

        public void DeleteCache()
        {
            Data = null;
        }

        public void SetCache(Dictionary<string, object> pCache)
        {
            Data = pCache;
        }
    }
}
