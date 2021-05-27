using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
    /// <summary>
    /// Returns value/Max. Returns 0 if the division fails. Can be used as a <see cref="MarkupExtension"/>.
    /// </summary>
    public class ValueToFactorConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Gets or sets the value by which dividing the input value.
        /// </summary>
        public double Max { get; set; }

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var val = System.Convert.ToDouble(value);
                if (Max != 0) return val / Max;
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
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
}