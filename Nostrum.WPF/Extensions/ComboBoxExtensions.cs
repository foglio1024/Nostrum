using System.Windows;
using System.Windows.Controls;

namespace Nostrum.WPF.Extensions
{
    /// <summary>
    /// Extension methods and attached properties for the <see cref="ComboBox"/> type.
    /// </summary>
    public class ComboBoxExtensions
    {
        // DropDownBorderStyle
        /// <summary>
        /// Specifies the style of the drop down <see cref="Border"/>.
        /// </summary>
        public static readonly DependencyProperty DropDownBorderStyleProperty = DependencyProperty.RegisterAttached("DropDownBorderStyle",
            typeof(Style),
            typeof(ComboBoxExtensions),
            new PropertyMetadata(null));

        /// <summary>
        /// Gets the <see cref="DropDownBorderStyleProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="CornerRadius"/></returns>
        public static Style GetDropDownBorderStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(DropDownBorderStyleProperty);
        }

        /// <summary>
        /// Sets the <see cref="DropDownBorderStyleProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetDropDownBorderStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(DropDownBorderStyleProperty, value);
        }
    }

    /// <summary>
    /// Extension methods and attached properties for the <see cref="CheckBox"/> type.
    /// </summary>
    public class CheckBoxExtensions
    {
        /// <summary>
        /// Specifies size <see cref="CheckBox"/>.
        /// </summary>
        public static readonly DependencyProperty SizeProperty = DependencyProperty.RegisterAttached("Size",
                                                                                                     typeof(double),
                                                                                                     typeof(CheckBoxExtensions),
                                                                                                     new PropertyMetadata(18D));

        /// <summary>
        /// Gets the <see cref="SizeProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="CornerRadius"/></returns>
        public static double GetSize(DependencyObject obj)
        {
            return (double)obj.GetValue(SizeProperty);
        }

        /// <summary>
        /// Sets the <see cref="SizeProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetSize(DependencyObject obj, double value)
        {
            obj.SetValue(SizeProperty, value);
        }
    }
}