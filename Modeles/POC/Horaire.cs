using ModelesApi.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelesApi.POC
{
    public class Horaire
    {
        [Key]
        public Guid Id { get; set; }

        [JourAttributeRange]
        public string Jour { get; set; }

        [HeureAttributeRange]
        public TimeSpan HeureOuverture { get; set; }

        [HeureAttributeRange]
        public TimeSpan HeureFermeture { get; set; }

        public Etablissement Etablissement { get; set; }
    }
}
