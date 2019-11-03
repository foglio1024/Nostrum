using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FoglioUtils.Converters
{
    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool b)) return Visibility.Collapsed;
            var invert = parameter != null && parameter.ToString().IndexOf("invert", StringComparison.InvariantCultureIgnoreCase) != -1;
            var h = parameter != null && parameter.ToString().IndexOf("hidden", StringComparison.InvariantCultureIgnoreCase) != -1;
            if (invert) b = !b;
            if (b) return Visibility.Visible;
            return h ? Visibility.Hidden : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}