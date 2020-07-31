using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.Converters
{
    public class MathMultiplicationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
