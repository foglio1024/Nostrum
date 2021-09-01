using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nostrum.WPF.Converters
{
	public class ObjectToType : MarkupExtension, IValueConverter
	{
		private static ObjectToType? _instance;
		public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value?.GetType();
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
