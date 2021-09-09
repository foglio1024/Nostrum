using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using Nostrum.Extensions;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Returns an <see cref="Enum"/> description. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class EnumDescriptionConverter : MarkupExtension, IValueConverter
    {
        private static EnumDescriptionConverter? _instance;
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Enum e ? e.GetDescription() : "";
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new EnumDescriptionConverter();
        }
    }
}
