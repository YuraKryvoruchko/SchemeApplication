using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SchemeApplication.Infrastructure.Converters
{
    internal class ResourceKeyToValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 1 || values[0] == null)
                return null;

            string key = values[0].ToString();
            var result = Application.Current.TryFindResource(key);

            return result ?? $"!{key}!";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
