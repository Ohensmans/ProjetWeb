﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Models;
using IdentityServer.ViewModel;
using IdentityServer.ViewModel.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModelesApi.POC;

namespace IdentityServer.Controllers
{
    [Authorize(Roles ="Administrateur")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Utilisateur> userManager;
        private string CoronaOutWebUrl;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<Utilisateur> userManager, IOptions<BaseUrl> url)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.CoronaOutWebUrl = url.Value.CoronaOutWeb;
        }

        [HttpGet]
        public IActionResult Index (string returnUrl)
        {
            try
            {
                if (returnUrl == null)
                    returnUrl = CoronaOutWebUrl;

                TableauBordViewModel vm = new TableauBordViewModel();

                vm.UserNames = userManager.Users.Select(u => u.UserName).ToList();
                vm.RoleNames = roleManager.Roles.Select(r => r.Name).ToList();
                vm.ReturnUrl = returnUrl;

                return View(vm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public IActionResult Index(TableauBordViewModel vm)
        {
            try
            {
                if (vm.ReturnUrl == null)
                    vm.ReturnUrl = CoronaOutWebUrl;

                return Redirect(vm.ReturnUrl);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId, string returnUrl)
        {
            try
            {
                ViewBag.userId = userId;
                ViewBag.returnUrl = returnUrl;

                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    ErrorViewModel vme = new ErrorViewModel("L'utilisateur avec l'id :" + userId + " n'a pas pu être trouvé");
                    return View("Error", vme);
                }

                var model = await getListUserRoles(user);

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<RolesUserViewModel> model, string userId, string returnUrl)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    ErrorViewModel vme = new ErrorViewModel("L'utilisateur avec l'id :" + userId + " n'a pas pu être trouvé");
                    return View("Error", vme);
                }

                var roles = await userManager.GetRolesAsync(user);
                var result = await userManager.RemoveFromRolesAsync(user, roles);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Ne peut pas retirer l'utilisaeur des rôles existants");
                    return View(model);
                }

                result = await userManager.AddToRolesAsync(user, model.Where(x => x.isSelected).Select(y => y.RoleName));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Ne peut pas ajouter l'utilisaeur à ces rôles");
                    return View(model);
                }

                return RedirectToAction("EditUser", new { userId, returnUrl });
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        public async Task<List<RolesUserViewModel>> getListUserRoles(Utilisateur user)
        {
            try
            {
                List<RolesUserViewModel> lRoles = new List<RolesUserViewModel>();

                foreach (var role in roleManager.Roles)
                {
                    var rolesUserViewModel = new RolesUserViewModel
                    {
                        RoleId = role.Id,
                        RoleName = role.Name
                    };
                    rolesUserViewModel.isSelected = await userManager.IsInRoleAsync(user, role.Name);

                    lRoles.Add(rolesUserViewModel);
                }
                return lRoles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult ListeUsers(string returnUrl)
        {
            try
            {
                ListeUserRoleViewModel vm = new ListeUserRoleViewModel();
                vm.returnUrl = returnUrl;
                vm.lUser = userManager.Users.ToList();

                return View(vm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId, string returnUrl)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    ErrorViewModel vme = new ErrorViewModel("L'utilisateur avec l'id :" + userId + " n'a pas pu être trouvé");
                    return View("Error", vme);
                }
                else
                {
                    var result = await userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListeUsers", new { returnUrl = returnUrl });
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListeUsers", new { returnUrl = returnUrl });
                }
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId, string returnUrl)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId);

                if (role == null)
                {
                    ErrorViewModel vme = new ErrorViewModel("Le role avec l'id :" + roleId + " n'a pas pu être trouvé");
                    return View("Error", vme);
                }
                else
                {
                    var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);

                    if (usersInRole.Count == 0)
                    {

                        var result = await roleManager.DeleteAsync(role);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("ListeRoles", new { returnUrl = returnUrl });
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Il y a encore des utilisateurs qui ont ce rôle, il faut d'abord les retirer");
                    }

                    return View("ListeRoles", new { returnUrl = returnUrl });
                }
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId, string returnUrl)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    ErrorViewModel vme = new ErrorViewModel("L'utilisateur avec l'id :" + userId + " n'a pas pu être trouvé");
                    return View("Error", vme);
                }

                var userClaims = await userManager.GetClaimsAsync(user);
                var userRoles = await userManager.GetRolesAsync(user);

                var vm = new EditUserViewModel();
                vm.lGenres = new GenreUtilisateur().genres;
                vm.User = new Utilisateur();
                vm.User = user;
                vm.ReturnUrl = returnUrl;
                vm.Claims = userClaims.Select(c => c.Value).ToList();
                vm.Roles = userRoles.ToList();

                return View(vm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            try
            {
                model.lGenres = new GenreUtilisateur().genres;

                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByIdAsync(model.User.Id);


                    if (user == null)
                    {
                        ErrorViewModel vme = new ErrorViewModel("L'utilisateur avec l'id :" + model.User.Id + " n'a pas pu être trouvé");
                        return View("Error", vme);
                    }
                    else
                    {

                        user.Nom = model.User.Nom;
                        user.Prenom = model.User.Prenom;
                        user.UserName = model.User.UserName;
                        user.Sexe = model.User.Sexe;
                        user.PhoneNumber = model.User.PhoneNumber;
                        user.DateNaissance = model.User.DateNaissance;
                        user.estProfessionel = model.User.estProfessionel;

                        var result = await userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ListeUsers", new { returnUrl = model.ReturnUrl });
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }


        [HttpGet]
        public IActionResult CreateRole(string returnUrl)
        {
            try
            {
                CreateRoleViewModel vm = new CreateRoleViewModel();
                vm.ReturnUrl = returnUrl;

                return View(vm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model, string button)
        {
            try
            {
                if (button == "create")
                {
                    if (ModelState.IsValid)
                    {
                        IdentityRole identityRole = new IdentityRole
                        {
                            Name = model.RoleName
                        };

                        IdentityResult result = await roleManager.CreateAsync(identityRole);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ListeRoles", "Administration", new { returnUrl = model.ReturnUrl });
                        }

                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    return View(model);
                }
                return RedirectToAction("ListeRoles", "Administration", new { returnUrl = model.ReturnUrl });
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpGet]
        public IActionResult ListeRoles(string returnUrl)
        {
            try
            {
                ListeRoleViewModel vm = new ListeRoleViewModel();
                vm.returnUrl = returnUrl;
                vm.lRoles = roleManager.Roles;
                return View(vm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id, string returnUrl)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(id);

                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Le Rôle avec l'Id {id} n'a pas pu être trouvé";
                    return View("Error");
                }

                var model = new EditRoleViewModel
                {
                    Id = role.Id,
                    RoleName = role.Name,
                    returnUrl = returnUrl
                };

                foreach (var user in userManager.Users.ToList())
                {
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user.UserName);
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Le Rôle avec l'Id {model.Id} n'a pas pu être trouvé";
                    return View("Error");
                }
                else
                {
                    role.Name = model.RoleName;
                    var result = await roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListeRoles", new { returnUrl = model.returnUrl });
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId, string returnUrl)
        {
            try
            {
                ViewBag.roleId = roleId;
                ViewBag.roleName = roleManager.Roles.FirstOrDefault(x => x.Id == roleId).Name;
                ViewBag.returnUrl = returnUrl;

                var role = await roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Le Rôle avec l'Id {roleId} n'a pas pu être trouvé";
                    return View("Error");
                }
                var model = new List<UserRoleViewModel>();

                foreach (var user in userManager.Users.ToList())
                {
                    var userRoleViewModel = new UserRoleViewModel
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleViewModel.isSelected = true;
                    }
                    else
                    {
                        userRoleViewModel.isSelected = false;
                    }

                    model.Add(userRoleViewModel);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId, string returnUrl)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId);

                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Le Rôle avec l'Id {roleId} n'a pas pu être trouvé";
                    return View("Error");
                }

                for (int i = 0; i < model.Count; i++)
                {
                    var user = await userManager.FindByIdAsync(model[i].UserId);
                    IdentityResult result = null;

                    if (model[i].isSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!model[i].isSelected && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        result = await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }

                    if (result.Succeeded)
                    {
                        if (i < (model.Count - 1))
                            continue;
                        else
                            return RedirectToAction("EditRole", new { Id = roleId, ReturnUrl = returnUrl });
                    }
                }

                return RedirectToAction("EditRole", new { Id = roleId, ReturnUrl = returnUrl });
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel(ex.Message);
                return View("Error", vme);
            }
        }


    }
}