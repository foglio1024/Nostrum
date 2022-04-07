using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nostrum.WPF.Extensions
{
    public class ControlExtensions
    {
        // LabelText
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.RegisterAttached("LabelText",
                typeof(string),
                typeof(ControlExtensions),
                new PropertyMetadata(""));

        public static string GetLabelText(Control o) => (string)o.GetValue(LabelTextProperty);

        public static void SetLabelText(Control o, string v) => o.SetValue(LabelTextProperty, v);

        // LabelForeground
        public static readonly DependencyProperty LabelForegroundProperty =
            DependencyProperty.RegisterAttached("LabelForeground",
                typeof(Brush),
                typeof(ControlExtensions),
                new PropertyMetadata(Brushes.White));

        public static Brush GetLabelForeground(Control o) => (Brush)o.GetValue(LabelForegroundProperty);

        public static void SetLabelForeground(Control o, Brush v) => o.SetValue(LabelForegroundProperty, v);

        // LabelFontSize
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.RegisterAttached("LabelFontSize",
                typeof(double),
                typeof(ControlExtensions),
                new PropertyMetadata(12D));

        public static double GetLabelFontSize(Control o) => (double)o.GetValue(LabelFontSizeProperty);

        public static void SetLabelFontSize(Control o, double v) => o.SetValue(LabelFontSizeProperty, v);

        // LabelFontFamily
        public static readonly DependencyProperty LabelFontFamilyProperty =
            DependencyProperty.RegisterAttached("LabelFontFamily",
                typeof(FontFamily),
                typeof(ControlExtensions));

        public static FontFamily GetLabelFontFamily(Control o) => (FontFamily)o.GetValue(LabelFontFamilyProperty);

        public static void SetLabelFontFamily(Control o, FontFamily v) => o.SetValue(LabelFontFamilyProperty, v);

        // LabelPosition
        public static readonly DependencyProperty LabelPositionProperty =
            DependencyProperty.RegisterAttached("LabelPosition",
                typeof(ControlLabelPosition),
                typeof(ControlExtensions),
                new PropertyMetadata(ControlLabelPosition.Top));

        public static ControlLabelPosition GetLabelPosition(Control o) => (ControlLabelPosition)o.GetValue(LabelPositionProperty);

        public static void SetLabelPosition(Control o, ControlLabelPosition v) => o.SetValue(LabelPositionProperty, v);

        // LabelMargin
        public static readonly DependencyProperty LabelMarginProperty =
            DependencyProperty.RegisterAttached("LabelMargin",
                typeof(Thickness),
                typeof(ControlExtensions),
                new PropertyMetadata(new Thickness(0)));

        public static Thickness GetLabelMargin(Control o) => (Thickness)o.GetValue(LabelMarginProperty);

        public static void SetLabelMargin(Control o, Thickness v) => o.SetValue(LabelMarginProperty, v);
    }


    public enum ControlLabelPosition
    {
        Top,
        Bottom
    }
}