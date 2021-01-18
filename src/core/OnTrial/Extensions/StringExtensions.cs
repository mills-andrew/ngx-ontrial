using System;
using System.Linq;
using System.Text;

namespace OnTrial
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static long ToLong(this string value)
        {
            return long.Parse(value);
        }

        public static float ToFloat(this string value)
        {
            return float.Parse(value);
        }

        public static double ToDouble(this string value)
        {
            return double.Parse(value);
        }

        public static Guid ToGuide(this string value)
        {
            return Guid.Parse(value);
        }

        public static TimeSpan ToTimeSpan(this string value)
        {
            return TimeSpan.Parse(value);
        }

        public static DateTime ToDateTime(this string value)
        {
            return DateTime.Parse(value);
        }

        public static bool IsNullOrWhiteSpace(this string pString)
        {
            return string.IsNullOrWhiteSpace(pString);
        }

        public static bool IsNullOrEmpty(this string pString)
        {
            return string.IsNullOrEmpty(pString);
        }

        public static string Clean(this string pString)
        {
            return pString.Replace("\\r\\n", string.Empty);
        }

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string Base64Encode(this string pText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(pText));
        }
    }
}
