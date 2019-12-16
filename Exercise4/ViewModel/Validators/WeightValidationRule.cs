using System.Globalization;
using System.Windows.Controls;

namespace ViewModel.Validators
{
    public class WeightValidationRule : ValidationRule
    {
        public string Error { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int i))
            {
                if(i >= 0)
                    return new  ValidationResult(true, null);
                else
                {
                    Error = "Weight has to be greater than 0";
                    return new ValidationResult(false, Error);
                }
            }
            Error = "Weight has to be a number";
            return new ValidationResult(false, Error);
        }
    }
}
