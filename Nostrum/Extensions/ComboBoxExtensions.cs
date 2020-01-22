using System.Windows;

namespace Nostrum.Extensions
{
    public class ComboBoxExtensions
    {
        // DropDownBorderStyle
        public static readonly DependencyProperty DropDownBorderStyleProperty = DependencyProperty.RegisterAttached("DropDownBorderStyle",
            typeof(Style),
            typeof(ComboBoxExtensions),
            new PropertyMetadata(null));
        public static Style GetDropDownBorderStyle(DependencyObject obj) => (Style)obj.GetValue(DropDownBorderStyleProperty);
        public static void SetDropDownBorderStyle(DependencyObject obj, Style value) => obj.SetValue(DropDownBorderStyleProperty, value);
    }
}