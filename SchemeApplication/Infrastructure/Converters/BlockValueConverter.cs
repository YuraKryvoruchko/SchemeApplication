using System.Globalization;
using System.Windows.Data;

namespace SchemeApplication.Infrastructure.Converters
{
    internal class BlockValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return b ? "1" : "0";
            }

            return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
            if (value is string s)
            {
                return s == "1";
            }

            return false;
        }
    }
}
