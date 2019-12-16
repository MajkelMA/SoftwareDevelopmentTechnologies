using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewModel.Validators
{
    public class StandardCostValidationRule : ValidationRule
    {
        public string Error { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse(value.ToString(), out decimal i))
            {
                if (i >= 0)
                    return new ValidationResult(true, null);
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
