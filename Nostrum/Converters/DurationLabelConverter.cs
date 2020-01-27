using System;
using System.Globalization;
using System.Windows.Data;

namespace Nostrum.Converters
{
    public class DurationLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = 0U;
            if (value != null) val = System.Convert.ToUInt32(value);
            var seconds = val / 1000;
            var minutes = seconds / 60;
            var hours = minutes / 60;
            var days = hours / 24;

            if (minutes < 3) return seconds.ToString();
            if (hours < 3) return $"{minutes}m";
            if (days < 1) return $"{hours}h";
            return $"{days}d";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class MillisecondsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = 0L;
            var ret = "";

            if (value != null) val = System.Convert.ToInt64(value);
            var seconds = val / 1000;
            var minutes = seconds / 60;
            var hours = minutes / 60;
            var days = hours / 24;

            if (minutes < 60) return $"{minutes}m";
            if (hours < 24) return $"{hours}h {minutes - (hours*60)}m";
            return $"{days}d {hours - (days * 24)}h {minutes - (hours * 60)}m";
            //if (seconds < 60) return $"{seconds}s";
            //if (minutes < 60) return $"{minutes}m {seconds - (minutes * 60)}s";
            //if (hours < 24) return $"{hours}h {minutes - (hours * 60)}m {seconds - (minutes * 60)}s";
            //return $"{days}d {hours - (days * 24)}h {minutes - (hours * 60)}m {seconds - (minutes * 60)}s";



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
