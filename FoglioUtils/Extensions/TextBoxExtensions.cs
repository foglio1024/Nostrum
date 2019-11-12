using System.Windows;
using System.Windows.Media;

namespace FoglioUtils.Extensions
{
    public class TextBoxExtensions
    {
        // FocusBorderBrush
        public static readonly DependencyProperty FocusBorderBrushProperty = DependencyProperty.RegisterAttached("FocusBorderBrush",
            typeof(Brush),
            typeof(TextBoxExtensions),
            new PropertyMetadata(Brushes.DodgerBlue));
        public static Brush GetFocusBorderBrush(DependencyObject obj) => (Brush)obj.GetValue(FocusBorderBrushProperty);
        public static void SetFocusBorderBrush(DependencyObject obj, Brush value) => obj.SetValue(FocusBorderBrushProperty, value);

    }
}