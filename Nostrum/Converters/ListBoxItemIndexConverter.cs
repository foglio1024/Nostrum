using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Nostrum.Converters
{
    public class ListBoxItemIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ListBoxItem lbi)) return -1;
            var lv = (ListBox) ItemsControl.ItemsControlFromItemContainer(lbi);
            return lv.ItemContainerGenerator.IndexFromContainer(lbi) + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}