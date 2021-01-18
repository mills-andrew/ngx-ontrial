using System;

namespace OnTrial.Utilities
{
    public static class EnumUtilis
    {
        private static T GetEnumStringEnumType<T>(string pEnumStr) where T : struct
        {
            Enum.TryParse(pEnumStr, true, out T resultInputType);
            return resultInputType;
        }
    }
}
