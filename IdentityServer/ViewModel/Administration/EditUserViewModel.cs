using ModelesApi.POC;
using System.Collections.Generic;

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
