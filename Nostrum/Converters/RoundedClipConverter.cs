using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Nostrum.Converters
{
    /// <summary>
    /// Returns a rounded rectangle to use as clip geometry. Inputs values are width, height, radius.
    /// </summary>
    public class RoundedClipConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 3 || !(values[0] is double width) || !(values[1] is double height) || !(values[2] is CornerRadius radius))
                return DependencyProperty.UnsetValue;

            if (width < double.Epsilon || height < double.Epsilon)
                return Geometry.Empty;

            // Actually we need more complex geometry, when CornerRadius has different values.
            // But let me not to take this into account, and simplify example for a common value.
            var clip = new RectangleGeometry(new Rect(0, 0, width, height), radius.TopLeft, radius.TopLeft);
            clip.Freeze();
            return clip;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
