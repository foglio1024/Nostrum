using Nostrum.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.Converters
{
    /// <summary>
    /// Returns an <see cref="Enum"/> description.
    /// </summary>
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Enum e ? e.GetDescription() : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
