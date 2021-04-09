using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Nostrum.Converters
{
    /// <summary>
    /// Returns the index of a <see cref="ListBoxItem"/>.
    /// </summary>
    public class ListBoxItemIndexConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ListBoxItem lbi) return -1;
            var lv = (ListBox)ItemsControl.ItemsControlFromItemContainer(lbi);
            return lv.ItemContainerGenerator.IndexFromContainer(lbi) + 1;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}