using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoronaOutWeb.ExternalApiCall.Etablissements;
using CoronaOutWeb.Models;
using CoronaOutWeb.ViewModel;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment hostingEnvironment;

        public AdministrationEtablissementController(IOptions<BaseUrl> url, IEtablissementService etablissementService, IHostingEnvironment hostingEnvironment)
        {
            this.baseUrl = url.Value.ApiEtablissement;
            this.etablissementService = etablissementService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            MonEtablissementViewModel model = new MonEtablissementViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MonEtablissementViewModel model)
        {
            if (ModelState.IsValid)
            {
                string logoNom = null;
                if (model.Logo !=null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img", model.Etab.Id.ToString());
                    logoNom = Guid.NewGuid().ToString() + "_" + model.Logo.FileName;
                    string logoPath = Path.Combine(uploadFolder, logoNom);
                    model.Logo.CopyTo(new FileStream(logoPath, FileMode.Create));
                }
            }

            return View();
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

