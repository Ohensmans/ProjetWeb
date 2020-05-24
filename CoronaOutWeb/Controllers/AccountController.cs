using CoronaOutWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace CoronaOutWeb.Controllers
{
    public class AccountController : Controller
    {
        public string returnHomecoronaOutWebParam;
        public string identityMonCompteUrl;
        public string identityRegisterUrl;

        public AccountController (IOptions<BaseUrl> url)
        {
            
            this.returnHomecoronaOutWebParam = "?ReturnUrl=" + url.Value.CoronaOutWeb;
            this.identityMonCompteUrl = url.Value.IdentityMonCompte;
            this.identityRegisterUrl = url.Value.IdentityRegister;
        }

        //pour actionner le log out
        [Authorize]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        //pour actionner le log in
        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult MonCompte()
        {
            return Redirect(identityMonCompteUrl+ returnHomecoronaOutWebParam);
        }

        public IActionResult Register()
        {
            return Redirect(identityRegisterUrl + returnHomecoronaOutWebParam);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }



    }
}