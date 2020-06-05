using System;
using System.Collections.Generic;


namespace ModelesApi.POC
{
    public class Etablissement
    {
        public Etablissement()
        {
            this.Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        public string Type { get; set; }

        public string Nom { get; set; }

        public string NumeroTva { get; set; }

        public string AdresseEmailPro { get; set; }

        public string ZoneTexteLibre { get; set; }

        public string Logo { get; set; }

        public string CodePostal { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }

        public string Rue { get; set; }

        public string NumeroBoite { get; set; }

        public string NumeroTelephone { get; set; }

        public string AdresseEmailEtablissement { get; set; }

        public string AdresseSiteWeb { get; set; }

        public string AdresseInstagram { get; set; }

        public string AdresseFacebook { get; set; }

        public string AdresseLinkedin { get; set; }

        public List<PhotoEtablissement> lPhotos { get; set; }

        public List<Horaire> lHoraire { get; set; }

        public Guid PublieParUserId { get; set; }

        public DateTime DatePublication { get; set; }

        public bool estValide { get; set; }

        public string NomUrl { get; set; }

    }
}
