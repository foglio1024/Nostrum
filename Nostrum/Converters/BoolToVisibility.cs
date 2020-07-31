using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.Converters
{
    /// <summary>
    /// <para>
    ///     Converts a boolean value to <see cref="Visibility"/>. Can be used as a <see cref="MarkupExtension"/>.
    /// </para>
    /// <para>
    ///     It's possible to set <see cref="Invert"/> to invert the output and <see cref="Mode"/> to choose whether to use <see cref="Visibility.Collapsed"/> or <see cref="Visibility.Hidden"/> when the resulting value is false.
    /// </para>
    /// </summary>
    public class BoolToVisibility : MarkupExtension, IValueConverter
    {
        public bool Invert { get; set; }

        public Visibility Mode { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool b)) return Mode;
            if (Invert) b = !b;
            return b ? Visibility.Visible : Mode;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

    }
}