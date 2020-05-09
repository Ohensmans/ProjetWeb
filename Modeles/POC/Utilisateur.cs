﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelesApi.POC
{
    public class Utilisateur : IdentityUser
    {
        
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Sexe { get; set; }

        [Key]
        public override string Email { get; set; }

        public override string PhoneNumber { get; set; }

        public DateTime DateNaissance { get; set; }

        public bool estProfessionel { get; set; }

        public string Roles { get; set; }
    }
}
