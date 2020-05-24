using CoronaOutWeb.ExternalApiCall.Etablissements;
using CoronaOutWeb.Models;
using CoronaOutWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModelesApi.POC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaOutWeb.Controllers
{
    public class EtablissementsController : Controller
    {
        private string baseUrl;
        private readonly HttpClient client;
        private readonly IEtablissementService etablissementService;

        public EtablissementsController(IOptions<BaseUrl> url, IEtablissementService etablissementService)
        {
            this.baseUrl = url.Value.ApiEtablissement;
            this.client = Program.client;
            this.etablissementService = etablissementService;
        }

        [HttpGet]
        public async Task<IActionResult> ListeEtablissements()
        {


            ListeEtablissementsViewModel vm = new ListeEtablissementsViewModel();

            vm.Etablissements = await etablissementService.GetAllEtablissementsAsync();

            return View(vm);
        }

        public async Task<IActionResult> Fiche(string id)
        {


            FicheViewModel vm = new FicheViewModel();

            vm.Etablissements = await etablissementService.GetAllEtablissementsAsync();

            if (id != null)
                vm.EtablissementId = Guid.Parse(id);
            else
                vm.EtablissementId = Guid.Empty;

            return View(vm);
        }





    }
}