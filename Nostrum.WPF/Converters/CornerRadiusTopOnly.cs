using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    public class CornerRadiusTopOnly : MarkupExtension, IValueConverter
    {
        static CornerRadiusTopOnly? _instance;

        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not CornerRadius cr) return null;
            return new CornerRadius(cr.TopLeft, cr.TopRight, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_instance == null) _instance = new();
            return _instance;
        }
    }
}