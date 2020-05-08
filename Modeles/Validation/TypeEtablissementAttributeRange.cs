
using Modeles.POC;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Modeles.Validation
{
    class TypeEtablissementAttributeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> types = new TypeEtablissement().types;


            if (types.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }


            return new ValidationResult(GetStringErreur(types));
        }

        private string GetStringErreur(List<string> types)
        {
            string errorMessage = "Il n'y a que ";
            errorMessage += types.Count;
            errorMessage += " valeurs possibles pour ce champ :";
            foreach (string type in types)
            {
                errorMessage += " " + type;
            }
            return errorMessage;
        }
    }
}
