using CoronaOutWeb.ExternalApiCall.Etablissements;
using CoronaOutWeb.Models;
using CoronaOutWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModelesApi.POC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaOutWeb.Controllers
{
    public class EtablissementsController : Controller
    {
        private string baseUrl;
        private readonly HttpClient client;
        private readonly IEtablissementService etablissementService;
        private readonly IHoraireService horaireService;
        private readonly IPhotoService photoService;

        public EtablissementsController(IOptions<BaseUrl> url, IEtablissementService etablissementService, IHoraireService horaireService, IPhotoService photoService)
        {
            this.baseUrl = url.Value.ApiEtablissement;
            this.client = Program.client;
            this.etablissementService = etablissementService;
            this.horaireService = horaireService;
            this.photoService = photoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListeEtablissements()
        {


            ListeEtablissementsViewModel vm = new ListeEtablissementsViewModel();

            vm.Etablissements = await etablissementService.GetAllEtablissementsAsync();

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Fiche(string id)
        {
            FicheViewModel model = new FicheViewModel();

            List<Etablissement> lEtabs = await etablissementService.GetAllEtablissementsAsync();

            if (id != null)
            {
                model.Etab = lEtabs.FirstOrDefault(x => x.NomUrl == id);

                if (model.Etab != null)
                {
                    List<Horaire> lHoraire = await horaireService.GetAllHorairesAsync();
                    if (lHoraire.Any(x => x.EtablissementId == model.Etab.Id))
                    {
                        model.Etab.lHoraire = lHoraire.Where(x => x.EtablissementId == model.Etab.Id).ToList();

                        List<string> lJours = new JoursSemaine().lJours;
                        model.Etab.lHoraire = model.Etab.lHoraire.OrderBy(h => lJours.IndexOf(h.Jour)).ThenBy(h => h.HeureOuverture).ToList();
                    }

                    List<PhotoEtablissement> lPhotos = await photoService.GetAllPhotosAsync();

                    if (lPhotos.Any(x => x.EtablissementId == model.Etab.Id))
                    {
                        lPhotos = lPhotos.Where(x => x.EtablissementId == model.Etab.Id).ToList();

                        List<PhotoGeneriqueViewModel> lPathImages = new List<PhotoGeneriqueViewModel>();
                        if (lPhotos != null)
                        {
                            foreach (PhotoEtablissement photo in lPhotos)
                            {
                                PhotoGeneriqueViewModel photoGenerique = new PhotoGeneriqueViewModel();
                                photoGenerique.Path = Path.Combine("\\", "img", "Etablissement", model.Etab.Id.ToString(), "Photos", photo.NomFichier);
                                photoGenerique.id = photo.Id;
                                lPathImages.Add(photoGenerique);
                            }
                        }
                        model.lPathPhotos = lPathImages;
                    }

                    if (model.Etab.Logo != null)
                    {
                        model.PathLogo = Path.Combine("\\", "img", "Etablissement", model.Etab.Id.ToString(), "Logo", model.Etab.Logo);
                    }
                    ViewBag.isLogged = User.Identity.IsAuthenticated;

                    return View(model);
                }
            }

            return RedirectToAction("ListeEtablissements");       
        }





    }
}