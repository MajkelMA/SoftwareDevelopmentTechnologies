using System;
using System.Globalization;
using System.Windows.Controls;

namespace ViewModel.Validators
{
    public class ShortGreaterThanZero : ValidationRule
    {
        public string Error { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Int16.TryParse(value.ToString(), out Int16 i))
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
