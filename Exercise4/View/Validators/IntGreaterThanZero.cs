using System.Globalization;
using System.Windows.Controls;

namespace View.Validators
{
    public class IntGreaterThanZero : ValidationRule
    {
        public string Error { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int i))
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
