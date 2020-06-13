
using System.Collections.Generic;

namespace IdentityServer.ViewModel.Administration
{
    public class TableauBordViewModel
    {

        public List<string> UserNames { get; set; }

        public List<string> RoleNames { get; set; }

        public string ReturnUrl { get; set; }
    }
}
