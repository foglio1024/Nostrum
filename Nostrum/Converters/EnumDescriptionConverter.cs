using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using Nostrum.Extensions;

namespace Nostrum.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Enum e ? e.GetDescription() : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
