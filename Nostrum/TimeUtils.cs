using System;

namespace Nostrum
{
    public static class TimeUtils
    {
        public static string FormatTime(long seconds)
        {
            if (Math.Abs(seconds) < 99) return $"{seconds}";
            if (Math.Abs(seconds) < 99 * 60) return $"{seconds / 60}m";
            if (Math.Abs(seconds) < 99 * 60 * 60) return $"{seconds / (60 * 60)}h";
            return $"{seconds / (60 * 60 * 24)}d";
        }
        public static string FormatTime(ulong seconds)
        {
            if (seconds < 99) return $"{seconds}";
            if (seconds < 99 * 60) return $"{seconds / 60}m";
            if (seconds < 99 * 60 * 60) return $"{seconds / (60 * 60)}h";
            return seconds / (60 * 60 * 24) + "d";
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

    }
}
