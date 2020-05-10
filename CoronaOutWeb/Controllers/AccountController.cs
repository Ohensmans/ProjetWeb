using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaOutWeb.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelesApi.POC;

namespace CoronaOutWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Utilisateur> userManager;

        public AccountController (UserManager<Utilisateur> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Utilisateur { UserName = model.user.Nom };
                var result = await userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    // logger
                }
            }
            return View();
        }

    }
}