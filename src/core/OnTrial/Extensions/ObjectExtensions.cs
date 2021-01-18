using System;
using System.Text.Json;

namespace OnTrial
{
    public static class ObjectExtensions
    {
        public static string ToString(this object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true,
            };

            return JsonSerializer.Serialize(obj, options);
        }

        public static bool ToBoolean(this object pObject)
        {
            return Convert.ToBoolean(pObject);
        }
    }
}
