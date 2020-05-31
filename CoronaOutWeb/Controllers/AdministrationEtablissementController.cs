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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModelesApi.POC;

namespace CoronaOutWeb.Controllers
{
    [Authorize(Policy = "Modificateur")]
    public class AdministrationEtablissementController : Controller
    {
        private readonly IEtablissementService etablissementService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IPhotoService photoService;
        private readonly IHoraireService horaireService;
        private int NOMBREMAXPHOTOS = 5;
        private int TAILLEMAXIMAGE = 3000000;

        public AdministrationEtablissementController(IEtablissementService etablissementService, IWebHostEnvironment hostingEnvironment, IPhotoService photoService, IHoraireService horaireService)
        {
            this.etablissementService = etablissementService;
            this.hostingEnvironment = hostingEnvironment;
            this.photoService = photoService;
            this.horaireService = horaireService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateEtablissementViewModel model = new CreateEtablissementViewModel(NOMBREMAXPHOTOS, TAILLEMAXIMAGE);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateEtablissementViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var userId = User.Claims.FirstOrDefault(x => x.Type.ToString() == "sub").Value;

                    if (User != null)
                    {

                        Etablissement newEtabl = new Etablissement();
                        newEtabl = model.Etab;
                        Guid userGuid;
                        
                        if (Guid.TryParse(userId, out userGuid))
                        {
                            newEtabl.PublieParUserId = userGuid;
                        }

                        else
                        {
                            RedirectToAction("Index", "Home");
                        }

                        
                        newEtabl.DatePublication = DateTime.Now;

                        string logoNom = "";
                        if (model.Logo != null)
                        {
                            //charge le logo sur le serveur
                            string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img", "Etablissement", newEtabl.Id.ToString(), "Logo");

                            if (!Directory.Exists(uploadFolder))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(uploadFolder);
                            }

                            logoNom = Guid.NewGuid().ToString() + "_" + model.Logo.FileName;
                            string logoPath = Path.Combine(uploadFolder, logoNom);
                            model.Logo.CopyTo(new FileStream(logoPath, FileMode.Create));

                            //charge le nom du fichier dans le nouvel établissement
                            newEtabl.Logo = logoNom;
                        }
                        


                        //crée l'établissement
                        var idToken = await HttpContext.GetTokenAsync("access_token");
                        try
                        {
                            var result = await etablissementService.CreateEtablissementAsync(newEtabl, idToken);
                        }
                        catch (Exception)
                        {
                            return View("Error");
                        }

                        //crée les photos
                        if (model.Photos != null)
                        {
                            foreach (PhotoGeneriqueViewModel photo in model.Photos)
                            {
                                createPhotos(newEtabl, photo);
                            }                           
                        }

                        //crée les horaires
                        createHoraires(newEtabl, model.lHoraire);


                        return RedirectToAction("ListeEtablissementOwned");
                    }
                    else
                        RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(model);
        }

        private async void createPhotos(Etablissement newEtabl, PhotoGeneriqueViewModel photo)
        {
            var idToken = await HttpContext.GetTokenAsync("access_token");

            if (photo.Photo != null)
            {
                //charge la photo sur le serveur
                string PhotoNom = "";
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img", "Etablissement", newEtabl.Id.ToString(), "Photos");

                if (!Directory.Exists(uploadFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(uploadFolder);
                }

                Guid photoGuid = photo.id;
                PhotoNom = photoGuid.ToString() + "_" + photo.Photo.FileName;
                string logoPath = Path.Combine(uploadFolder, PhotoNom);
                photo.Photo.CopyTo(new FileStream(logoPath, FileMode.Create));

                //crée l'objet photo
                PhotoEtablissement photoNew = new PhotoEtablissement();
                photoNew.Id = photoGuid;
                photoNew.NomFichier = PhotoNom;
                photoNew.EtablissementId = newEtabl.Id;

                try
                {
                    var result = await photoService.CreatePhotoAsync(photoNew, idToken);
                }
                catch (Exception)
                {
                    RedirectToAction("Error");
                }
            }
            
        }

        private async void createHoraires(Etablissement newEtabl, List<Horaire> lHoraire)
        {
            var idToken = await HttpContext.GetTokenAsync("access_token");

            foreach (Horaire horaire in lHoraire)
            {
                if (!(horaire.Jour == null || (horaire.HeureOuverture == new TimeSpan() && horaire.HeureFermeture == new TimeSpan())))
                {

                 horaire.EtablissementId = newEtabl.Id;

                    try
                    {
                        var result = await horaireService.CreateHoraireAsync(horaire, idToken);
                    }
                    catch (Exception)
                    {
                        RedirectToAction("Error");
                    }
                }
            }

        }


        [HttpPost]
        public ActionResult AddHoraire(CreateEtablissementViewModel vm)
        {
            vm.lHoraire.Add(new Horaire());
            return PartialView("ListeHoraire", vm);
        }

        [HttpPost]
        public ActionResult DeleteHoraire(CreateEtablissementViewModel vm, int id)
        {
            try
            {
                vm.lHoraire.RemoveAt(id);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return PartialView("ListeHoraire", vm);
        }



        [HttpGet]
        public async Task<IActionResult> ListeEtablissementOwned()
        {
            ListeEtablissementsViewModel vm = new ListeEtablissementsViewModel();
            try
            {
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
            }
            catch (Exception)
            {
                return View("Error");
            }
       
            return View(vm);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Validate(Guid etabId, string button)
        {
            try
            {
                Etablissement etab = await etablissementService.GetEtablissementAsync(etabId);

                etab.estValide = bool.Parse(button);

                var idToken = await HttpContext.GetTokenAsync("access_token");

                var result = await etablissementService.UpdateEtablissementAsync(etab, idToken);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return RedirectToAction("ListeEtablissementOwned");

        }
    }
}

