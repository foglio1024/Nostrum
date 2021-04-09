using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.Converters
{
    /// <summary>
    /// Converts a 0-1 value to a 0-360 angle. The result can be scaled by using the <see cref="Multiplier"/> property.
    /// </summary>
    public class FactorToAngleConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Gets or sets the multiplier used to scale the final value.
        /// </summary>
        public double Multiplier { get; set; } = 1;

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = System.Convert.ToDouble(value);

            return MathUtils.FactorToAngle(val, Multiplier);
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