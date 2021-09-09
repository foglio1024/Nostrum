using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Inverts a boolean value. Returns false if the provided value is not a <see cref="bool"/>. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class BooleanInverter : MarkupExtension, IValueConverter
    {
        private static BooleanInverter? _instance;

        ///<inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool b && b);
        }

        ///<inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new BooleanInverter();
        }
    }
}