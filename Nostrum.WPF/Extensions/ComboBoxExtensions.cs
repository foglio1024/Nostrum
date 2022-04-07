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
        /// Gets the <see cref="DropDownBorderStyleProperty"/> dependency property value of the given <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="CornerRadius"/></returns>
        public static Style GetDropDownBorderStyle(ComboBox obj)
        {
            return (Style)obj.GetValue(DropDownBorderStyleProperty);
        }

        /// <summary>
        /// Sets the <see cref="DropDownBorderStyleProperty"/> dependency property value of the given <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetDropDownBorderStyle(ComboBox obj, Style value)
        {
            obj.SetValue(DropDownBorderStyleProperty, value);
        }

        //IconTemplate
        /// <summary>
        /// Specifies the icon template of items.
        /// </summary>
        public static readonly DependencyProperty IconTemplateProperty = DependencyProperty.RegisterAttached("IconTemplate",
            typeof(ControlTemplate),
            typeof(ComboBoxExtensions));

        /// <summary>
        /// Gets the <see cref="IconTemplateProperty"/> dependency property value of the given <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="obj">the ComboBox</param>
        /// <returns>the <see cref="ControlTemplate"/></returns>
        public static ControlTemplate GetIconTemplate(ComboBox obj)
        {
            return (ControlTemplate)obj.GetValue(IconTemplateProperty);
        }

        /// <summary>
        /// Sets the <see cref="IconTemplateProperty"/> dependency property value of the given <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="obj">the ComboBox</param>
        /// <param name="value">the new property value</param>
        public static void SetIconTemplate(ComboBox obj, ControlTemplate value)
        {
            obj.SetValue(IconTemplateProperty, value);
        }
    }
}