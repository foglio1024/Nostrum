using System.Windows;
using System.Windows.Media;

namespace FoglioUtils.Extensions
{
    public class ButtonExtensions
    {
        // CornerRadius
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius",
                                                                                                             typeof(CornerRadius),
                                                                                                             typeof(ButtonExtensions),
                                                                                                             new PropertyMetadata(new CornerRadius(0)));
        public static CornerRadius GetCornerRadius(DependencyObject obj) => (CornerRadius)obj.GetValue(CornerRadiusProperty);
        public static void SetCornerRadius(DependencyObject obj, CornerRadius value) => obj.SetValue(CornerRadiusProperty, value);

        // RippleBrush
        public static readonly DependencyProperty RippleBrushProperty = DependencyProperty.RegisterAttached("RippleBrush",
                                                                                                            typeof(Brush),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(Brushes.White));
        public static Brush GetRippleBrush(DependencyObject obj) => (Brush)obj.GetValue(RippleBrushProperty);
        public static void SetRippleBrush(DependencyObject obj, Brush value) => obj.SetValue(RippleBrushProperty, value);

        // RippleDuration
        public static readonly DependencyProperty RippleDurationProperty = DependencyProperty.RegisterAttached("RippleDuration",
                                                                                                            typeof(int),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(650));
        public static int GetRippleDuration(DependencyObject obj) => (int)obj.GetValue(RippleDurationProperty);
        public static void SetRippleDuration(DependencyObject obj, int value) => obj.SetValue(RippleDurationProperty, value);

        // RippleStaysVisible
        public static readonly DependencyProperty RippleStaysVisibleProperty = DependencyProperty.RegisterAttached("RippleStaysVisible",
                                                                                                            typeof(bool),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(false));
        public static bool GetRippleStaysVisible(DependencyObject obj) => (bool)obj.GetValue(RippleStaysVisibleProperty);
        public static void SetRippleStaysVisible(DependencyObject obj, bool value) => obj.SetValue(RippleStaysVisibleProperty, value);

        // RippleReversed
        public static readonly DependencyProperty RippleReversedProperty = DependencyProperty.RegisterAttached("RippleReversed",
                                                                                                            typeof(bool),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(false));
        public static bool GetRippleReversed(DependencyObject obj) => (bool)obj.GetValue(RippleReversedProperty);
        public static void SetRippleReversed(DependencyObject obj, bool value) => obj.SetValue(RippleReversedProperty, value);

        // RippleEnabled
        public static readonly DependencyProperty RippleEnabledProperty = DependencyProperty.RegisterAttached("RippleEnabled",
                                                                                                            typeof(bool),
                                                                                                            typeof(ButtonExtensions),
                                                                                                            new PropertyMetadata(true));
        public static bool GetRippleEnabled(DependencyObject obj) => (bool)obj.GetValue(RippleEnabledProperty);
        public static void SetRippleEnabled(DependencyObject obj, bool value) => obj.SetValue(RippleEnabledProperty, value);

        

    }
}