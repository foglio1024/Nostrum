using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FoglioUtils.Converters
{
    public class ColorToTransparent : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double.TryParse(parameter?.ToString(), NumberStyles.Any,CultureInfo.InvariantCulture, out var opacity);
            var alpha = System.Convert.ToByte(255 * opacity);
            switch (value)
            {
                case SolidColorBrush b:
                {
                    return new SolidColorBrush(Color.FromArgb(alpha, b.Color.R, b.Color.G, b.Color.B));
                }
                case Color c:
                {
                    return Color.FromArgb(alpha, c.R, c.G, c.B);
                }
                default: return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
