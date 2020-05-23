using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModel.Administration
{
    public class ListeUserRoleViewModel
    {
        public string returnUrl { get; set; }

        public IEnumerable<Utilisateur> lUser { get; set; }
    }
}
