using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ModelesApi.Validation
{
    public class JourAttributeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            List<string> lJours = new JoursSemaine().lJours;


            if (lJours.Any(x => x == value.ToString()))
            {
                return ValidationResult.Success;
            }


            return new ValidationResult(GetStringErreur(value.ToString()));
        }

        private string GetStringErreur(string value)
        {
            return "Le jour "+value+" n'existe pas";
        }
    }
}
