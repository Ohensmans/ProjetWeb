using System.Collections.Generic;


namespace IdentityServer.ViewModel.Administration
{
    public class ListeRoleViewModel
    {
        public string returnUrl { get; set; }

        public IEnumerable<Microsoft.AspNetCore.Identity.IdentityRole> lRoles { get; set; }
    }
}
