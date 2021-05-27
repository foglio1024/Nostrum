using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Converts a duration expressed in milliseconds to a formatted string. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class DurationToStringConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// String format mode.
        /// </summary>
        public enum FormatMode
        {
            /// <summary>
            /// The resulting string will only contain one time component.
            /// </summary>
            Single,
            /// <summary>
            /// The resulting string will contain all the available time components from seconds to days.
            /// </summary>
            Extended
        }

        /// <summary>
        /// Gets or sets the threshold after which the value in seconds will be showed in minutes (<see cref="FormatMode.Single"/> only).
        /// </summary>
        public uint MaxMinutes { get; set; } = 3;
        /// <summary>
        /// Gets or sets the threshold after which the value in minutes will be showed in hours (<see cref="FormatMode.Single"/> only).
        /// </summary>
        public uint MaxHours { get; set; } = 3;
        /// <summary>
        /// Gets or sets the threshold after which the value in hours will be showed in days (<see cref="FormatMode.Single"/> only).
        /// </summary>
        public uint MaxDays { get; set; } = 1;
        /// <summary>
        /// Gets or sets the formatting mode.
        /// </summary>
        public FormatMode Mode { get; set; } = FormatMode.Single;

        /// <inheritdoc />
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

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
