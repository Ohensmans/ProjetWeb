using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModel
{
    public class MonCompteViewModel
    {
        public Utilisateur User { get; set; }

        public string ReturnUrl { get; set; }
    }
}
