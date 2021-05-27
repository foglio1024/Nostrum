using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Holds a list of <see cref="IValueConverter"/>s and feeds the result of each one into the next.
    /// </summary>
    public class ValueConverterGroup : List<IValueConverter>, IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}