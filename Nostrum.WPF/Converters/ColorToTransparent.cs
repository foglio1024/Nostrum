using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// <para>
    ///     Sets the Alpha channel of the input <see cref="Color"/> or <see cref="SolidColorBrush"/> to the given <see cref="Opacity"/>.
    /// </para>
    /// </summary>
    public class ColorToTransparent : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Gets or sets opacity value (0 to 1).
        /// </summary>
        public double Opacity { get; set; }

        /// <inheritdoc />
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var alpha = System.Convert.ToByte(255 * Opacity);
            return value switch
            {
                SolidColorBrush b => new SolidColorBrush(Color.FromArgb(alpha, b.Color.R, b.Color.G, b.Color.B)),
                Color c => Color.FromArgb(alpha, c.R, c.G, c.B),
                _ => null
            };
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