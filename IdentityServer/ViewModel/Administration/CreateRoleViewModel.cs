using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModel.Administration
{
    public class CreateRoleViewModel
    {
        public string RoleName { get; set; }
        public string ReturnUrl { get; set; }
    }
}
