using System;
using System.Globalization;
using System.Windows.Data;
using Nostrum.Extensions;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Returns an <see cref="Enum"/> description.
    /// </summary>
    public class EnumDescriptionConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Enum e ? e.GetDescription() : "";
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
