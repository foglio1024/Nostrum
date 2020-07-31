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
        public static Style GetDropDownBorderStyle(DependencyObject obj)
        {
            return (Style) obj.GetValue(DropDownBorderStyleProperty);
        }

        public static void SetDropDownBorderStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(DropDownBorderStyleProperty, value);
        }
    }

    public class CheckBoxExtensions
    {

        public static readonly DependencyProperty SizeProperty = DependencyProperty.RegisterAttached("Size", 
                                                                                                     typeof(double), 
                                                                                                     typeof(CheckBoxExtensions), 
                                                                                                     new PropertyMetadata(18D));
        public static double GetSize(DependencyObject obj)
        {
            return (double) obj.GetValue(SizeProperty);
        }

        public static void SetSize(DependencyObject obj, double value)
        {
            obj.SetValue(SizeProperty, value);
        }
    }
}