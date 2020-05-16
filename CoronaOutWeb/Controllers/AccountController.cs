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
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.lGenres = new GenreUtilisateur().genres;

            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.User;
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // logger
                }
            }
            return View();
        }

    }
}