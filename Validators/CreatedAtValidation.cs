using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp_DataBinding_EF.Validators
{
    class CreatedAtValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value == DBNull.Value)
                return new ValidationResult(false, "Дата обязательна");

            DateTime date;

            if (value is DateTime dt)
                date = dt;
            else if (!DateTime.TryParse(value.ToString(), out date))
                return new ValidationResult(false, "Неверная дата");

            if (date < DateTime.Today)
                return new ValidationResult(false, "Дата не может быть раньше сегодняшней");

            return ValidationResult.ValidResult;
        }
    }
}

