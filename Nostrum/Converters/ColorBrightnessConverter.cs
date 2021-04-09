using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Nostrum.Converters
{
    public class ColorBrightnessConverter : MarkupExtension, IValueConverter
    {
        public float Factor { get; set; } = 1;
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color c)) return null;
            var originalAlpha = c.A;
            var ret = Color.Multiply(c, Factor);
            ret.A = originalAlpha;

            return ret;
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