using System.Runtime.CompilerServices;

namespace Neu.ANT.Backend.Utilities
{
    public static class IsoDatetime
    {
        public static string ToISO8601(this DateTime datetime)
        {
            return datetime.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string NowISO8601()
        {
            return DateTime.UtcNow.ToISO8601();
        }

        public static DateTime ParseIDO8601(string str)
        {
            return DateTime.Parse(str);
        }
    }
}
