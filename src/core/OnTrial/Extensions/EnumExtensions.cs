using System;
using System.ComponentModel;

namespace OnTrial
{
    public static class EnumExtensions
    {
        public static string Name(this Enum en, object value)
        {
            return Enum.GetName(en.GetType(), value);
        }

        public static string Description(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }

        public static T ToEnum<T>(this string pValue) where T : struct
        {
            Enum.TryParse(pValue, true, out T resultInputType);
            return resultInputType;
        }
    }
}
