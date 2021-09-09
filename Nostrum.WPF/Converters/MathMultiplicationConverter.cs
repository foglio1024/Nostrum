using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Multiplies the given value by the given parameters. Both values are treated as <see cref="double"/>. Can be used as a <see cref="MarkupExtension"/>. 
    /// </summary>
    public class MathMultiplicationConverter : MarkupExtension, IValueConverter
    {
        private static MathMultiplicationConverter? _instance;

        /// <inheritdoc />
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var val = (double?)value;
            var fac = 1D;

            if (parameter?.ToString() != null)
            {
                fac = double.Parse(parameter.ToString()!, CultureInfo.InvariantCulture);
            }
            return val * fac;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new MathMultiplicationConverter();
        }
    }
}