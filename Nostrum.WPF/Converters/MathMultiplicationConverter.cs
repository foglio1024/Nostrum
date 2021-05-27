using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Multiplies the given value by the given parameters. Both values are treated as <see cref="double"/>.
    /// </summary>
    public class MathMultiplicationConverter : IValueConverter
    {
        /// <inheritdoc />
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var val = (double?)value;
            var fac = 1D;
            if (parameter != null)
            {
#if NETCOREAPP
                fac = double.Parse(parameter.ToString() ?? "1", CultureInfo.InvariantCulture);
#elif NETFRAMEWORK
                fac = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);
#endif
            }
            return val * fac;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}