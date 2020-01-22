using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Nostrum.Converters
{
    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool bValue)) return Visibility.Collapsed;
            var invert = parameter != null && parameter.ToString().IndexOf("invert", StringComparison.InvariantCultureIgnoreCase) != -1;
            var hidden = parameter != null && parameter.ToString().IndexOf("hidden", StringComparison.InvariantCultureIgnoreCase) != -1;
            if (invert) bValue = !bValue;
            if (bValue) return Visibility.Visible;
            return hidden ? Visibility.Hidden : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}