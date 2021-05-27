using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Inverts a boolean value. Returns false if the provided value is not a <see cref="bool"/>.
    /// </summary>
    public class BooleanInverter : IValueConverter
    {
        ///<inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool b && b);
        }

        ///<inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}