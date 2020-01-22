using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Nostrum.Converters
{
    public class ColorToTransparentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var col = Color.FromArgb(0,0,0,0);
            switch (value)
            {
                case Color c:
                    col = Color.FromArgb(0, c.R, c.G, c.B);
                    break;
                case SolidColorBrush br:
                    col = Color.FromArgb(0, br.Color.R, br.Color.G, br.Color.B);
                    break;
            }

            if(targetType == typeof(SolidColorBrush)) return new SolidColorBrush(col);
            return col;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
