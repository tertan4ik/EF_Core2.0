using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp_DataBinding_EF.Validators
{
    class Passwordvalidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var password = (value ?? "").ToString();

            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult(false, "Пароль обязателен");

            if (password.Length < 8)
                return new ValidationResult(false, "Минимум 8 символов");

            if (!password.Any(char.IsDigit))
                return new ValidationResult(false, "Добавьте цифру");

            if (!password.Any(char.IsUpper))
                return new ValidationResult(false, "Нужна заглавная буква");

            if (!password.Any(char.IsLower))
                return new ValidationResult(false, "Нужна строчная буква");

            string special = "!@#$%^&*()_+-={}[]|:;\"'<>,.?/";
            if (!password.Any(ch => special.Contains(ch)))
                return new ValidationResult(false, "Нужен спецсимвол");

            return ValidationResult.ValidResult;
        }
    }
}

