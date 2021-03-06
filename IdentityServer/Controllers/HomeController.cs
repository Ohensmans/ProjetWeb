﻿using IdentityServer.Models;
using IdentityServer.ViewModel;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    
    public class HomeController : Controller
    {

        private readonly IIdentityServerInteractionService _interaction;
        private readonly IWebHostEnvironment _environment;
        private readonly string CoronaOutWebUrl;

        public HomeController(IIdentityServerInteractionService interaction, IWebHostEnvironment environment, IOptions<BaseUrl> url)
        {
            _interaction = interaction;
            _environment = environment;
            this.CoronaOutWebUrl = url.Value.CoronaOutWeb;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Back()
        {
            return Redirect(CoronaOutWebUrl);
        }

        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;

                if (!_environment.IsDevelopment())
                {
                    // only show in development
                    message.ErrorDescription = null;
                }
            }

            return View("Error", vm);
        }

        public IActionResult Error(ErrorViewModel vm)
        {
            return View("Error", vm);
        }


    }
}