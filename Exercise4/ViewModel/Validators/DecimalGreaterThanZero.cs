using System.Globalization;
using System.Windows.Controls;

namespace ViewModel.Validators
{
    public class DecimalGreaterThanZero : ValidationRule
    {
        public string Error { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse(value.ToString(), out decimal i))
            {
                if (i > 0)
                    return new ValidationResult(true, null);
                else
                {
                    Error = "Value has to be greater than 0";
                    return new ValidationResult(false, Error);
                }
            }
            Error = "Value has to be a correct number";
            return new ValidationResult(false, Error);
        }
    }
}
