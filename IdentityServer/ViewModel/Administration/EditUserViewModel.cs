using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModel.Administration
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public Utilisateur User { get; set; }

        public List<string> Claims { get; set; }

        public List<string> Roles { get; set; }

        public string ReturnUrl { get; set; }

        public List<string> lGenres { get; set; }

    }
}
