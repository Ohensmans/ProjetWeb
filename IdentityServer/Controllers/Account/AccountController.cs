using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.ViewModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelesApi.POC;

namespace IdentityServer.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly UserManager<Utilisateur> _userManager;
        private readonly SignInManager<Utilisateur> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

        public AccountController(
            UserManager<Utilisateur> userManager,
            SignInManager<Utilisateur> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
        }


        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.ReturnUrl = returnUrl;
            rvm.lGenres = new GenreUtilisateur().genres;

            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            model.lGenres = new GenreUtilisateur().genres;

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(model.User, model.Password);

                if (result.Succeeded)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(model.User, model.Password, false, false);
                    return Redirect(model.ReturnUrl);
                }

                return View(model);
            }
            else
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginInputViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputViewModel vm, string button)
        {
            // check if we are in the context of an authorization request
            var context = await _interaction.GetAuthorizationContextAsync(vm.ReturnUrl);

            if (button.Equals("register"))
            {
                return RedirectToAction("Register","Account",vm.ReturnUrl);
            }
            else if (button.Equals("login"))
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, vm.RememberLogin, false);

                    if (result.Succeeded)
                    {
                        //voir pour event si nécessaire

                        return Redirect(vm.ReturnUrl);
                    }
                    else
                        ModelState.AddModelError(string.Empty, "User ou mot de passe invalide");                   
                }
                return View(BuildLoginInputModel(vm));
            }
            else
            {
                if (context != null)
                {
                    // if the user cancels, send a result back into IdentityServer as if they 
                    // denied the consent (even if this client does not require consent).
                    // this will send back an access denied OIDC error response to the client.
                    await _interaction.GrantConsentAsync(context, ConsentResponse.Denied);

                    return Redirect(vm.ReturnUrl);
                }
                else
                    return Redirect("~/");
            }
        }

        private LoginInputViewModel BuildLoginInputModel(LoginInputViewModel model)
        {
            LoginInputViewModel vm = new LoginInputViewModel();
            vm.ReturnUrl = model.ReturnUrl;
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }
    }
}