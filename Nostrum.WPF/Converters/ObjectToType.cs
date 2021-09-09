using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Returns the <see cref="Type"/> of the input value. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class ObjectToType : MarkupExtension, IValueConverter
    {
        private static ObjectToType? _instance;

        /// <inheritdoc />
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.GetType();
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new ObjectToType();
        }
    }
}
