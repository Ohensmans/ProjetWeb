
using Modeles.POC;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Modeles.Validation
{
    public class GenreAttributeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            List<string> genres = new GenreUtilisateur().genres;

            if (genres.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }


            return new ValidationResult(GetStringErreur(genres));
        }

        private string GetStringErreur(List<string> genres)
        {
            string errorMessage = "Il n'y a que ";
            errorMessage += genres.Count;
            errorMessage += " valeurs possibles pour ce champ :";
            foreach (string genre in genres)
            {
                errorMessage += " "+genre;
            }
            return errorMessage;
        }
    }
}
