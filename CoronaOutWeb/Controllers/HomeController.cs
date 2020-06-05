using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoronaOutWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.Extensions.Options;
using CoronaOutWeb.ViewModel;
using CoronaOutWeb.ExternalApiCall.Map;
using CoronaOutWeb.ExternalApiCall.Etablissements;
using System.Collections.Generic;
using ModelesApi.POC;
using Newtonsoft.Json;

namespace CoronaOutWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEtablissementService etablissementService;
        private readonly IHoraireService horaireService;
        private readonly IMapService mapService;
        private readonly string Mapbox; 

        public HomeController(ILogger<HomeController> logger, IOptions<BaseKey> key, IEtablissementService etablissementService, IHoraireService horaireService, IMapService mapService)
        {
            _logger = logger;
            this.etablissementService = etablissementService;
            this.horaireService = horaireService;
            this.mapService = mapService;
            this.Mapbox = key.Value.MapBox;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.MapBox = this.Mapbox;

            return View(model);
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<string>> getCoordinates()
        {
            List<Etablissement> lEtabl = await etablissementService.GetAllEtablissementsAsync();
            List<string> lCoordinates = new List<string>();

            foreach (Etablissement etab in lEtabl)
            {
                if (etab.estValide)
                {
                    Marker marker = new Marker();

                    string adresse = etab.NumeroBoite + "+" + etab.Rue + ",+" + etab.CodePostal + ",+" + etab.Ville + ",+" + etab.Pays;
                    marker = await mapService.GetCoordinates(adresse);
                    marker.Nom = etab.Nom;
                    marker.NomUrl = etab.NomUrl;
                    string coordinates = JsonConvert.SerializeObject(marker);
                    lCoordinates.Add(coordinates);
                }
            }

            return lCoordinates;
        }

    }
}
