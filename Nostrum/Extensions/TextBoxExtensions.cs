using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nostrum.Extensions
{
    public class TextBoxExtensions
    {
        // FocusBorderBrush
        public static readonly DependencyProperty FocusBorderBrushProperty = DependencyProperty.RegisterAttached("FocusBorderBrush",
            typeof(Brush),
            typeof(TextBoxExtensions),
            new PropertyMetadata(Brushes.DodgerBlue));
        public static Brush GetFocusBorderBrush(DependencyObject obj)
        {
            return (Brush) obj.GetValue(FocusBorderBrushProperty);
        }

        public static void SetFocusBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusBorderBrushProperty, value);
        }

        public static readonly DependencyProperty AutoScrollEnabledProperty = DependencyProperty.RegisterAttached(
            "AutoScrollEnabled",
            typeof(bool),
            typeof(TextBoxExtensions),
            new UIPropertyMetadata(false, OnAutoScrollEnabledChanged));

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

        public static bool GetAutoScrollEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollEnabledProperty);
        }

        public static void SetAutoScrollEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollEnabledProperty, value);
        }
    }
}