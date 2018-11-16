using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Course_kepeer_1
{
    public class QuValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (value.ToString().Length < 1)
                    return new ValidationResult(false, "Question cannot be less than 1 characters long.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
