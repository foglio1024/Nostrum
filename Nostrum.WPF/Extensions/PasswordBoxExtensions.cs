using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nostrum.WPF.Extensions
{
    public class PasswordBoxExtensions
    {
        // FocusBorderBrush
        public static readonly DependencyProperty FocusBorderBrushProperty = DependencyProperty.RegisterAttached(
            "FocusBorderBrush",
            typeof(Brush),
            typeof(PasswordBoxExtensions),
            new PropertyMetadata(Brushes.DodgerBlue));

        public static Brush GetFocusBorderBrush(PasswordBox obj)
        {
            return (Brush)obj.GetValue(FocusBorderBrushProperty);
        }

        public static void SetFocusBorderBrush(PasswordBox obj, Brush value)
        {
            obj.SetValue(FocusBorderBrushProperty, value);
        }

        // FocusBackgroundBrush
        public static readonly DependencyProperty FocusBackgroundBrushProperty = DependencyProperty.RegisterAttached(
            "FocusBackgroundBrush",
            typeof(Brush),
            typeof(PasswordBoxExtensions),
            new PropertyMetadata(Brushes.DodgerBlue));

        public static Brush GetFocusBackgroundBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusBackgroundBrushProperty);
        }

        public static void SetFocusBackgroundBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusBackgroundBrushProperty, value);
        }

        // CornerRadius
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
            "CornerRadius",
            typeof(CornerRadius),
            typeof(PasswordBoxExtensions),
            new PropertyMetadata(new CornerRadius(0)));

        public static CornerRadius GetCornerRadius(PasswordBox tb)
        {
            return (CornerRadius)tb.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(PasswordBox tb, CornerRadius value)
        {
            tb.SetValue(CornerRadiusProperty, value);
        }

        // FocusedCornerRadius
        public static readonly DependencyProperty FocusedCornerRadiusProperty = DependencyProperty.RegisterAttached(
            "FocusedCornerRadius",
            typeof(CornerRadius),
            typeof(PasswordBoxExtensions),
            new PropertyMetadata(new CornerRadius(0)));

        public static CornerRadius GetFocusedCornerRadius(PasswordBox tb)
        {
            return (CornerRadius)tb.GetValue(FocusedCornerRadiusProperty);
        }

        public static void SetFocusedCornerRadius(PasswordBox tb, CornerRadius value)
        {
            tb.SetValue(FocusedCornerRadiusProperty, value);
        }

        // HintText
        public static readonly DependencyProperty HintTextProperty = DependencyProperty.RegisterAttached(
            "HintText",
            typeof(string),
            typeof(PasswordBoxExtensions),
            new PropertyMetadata(""));

        public static string GetHintText(PasswordBox obj)
        {
            return (string)obj.GetValue(HintTextProperty);
        }

        public static void SetHintText(PasswordBox obj, string value)
        {
            obj.SetValue(HintTextProperty, value);
        }

        // HintTextBrush
        public static readonly DependencyProperty HintTextBrushProperty = DependencyProperty.RegisterAttached(
            "HintTextBrush",
            typeof(Brush),
            typeof(PasswordBoxExtensions),
            new PropertyMetadata(Brushes.DodgerBlue));

        public static Brush GetHintTextBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HintTextBrushProperty);
        }

        public static void SetHintTextBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HintTextBrushProperty, value);
        }

        public static readonly DependencyProperty PasswordLengthProperty =
    DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxExtensions),
    new UIPropertyMetadata(0));

        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        public static void SetPasswordLength(DependencyObject obj, int value)
        {
            obj.SetValue(PasswordLengthProperty, value);
        }




        public static bool GetPasswordLengthEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(PasswordLengthEnabledProperty);
        }

        public static void SetPasswordLengthEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(PasswordLengthEnabledProperty, value);
        }

        public static readonly DependencyProperty PasswordLengthEnabledProperty =
            DependencyProperty.RegisterAttached("PasswordLengthEnabled", typeof(bool), typeof(PasswordBoxExtensions), new UIPropertyMetadata(false, OnEnabled));



        private static void OnEnabled(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not PasswordBox tb) return;
            var enabled = e.NewValue is bool b && b;

            if (enabled)
            {
                tb.PasswordChanged += OnTextChanged;
            }
            else
            {
                tb.PasswordChanged -= OnTextChanged;
            }
        }

        private static void OnTextChanged(object sender, RoutedEventArgs e)
        {
            ((DependencyObject)sender).SetValue(PasswordLengthProperty, ((PasswordBox)sender).Password.Length);
        }

        // ErrorBorderBrush
        public static readonly DependencyProperty ErrorBorderBrushProperty = DependencyProperty.RegisterAttached(
            "ErrorBorderBrush",
            typeof(Brush),
            typeof(PasswordBoxExtensions),
            new PropertyMetadata(Brushes.DodgerBlue));

        public static Brush GetErrorBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ErrorBorderBrushProperty);
        }

        public static void SetErrorBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ErrorBorderBrushProperty, value);
        }


    }

}