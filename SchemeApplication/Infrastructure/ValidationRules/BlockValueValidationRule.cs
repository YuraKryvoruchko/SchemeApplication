using System.Globalization;
using System.Windows.Controls;

namespace SchemeApplication.Infrastructure.ValidationRules
{
    internal class BlockValueValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != "0" || value != "1")
            {
                return new ValidationResult(false, $"Block value must be \"1\" or \"0\"!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
