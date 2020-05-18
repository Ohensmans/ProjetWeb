using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Quickstart.Account
{
    public class RegisterViewModel
    {
        public Utilisateur User { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public List<string> lGenres;

        public string ReturnUrl { get; set; }
    }
}
