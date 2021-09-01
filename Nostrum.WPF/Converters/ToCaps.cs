using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
	public class ToCaps : MarkupExtension, IValueConverter
	{
		private static ToCaps? _instance;
		public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
		{
			return value?.ToString()?.ToUpperInvariant();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (_instance == null) _instance = new();
			return _instance;
		}
	}
}
