using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.Converters
{
    /// <summary>
    /// Converts a duration expressed in milliseconds to the "[XXd] [XXh] XXm" format.
    /// </summary>
    [Obsolete("Use DurationToStringConverter instead")]
    public class MillisecondsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ms = 0L;

            if (value != null) ms = System.Convert.ToInt64(value);

            var ts = TimeSpan.FromMilliseconds(ms);

            var minutes = Math.Floor(ts.TotalMinutes);
            var hours = Math.Floor(ts.TotalHours);
            var days = Math.Floor(ts.TotalDays);

            if (minutes < 60) return $"{minutes}m";
            if (hours < 24) return $"{hours}h {minutes - (hours * 60)}m";
            return $"{days}d {hours - (days * 24)}h {minutes - (hours * 60)}m";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}