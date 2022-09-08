using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Nostrum.WPF.Converters;

public class CenterToolTipConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Any(v => v == DependencyProperty.UnsetValue)) return double.NaN;

        var placementTargetDimension = (double)values[0];
        var toolTipDimension = (double)values[1];
        return (placementTargetDimension / 2.0) - (toolTipDimension / 2.0);
    }

    public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
