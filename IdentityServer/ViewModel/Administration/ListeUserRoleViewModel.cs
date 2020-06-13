using ModelesApi.POC;
using System.Collections.Generic;


namespace IdentityServer.ViewModel.Administration
{
    public class ListeUserRoleViewModel
    {
        public string returnUrl { get; set; }

        public IEnumerable<Utilisateur> lUser { get; set; }
    }
}
