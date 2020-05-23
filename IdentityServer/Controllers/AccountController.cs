using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using IdentityServer.ViewModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelesApi.POC;

namespace IdentityServer.Controllers
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
        public IActionResult Register(string ReturnUrl)
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.ReturnUrl = ReturnUrl;
            rvm.lGenres = new GenreUtilisateur().genres;

            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string button)
        {
            model.lGenres = new GenreUtilisateur().genres;

            if (button.Equals("register"))
            {
                if (ModelState.IsValid)
                {
                    var result = await _userManager.CreateAsync(model.User, model.Password);

                    if (result.Succeeded)
                    {
                        var signInResult = await _signInManager.PasswordSignInAsync(model.User, model.Password, false, false);
                        return Redirect(model.ReturnUrl);
                    }
                }
                return View(model);
            }
            else
            {
                return Redirect(model.ReturnUrl);
            }
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
                return RedirectToAction("Register","Account",new { returnUrl = vm.ReturnUrl });
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


        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(logoutId);
            var PostLogoutRedirectUri = logout?.PostLogoutRedirectUri;

            if (User?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await _signInManager.SignOutAsync();

                // raise the logout event
                await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
            }

            return Redirect(PostLogoutRedirectUri);
        }

        [HttpGet]
        public async Task<IActionResult> Modifier(string ReturnUrl)
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                ModifierViewModel vm = new ModifierViewModel();
                vm.ReturnUrl = ReturnUrl;
                vm.lGenres = new GenreUtilisateur().genres;
                var userId = User.GetSubjectId();

                Utilisateur user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    vm.User = user;
                    return View(vm);
                }
            }
            ErrorViewModel evm = new ErrorViewModel("L'identité n'a pas pu être verifiée");
            return View("Error", evm);
        }

        [HttpPost]
        public async Task<IActionResult> Modifier(ModifierViewModel vm, string button)
        {
            vm.lGenres = new GenreUtilisateur().genres;

            if (button.Equals("register"))
            {
                if (ModelState.IsValid)
                {
                    var result = await _userManager.UpdateAsync(vm.User);

                    if (vm.Password != null && vm.ConfirmPassword != null && vm.NewPassword != null)
                    {
                        if (vm.Password != null)
                        {
                            var resultlogin = await _signInManager.CheckPasswordSignInAsync(vm.User, vm.Password, true);
                            if (!resultlogin.Succeeded)
                            {
                                ModelState.AddModelError(string.Empty, "Mot de passe invalide");
                                return View(vm);
                            }
                            var modifPass = await _userManager.ChangePasswordAsync(vm.User, vm.Password, vm.NewPassword);
                        }
                    }
                }
            }
            if (vm.ReturnUrl != null)
                return Redirect(vm.ReturnUrl);
            else
                return Redirect("~/");

        }

        [HttpGet]
        public async Task<IActionResult> MonCompte(string ReturnUrl)
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                MonCompteViewModel vm = new MonCompteViewModel();
                vm.ReturnUrl = ReturnUrl;
                var userId = User.GetSubjectId();

                Utilisateur user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    vm.User = user;
                    return View(vm);
                }
            }
            ErrorViewModel evm = new ErrorViewModel("Veuillez vous connecter pour accéder à votre compte");
            return View("Error", evm);
        }

        [HttpPost]
        public IActionResult MonCompte(MonCompteViewModel vm, string button)
        {
            if (ModelState.IsValid)
            {
                if (button.Equals("modifier"))
                {
                    return RedirectToAction("Modifier", new { ReturnUrl = vm.ReturnUrl });
                }
            }
            if (vm.ReturnUrl != null)
                return Redirect(vm.ReturnUrl);
            else
                return Redirect("~/");
        }


    }
}