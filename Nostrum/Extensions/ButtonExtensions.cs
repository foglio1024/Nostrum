using Nostrum.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Nostrum.Extensions
{
    /// <summary>
    /// Extension methods and attached properties for the <see cref="Button"/> type.
    /// </summary>
    public class ButtonExtensions
    {
        // CornerRadius
        /// <summary>
        /// Specifies the <see cref="CornerRadius"/> of the <see cref="Button"/>.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius",
                                                                                                             typeof(CornerRadius),
                                                                                                             typeof(ButtonExtensions),
                                                                                                             new PropertyMetadata(new CornerRadius(0)));

        /// <summary>
        /// Gets the <see cref="CornerRadiusProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="CornerRadius"/></returns>
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        /// <summary>
        /// Sets the <see cref="CornerRadiusProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        // RippleBrush
        /// <summary>
        /// Specifies the <see cref="Brush"/> of the <see cref="Ripple"/> contained in the <see cref="Button"/>.
        /// </summary>
        public static readonly DependencyProperty RippleBrushProperty = DependencyProperty.RegisterAttached("RippleBrush",
                                                                                                            typeof(Brush),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(Brushes.White));
        /// <summary>
        /// Gets the <see cref="RippleBrushProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleBrushProperty"/> value</returns>
        public static Brush GetRippleBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(RippleBrushProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleBrushProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(RippleBrushProperty, value);
        }

        // RippleDuration
        /// <summary>
        /// Specifies the duration of the <see cref="Ripple"/> animation.
        /// </summary>
        public static readonly DependencyProperty RippleDurationProperty = DependencyProperty.RegisterAttached("RippleDuration",
                                                                                                            typeof(int),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(650));

        /// <summary>
        /// Gets the <see cref="RippleDurationProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>
        public static int GetRippleDuration(DependencyObject obj)
        {
            return (int)obj.GetValue(RippleDurationProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleDurationProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleDuration(DependencyObject obj, int value)
        {
            obj.SetValue(RippleDurationProperty, value);
        }

        // RippleStaysVisible
        /// <summary>
        /// Specifies if the <see cref="Ripple"/> should remain expanded.
        /// </summary>
        public static readonly DependencyProperty RippleStaysVisibleProperty = DependencyProperty.RegisterAttached("RippleStaysVisible",
                                                                                                            typeof(bool),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(false));

        /// <summary>
        /// Gets the <see cref="RippleStaysVisibleProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>
        public static bool GetRippleStaysVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(RippleStaysVisibleProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleStaysVisibleProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleStaysVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(RippleStaysVisibleProperty, value);
        }

        // RippleReversed
        /// <summary>
        /// Specifies the direction of the <see cref="Ripple"/> animation.
        /// </summary>
        public static readonly DependencyProperty RippleReversedProperty = DependencyProperty.RegisterAttached("RippleReversed",
                                                                                                            typeof(bool),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(false));

        /// <summary>
        /// Gets the <see cref="RippleReversedProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>
        public static bool GetRippleReversed(DependencyObject obj)
        {
            return (bool)obj.GetValue(RippleReversedProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleReversedProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleReversed(DependencyObject obj, bool value)
        {
            obj.SetValue(RippleReversedProperty, value);
        }

        // RippleEnabled
        /// <summary>
        /// Enables or disables the <see cref="Ripple"/>.
        /// </summary>
        public static readonly DependencyProperty RippleEnabledProperty = DependencyProperty.RegisterAttached("RippleEnabled",
                                                                                                            typeof(bool),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(true));
        /// <summary>
        /// Gets the <see cref="RippleEnabledProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>

        public static bool GetRippleEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(RippleEnabledProperty);
        }
        /// <summary>
        /// Sets the <see cref="RippleEnabledProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>

        public static void SetRippleEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(RippleEnabledProperty, value);
        }

        // BorderEffect
        /// <summary>
        /// Specifies an <see cref="Effect"/> for the underlying <see cref="Border"/> of the <see cref="Button"/>.
        /// </summary>
        public static readonly DependencyProperty BorderEffectProperty = DependencyProperty.RegisterAttached("BorderEffect",
                                                                                                            typeof(Effect),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(null));
        /// <summary>
        /// Gets the <see cref="BorderEffectProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>

        public static Effect GetBorderEffect(DependencyObject obj)
        {
            return (Effect)obj.GetValue(BorderEffectProperty);
        }
        /// <summary>
        /// Sets the <see cref="BorderEffectProperty"/> dependency property value of the given <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>

        public static void SetBorderEffect(DependencyObject obj, Effect value)
        {
            obj.SetValue(BorderEffectProperty, value);
        }
    }
}