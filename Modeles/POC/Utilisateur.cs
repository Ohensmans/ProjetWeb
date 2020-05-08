using Microsoft.AspNetCore.Identity;
using System;


namespace ModelesApi.POC
{
    public class Utilisateur : IdentityUser
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Sexe { get; set; }

        public DateTime DateNaissance { get; set; }

        public bool estProfessionel { get; set; }
    }
}
