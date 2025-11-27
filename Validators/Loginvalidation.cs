using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp_DataBinding_EF.Validators
{
    class Loginvalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var login = (value ?? "").ToString().Trim();

            if (string.IsNullOrEmpty(login))
                return new ValidationResult(false, "Логин обязателен");

            if (login.Length < 5)
                return new ValidationResult(false, "Логин минимум 5 символов");

            return ValidationResult.ValidResult;
        }
    }
}

