using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelesApi.Validation
{

    public class ListePhotoEtablissementValidationRange : ValidationAttribute
    {
        private readonly int _max;

        public ListePhotoEtablissementValidationRange(int max)
        {
            _max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IList;
            if (list == null)
                return ValidationResult.Success;

            if (list.Count < _max)
                return ValidationResult.Success;

            return new ValidationResult(GetStringErreur());
        }

        private string GetStringErreur()
        {
            return "Il ne peut avoir que "+_max+" photos maximum";
        }
    }

}
