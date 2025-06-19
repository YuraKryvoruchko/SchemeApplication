using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SchemeApplication.Infrastructure.Converters
{
    internal class ResourceKeyToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string key)
            {
                return Application.Current.TryFindResource(key) ?? $"[{key}]";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
