﻿using System;
using System.Threading.Tasks;
using IdentityServer.ViewModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IEventService _events;

        public AccountController(
            UserManager<Utilisateur> userManager,
            SignInManager<Utilisateur> signInManager,
            IIdentityServerInteractionService interaction,
            IEventService events)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _events = events;
        }


        [HttpGet]
        public IActionResult Register(string ReturnUrl)
        {
            try
            {
                RegisterViewModel rvm = new RegisterViewModel();
                rvm.ReturnUrl = ReturnUrl;
                rvm.lGenres = new GenreUtilisateur().genres;

                return View(rvm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }

        }


        public async Task<bool> PutInRole(Utilisateur user)
        {
            try
            {
                var roles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, roles);
                if (result.Succeeded)
                {

                    string role;

                    if (user.estProfessionel)
                    {
                        role = "Gestionnaire";
                    }
                    else
                    {
                        role = "Utilisateur";
                    }

                    result = await _userManager.AddToRoleAsync(user, role);

                    if (result.Succeeded)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string button)
        {
            try
            {
                model.lGenres = new GenreUtilisateur().genres;

                if (button.Equals("register"))
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _userManager.CreateAsync(model.User, model.Password);

                        if (result.Succeeded)
                        {
                            if (await PutInRole(model.User))
                            {

                                if (_signInManager.IsSignedIn(User) && User.IsInRole("Administrateur"))
                                {
                                    return RedirectToAction("ListeUser", "Administration", new { returnUrl = model.ReturnUrl });
                                }
                                var signInResult = await _signInManager.PasswordSignInAsync(model.User, model.Password, false, false);
                                return Redirect(model.ReturnUrl);
                            }
                        }
                    }
                    return View(model);
                }
                else
                {
                    return Redirect(model.ReturnUrl);
                }
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
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
            try
            {
                // check if we are in the context of an authorization request
                var context = await _interaction.GetAuthorizationContextAsync(vm.ReturnUrl);

                if (button.Equals("register"))
                {
                    return RedirectToAction("Register", "Account", new { returnUrl = vm.ReturnUrl });
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
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
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
            try
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
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Modifier(string ReturnUrl)
        {
            try
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
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Modifier(ModifierViewModel vm, string button)
        {
            try
            {
                vm.lGenres = new GenreUtilisateur().genres;

                if (button.Equals("register"))
                {
                    if (ModelState.IsValid)
                    {

                        var result = await _userManager.UpdateAsync(vm.User);

                        if (result.Succeeded)
                        {
                            if (await PutInRole(vm.User))
                            {
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
                                        if (modifPass.Succeeded)
                                        {
                                            if (_signInManager.IsSignedIn(User) && User.IsInRole("Administrateur"))
                                            {
                                                return RedirectToAction("ListeUser", "Administration", new { returnUrl = vm.ReturnUrl });
                                            }

                                            if (vm.ReturnUrl != null)
                                                return Redirect(vm.ReturnUrl);
                                            else
                                                return Redirect("~/");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (vm.ReturnUrl != null)
                    return Redirect(vm.ReturnUrl);
                else
                    return Redirect("~/");
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }

        }

        [HttpGet]
        public async Task<IActionResult> MonCompte(string ReturnUrl)
        {
            try
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
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public IActionResult MonCompte(MonCompteViewModel vm, string button)
        {
            try
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
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}