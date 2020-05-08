using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelesApi.Validation
{
    public class HeureAttributeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            TimeSpan heureMin = new TimeSpan(0, 0, 0);
            TimeSpan heureMax = new TimeSpan(24, 0, 0);

            if ((TimeSpan)value>=heureMin && (TimeSpan)value<= heureMax)
            {
                return ValidationResult.Success;
            }


            return new ValidationResult(GetStringErreur(value.ToString()));
        }

        private string GetStringErreur(string value)
        {
            return "L'heure doit être comprise entre 0:00 et 24:00)";
        }
    }
}
