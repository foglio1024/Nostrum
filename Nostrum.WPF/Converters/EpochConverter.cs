using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Converts a Unix time value to a <see cref="DateTime"/>. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class EpochConverter : MarkupExtension, IValueConverter
    {
        private static EpochConverter? _instance;
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

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new EpochConverter();
        }
    }
}
