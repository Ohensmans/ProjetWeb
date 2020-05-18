using System;
using System.Threading.Tasks;
using CoronaOutWeb.ExternalApiCall.Users;
using CoronaOutWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ModelesApi.POC;

namespace CoronaOutWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController (IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.lGenres = new GenreUtilisateur().genres;

            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                    if (model.Password.Equals(model.ConfirmPassword))
                    {
                        var result = await userService.CreateUserAsync(model.Password, model.User);
                    }                  
                


                //login
            }
            return View();
        }

    }
}