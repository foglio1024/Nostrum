using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nostrum.WPF.Extensions
{
    public class TextBoxExtensions
    {
        // FocusBorderBrush
        public static readonly DependencyProperty FocusBorderBrushProperty = DependencyProperty.RegisterAttached(
            "FocusBorderBrush",
            typeof(Brush),
            typeof(TextBoxExtensions),
            new PropertyMetadata(Brushes.DodgerBlue));

        public static Brush GetFocusBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusBorderBrushProperty);
        }

        public static void SetFocusBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusBorderBrushProperty, value);
        }

        // AutoScrollEnabled
        public static readonly DependencyProperty AutoScrollEnabledProperty = DependencyProperty.RegisterAttached(
            "AutoScrollEnabled",
            typeof(bool),
            typeof(TextBoxExtensions),
            new UIPropertyMetadata(false, OnAutoScrollEnabledChanged));

        public static bool GetAutoScrollEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollEnabledProperty);
        }

        public static void SetAutoScrollEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollEnabledProperty, value);
        }

        private static void OnAutoScrollEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is TextBox tb)) return;
            var enabled = e.NewValue is bool b && b;

            if (enabled)
            {
                tb.TextChanged += OnTextChanged;
            }
            else
            {
                tb.TextChanged -= OnTextChanged;
            }
        }

        private static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox tb)) return;
            tb.ScrollToEnd();
        }

        // CornerRadius
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
            "CornerRadius",
            typeof(CornerRadius),
            typeof(TextBoxExtensions),
            new PropertyMetadata(new CornerRadius(0)));

        public static CornerRadius GetCornerRadius(TextBox tb)
        {
            return (CornerRadius)tb.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(TextBox tb, CornerRadius value)
        {
            tb.SetValue(CornerRadiusProperty, value);
        }

        // FocusedCornerRadius
        public static readonly DependencyProperty FocusedCornerRadiusProperty = DependencyProperty.RegisterAttached(
            "FocusedCornerRadius",
            typeof(CornerRadius),
            typeof(TextBoxExtensions),
            new PropertyMetadata(new CornerRadius(0)));

        public static CornerRadius GetFocusedCornerRadius(TextBox tb)
        {
            return (CornerRadius)tb.GetValue(FocusedCornerRadiusProperty);
        }

        public static void SetFocusedCornerRadius(TextBox tb, CornerRadius value)
        {
            tb.SetValue(FocusedCornerRadiusProperty, value);
        }

        // HintText
        public static readonly DependencyProperty HintTextProperty = DependencyProperty.RegisterAttached(
            "HintText",
            typeof(string),
            typeof(TextBoxExtensions),
            new PropertyMetadata(""));

        public static string GetHintText(TextBox obj)
        {
            return (string)obj.GetValue(HintTextProperty);
        }

        public static void SetHintText(TextBox obj, string value)
        {
            obj.SetValue(HintTextProperty, value);
        }
    }
}