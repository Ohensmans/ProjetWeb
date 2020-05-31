using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonConverter(typeof(JsonTimeSpanConverter))]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan HeureOuverture { get; set; }

        [JsonConverter(typeof(JsonTimeSpanConverter))]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan HeureFermeture { get; set; }

        public Guid EtablissementId { get; set; }

        public Etablissement Etablissement { get; set; }

    }
}
