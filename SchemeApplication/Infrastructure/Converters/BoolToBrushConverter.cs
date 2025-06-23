using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SchemeApplication.Infrastructure.Converters
{
    /// <summary>
    /// Конвертує булеве значення у колір заливки
    /// </summary>
    internal class BoolToBrushConverter : IValueConverter
    {
        public Brush TrueBrush { get; set; } = Brushes.Blue;
        public Brush FalseBrush { get; set; } = Brushes.Transparent;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolValue && boolValue ? TrueBrush : FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
