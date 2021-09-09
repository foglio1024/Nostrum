using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Returns the index of a <see cref="ListBoxItem"/>. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class ListBoxItemIndexConverter : MarkupExtension, IValueConverter
    {
        private static ListBoxItemIndexConverter? _instance;

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

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new ListBoxItemIndexConverter();
        }
    }
}