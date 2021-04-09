using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.Converters
{
    /// <summary>
    /// Converts a duration expressed in milliseconds to a formatted string. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class DurationToStringConverter : MarkupExtension, IValueConverter
    {
        public enum FormatMode
        {
            Single,
            Extended
        }

        public uint MaxMinutes { get; set; } = 3;
        public uint MaxHours { get; set; } = 3;
        public uint MaxDays { get; set; } = 1;
        public FormatMode Mode { get; set; } = FormatMode.Single;

        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            var ms = 0D;
            if (value != null) ms = System.Convert.ToDouble(value);

            var ts = TimeSpan.FromMilliseconds(ms);

            return Mode switch
            {
                FormatMode.Single => FormatSingle(ts),
                FormatMode.Extended => FormatExtended(ts),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private string FormatSingle(TimeSpan ts)
        {
            var seconds = Math.Floor(ts.TotalSeconds);
            var minutes = Math.Floor(ts.TotalMinutes);
            var hours = Math.Floor(ts.TotalHours);
            var days = Math.Floor(ts.TotalDays);

            if (minutes < MaxMinutes) return seconds.ToString(CultureInfo.InvariantCulture);
            if (hours < MaxHours) return $"{minutes}m";
            if (days < MaxDays) return $"{hours}h";
            return $"{days}d";

        }
        private string FormatExtended(TimeSpan ts)
        {
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

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
