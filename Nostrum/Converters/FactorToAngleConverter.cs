using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.Converters
{
    public class FactorToAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = System.Convert.ToDouble(value);
            var mult = 1D;
            if (parameter != null && parameter.ToString() != "") mult = System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);

            return MathUtils.FactorToAngle(val, mult);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    
}
