using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Nostrum.WPF.Controls;

namespace Nostrum.WPF.Extensions
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
        /// Gets the <see cref="CornerRadiusProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="CornerRadius"/></returns>
        public static CornerRadius GetCornerRadius(Button obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        /// <summary>
        /// Sets the <see cref="CornerRadiusProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetCornerRadius(Button obj, CornerRadius value)
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
        /// Gets the <see cref="RippleBrushProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleBrushProperty"/> value</returns>
        public static Brush GetRippleBrush(Button obj)
        {
            return (Brush)obj.GetValue(RippleBrushProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleBrushProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleBrush(Button obj, Brush value)
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
        /// Gets the <see cref="RippleDurationProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>
        public static int GetRippleDuration(Button obj)
        {
            return (int)obj.GetValue(RippleDurationProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleDurationProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleDuration(Button obj, int value)
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
        /// Gets the <see cref="RippleStaysVisibleProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>
        public static bool GetRippleStaysVisible(Button obj)
        {
            return (bool)obj.GetValue(RippleStaysVisibleProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleStaysVisibleProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleStaysVisible(Button obj, bool value)
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
        /// Gets the <see cref="RippleReversedProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>
        public static bool GetRippleReversed(Button obj)
        {
            return (bool)obj.GetValue(RippleReversedProperty);
        }

        /// <summary>
        /// Sets the <see cref="RippleReversedProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetRippleReversed(Button obj, bool value)
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
        /// Gets the <see cref="RippleEnabledProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>

        public static bool GetRippleEnabled(Button obj)
        {
            return (bool)obj.GetValue(RippleEnabledProperty);
        }
        /// <summary>
        /// Sets the <see cref="RippleEnabledProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>

        public static void SetRippleEnabled(Button obj, bool value)
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
        /// Gets the <see cref="BorderEffectProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="RippleDurationProperty"/> value</returns>
        public static Effect GetBorderEffect(Button obj)
        {
            return (Effect)obj.GetValue(BorderEffectProperty);
        }

        ///<summary>
        /// Sets the <see cref="BorderEffectProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name = "value" > the new property value</param>
        public static void SetBorderEffect(Button obj, Effect value)
        {
            obj.SetValue(BorderEffectProperty, value);
        }

        // DimsOnDisabled
        /// <summary>
        /// Specifies if the content should be dimmed when the button is disabled.
        /// </summary>
        public static readonly DependencyProperty DimsOnDisabledProperty = DependencyProperty.RegisterAttached("DimsOnDisabled",
                                                                                                               typeof(bool),
                                                                                                               typeof(ButtonExtensions),
                                                                                                               new PropertyMetadata(true));
        /// <summary>
        /// Gets the <see cref="DimsOnDisabledProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="DimsOnDisabledProperty"/> value</returns>
        public static bool GetDimsOnDisabled(Button obj)
        {
            return (bool)obj.GetValue(DimsOnDisabledProperty);
        }

        /// <summary>
        /// Sets the <see cref="DimsOnDisabledProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetDimsOnDisabled(Button obj, bool value)
        {
            obj.SetValue(DimsOnDisabledProperty, value);
        }

        // HighlightBrush
        /// <summary>
        /// The brush displayed when hovering the button.
        /// </summary>
        public static readonly DependencyProperty HighlightBrushProperty = DependencyProperty.RegisterAttached("HighlightBrush",
                                                                                                               typeof(Brush),
                                                                                                               typeof(ButtonExtensions),
                                                                                                               new PropertyMetadata(new SolidColorBrush(Colors.White) { Opacity = .2 }));

        /// <summary>
        /// Gets the <see cref="HighlightBrushProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <returns>the <see cref="DimsOnDisabledProperty"/> value</returns>
        public static Brush GetHighlightBrush(Button obj)
        {
            return (Brush)obj.GetValue(HighlightBrushProperty);
        }

        /// <summary>
        /// Sets the <see cref="HighlightBrushProperty"/> dependency property value of the given <see cref="Button"/>.
        /// </summary>
        /// <param name="obj">the dependency object</param>
        /// <param name="value">the new property value</param>
        public static void SetHighlightBrush(Button obj, Brush value)
        {
            obj.SetValue(HighlightBrushProperty, value);
        }

    }
}