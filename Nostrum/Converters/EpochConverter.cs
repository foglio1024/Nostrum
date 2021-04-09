using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.Converters
{
    /// <summary>
    /// Converts a Unix time value to a <see cref="DateTime"/>.
    /// </summary>
    public class EpochConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long ux) return TimeUtils.FromUnixTime(ux).ToLocalTime();
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
