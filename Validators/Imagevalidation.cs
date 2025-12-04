using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp_DataBinding_EF.Validators
{
    internal class Imagevalidation: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var ImageUrl = (value ?? "").ToString().Trim();

            if (!string.IsNullOrEmpty(ImageUrl))
                {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(ImageUrl, UriKind.Absolute);
                    bitmap.EndInit();
                }
                catch 
                {
                    return new ValidationResult(false, "Не удается преобразовать ссылку");
                }

                
                   
               
            }


            return ValidationResult.ValidResult;
        }
    }
}

