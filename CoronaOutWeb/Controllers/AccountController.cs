using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CoronaOutWeb.ExternalApiCall.Users;
using CoronaOutWeb.Models;
using CoronaOutWeb.ViewModel;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using ModelesApi.POC;

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