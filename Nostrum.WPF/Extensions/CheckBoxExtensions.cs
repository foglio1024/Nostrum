using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nostrum.WPF.Extensions
{
    /// <summary>
    /// Extension methods and attached properties for the <see cref="CheckBox"/> type.
    /// </summary>
    public class CheckBoxExtensions
    {
        /// <summary>
        /// Specifies size of the <see cref="CheckBox"/>.
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
        public static double GetSize(CheckBox obj)
        {
            return (double)obj.GetValue(SizeProperty);
        }

        /// <summary>
        /// Sets the <see cref="SizeProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetSize(CheckBox obj, double value)
        {
            obj.SetValue(SizeProperty, value);
        }


        /// <summary>
        /// Specifies the color to use when the checkbox is unchecked.
        /// </summary>
        public static readonly DependencyProperty BaseBrushProperty = DependencyProperty.RegisterAttached("BaseBrush", 
                                                                                                          typeof(Brush), 
                                                                                                          typeof(CheckBoxExtensions), 
                                                                                                          new PropertyMetadata(Brushes.SlateGray));
        /// <summary>
        /// Gets the <see cref="BaseBrushProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="Brush"/></returns>
        public static Brush GetBaseBrush(CheckBox obj)
        {
            return (Brush)obj.GetValue(BaseBrushProperty);
        }
        /// <summary>
        /// Sets the <see cref="BaseBrushProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetBaseBrush(CheckBox obj, Brush value)
        {
            obj.SetValue(BaseBrushProperty, value);
        }



    }
}