using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ModelesApi.POC
{
    public class Etablissement
    {
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

        public ICollection<PhotoEtablissement> lPhotos { get; set; }

        public ICollection<Horaire> lHoraire { get; set; }

        public string PublieParUserId { get; set; }

        public DateTime DatePublication { get; set; }

    }
}
