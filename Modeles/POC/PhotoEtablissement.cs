using System;
using System.Collections.Generic;
using System.Text;

namespace ModelesApi.POC
{
    public class PhotoEtablissement
    {
        public Guid Id { get; set; }

        public string NomFichier { get; set; }

        public Etablissement Etablissement { get; set; }
    }
}
