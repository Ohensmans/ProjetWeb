﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoronaOutWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CoronaOutWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var idToken = await HttpContext.GetTokenAsync("id_token");

            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            var test = User.Claims.Any(x => x.Value == "Administrateur" && x.Type.ToString()=="role");

            var test2 = User.Claims.FirstOrDefault(x => x.Type.ToString() == "sub").Value;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //pour actionner le log out
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Index");    
        }

        //pour actionner le log in
        [Authorize]
        public  IActionResult Login()
        {
            return Redirect("Index");
        }
    }
}
