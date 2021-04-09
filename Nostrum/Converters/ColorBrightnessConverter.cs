using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Nostrum.Converters
{
    /// <summary>
    /// Returns a brighter shade of the input color using <see cref="Color.Multiply"/> and preserving the alpha value.
    /// </summary>
    public class ColorBrightnessConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Gets or sets the multiplication factor.
        /// </summary>
        public float Factor { get; set; } = 1;

        /// <inheritdoc />
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Color c) return null;
            var originalAlpha = c.A;
            var ret = Color.Multiply(c, Factor);
            ret.A = originalAlpha;

            return ret;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}