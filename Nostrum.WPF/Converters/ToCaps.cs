using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Makes the input string uppercase. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class ToCaps : MarkupExtension, IValueConverter
    {
        private static ToCaps? _instance;

        /// <inheritdoc/>
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString()?.ToUpperInvariant();
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new ToCaps();
        }
    }
}
