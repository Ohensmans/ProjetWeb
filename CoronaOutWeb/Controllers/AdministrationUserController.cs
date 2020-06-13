using CoronaOutWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoronaOutWeb.Controllers
{
    public class AdministrationUserController : Controller
    {
        private string identityAdminUrl;
        public string returnHomecoronaOutWebParam;

        public AdministrationUserController(IOptions<BaseUrl> url)
        {
            this.identityAdminUrl = url.Value.IdentityAdmin;
            this.returnHomecoronaOutWebParam = "?ReturnUrl=" + url.Value.CoronaOutWeb;
        }

        public IActionResult Admin()
        {
            return Redirect(identityAdminUrl + returnHomecoronaOutWebParam);
        }
    }
}