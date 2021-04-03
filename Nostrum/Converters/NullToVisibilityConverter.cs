using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.Converters
{
    /// <summary>
    /// <para>
    ///     Converts a reference type object value to <see cref="Visibility"/>. Can be used as a <see cref="MarkupExtension"/>.
    /// </para>
    /// <para>
    ///     It's possible to set <see cref="Invert"/> to invert the output and <see cref="Mode"/> to choose whether to use <see cref="Visibility.Collapsed"/> or <see cref="Visibility.Hidden"/> when the resulting value is false.
    /// </para>
    /// </summary>
    public class NullToVisibilityConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// If true, it inverts the conversion logic.
        /// </summary>
        public bool Invert { get; set; }
        /// <summary>
        /// Choose whether to use <see cref="Visibility.Collapsed"/> or <see cref="Visibility.Hidden"/>.
        /// </summary>
        public Visibility Mode { get; set; } = Visibility.Collapsed;

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value == null;
            if (Invert) v = !v;
            return v ? Mode : Visibility.Visible;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

    }

    /// <summary>
    /// Deprecated, use <see cref="NullToVisibilityConverter"/> instead.
    /// </summary>
    [Obsolete("Use NullToVisibilityConverter instead.")]
    public class NullToVisibleCollapsedConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
