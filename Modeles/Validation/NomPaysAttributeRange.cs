using ModelesApi.Context;
using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ModelesApi.Validation
{
    public class NomPaysAttributeRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                using (var ctx = new EtablissementContext())
                {

                    List<Pays> lPaysValide = ctx.Pays.ToList();


                    if (lPaysValide.Any(x => x.Nom == value.ToString()))
                    {
                        return ValidationResult.Success;
                    }


                    return new ValidationResult(GetStringErreur(value.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetStringErreur(string value)
        {
            return "Le pays "+value+" n'existe pas dans la DB";
        }
    }
}
