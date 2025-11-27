using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp_DataBinding_EF.Validators
{
    class Emailvalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var email = (value ?? "").ToString().Trim();

            if (string.IsNullOrEmpty(email))
                return new ValidationResult(false, "Email обязателен");

            if (!email.Contains("@"))
                return new ValidationResult(false, "Email должен содержать @");

            return ValidationResult.ValidResult;
        }
    }
}
