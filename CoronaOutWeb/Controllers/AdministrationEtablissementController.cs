using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaOutWeb.ExternalApiCall.Etablissements;
using CoronaOutWeb.Models;
using CoronaOutWeb.ViewModel;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModelesApi.POC;

namespace CoronaOutWeb.Controllers
{
    [Authorize(Policy = "Modificateur")]
    public class AdministrationEtablissementController : Controller
    {
        private readonly string baseUrl;
        private readonly IEtablissementService etablissementService;

        public AdministrationEtablissementController(IOptions<BaseUrl> url, IEtablissementService etablissementService)
        {
            this.baseUrl = url.Value.ApiEtablissement;
            this.etablissementService = etablissementService;
        }

        [HttpGet]
        public IActionResult Create(string ReturnUrl)
        {
            MonEtablissementViewModel vm = new MonEtablissementViewModel();

            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> ListeEtablissementOwned()
        {
            ListeEtablissementsViewModel vm = new ListeEtablissementsViewModel();
            List<Etablissement> lEtab = await etablissementService.GetAllEtablissementsAsync();

            if (!User.Claims.Any(x => x.Value == "Administrateur" && x.Type.ToString() == "role"))
            {
                var Id = User.Identity.GetSubjectId();
                Guid userId = Guid.Parse(Id);
                vm.Etablissements = lEtab.Where(x => x.PublieParUserId == userId).ToList();
            }
            else
            {
                vm.Etablissements = lEtab;
            }

            return View(vm);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Validate(Guid etabId, string button)
        {

            Etablissement etab = await etablissementService.GetEtablissementAsync(etabId);

            etab.estValide = bool.Parse(button);

            var idToken = await HttpContext.GetTokenAsync("access_token");

            var result = await etablissementService.UpdateEtablissementAsync(etab, idToken);

            return RedirectToAction("ListeEtablissementOwned");

        }
    }
}

