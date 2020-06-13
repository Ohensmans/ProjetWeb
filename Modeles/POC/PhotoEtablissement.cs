using System;

namespace ModelesApi.POC
{
    public class PhotoEtablissement
    {
        public Guid Id { get; set; }

        public string NomFichier { get; set; }

        public Guid EtablissementId { get; set; }

        public Etablissement Etablissement { get; set; }
    }
}
