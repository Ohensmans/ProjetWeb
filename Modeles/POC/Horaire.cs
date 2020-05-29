using System;
using System.ComponentModel.DataAnnotations;

namespace ModelesApi.POC
{
    public class Horaire
    {
        public Horaire()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
       
        public string Jour { get; set; }
       
        public TimeSpan HeureOuverture { get; set; }
       
        public TimeSpan HeureFermeture { get; set; }

        public Etablissement Etablissement { get; set; }

        public bool IsDeleted { get; set; }
    }
}
