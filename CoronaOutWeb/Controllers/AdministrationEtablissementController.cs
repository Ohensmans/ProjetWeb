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
        private readonly string baseUrl;
        private readonly IEtablissementService etablissementService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private int NOMBREMAXPHOTOS = 5;
        private int TAILLEMAXIMAGE = 3000000;

        public AdministrationEtablissementController(IOptions<BaseUrl> url, IEtablissementService etablissementService, IWebHostEnvironment hostingEnvironment)
        {
            this.baseUrl = url.Value.ApiEtablissement;
            this.etablissementService = etablissementService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            MonEtablissementViewModel model = new MonEtablissementViewModel(NOMBREMAXPHOTOS, TAILLEMAXIMAGE);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(MonEtablissementViewModel model)
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


                        foreach (Horaire horaire in newEtabl.lHoraire)
                        {
                            horaire.Etablissement = newEtabl;
                        }

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

                        if (model.Photos != null)
                        {
                            foreach (IFormFile photo in model.Photos)
                            {
                                if (photo != null)
                                {
                                    //charge la photo sur le serveur
                                    string PhotoNom = "";
                                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img", "Etablissement", newEtabl.Id.ToString(), "Photos");

                                    if (!Directory.Exists(uploadFolder))
                                    {
                                        DirectoryInfo di = Directory.CreateDirectory(uploadFolder);
                                    }

                                    Guid photoGuid = Guid.NewGuid();
                                    PhotoNom = photoGuid.ToString() + "_" + photo.FileName;
                                    string logoPath = Path.Combine(uploadFolder, PhotoNom);
                                    photo.CopyTo(new FileStream(logoPath, FileMode.Create));

                                    //crée l'objet photo
                                    PhotoEtablissement photoNew = new PhotoEtablissement();
                                    photoNew.Id = photoGuid;
                                    photoNew.NomFichier = PhotoNom;
                                    photoNew.Etablissement = newEtabl;

                                    //rajoute la photo à l'établissement
                                    newEtabl.lPhotos.Add(photoNew);
                                }
                            }
                        }

                        var idToken = await HttpContext.GetTokenAsync("access_token");
                        try
                        {
                            var result = await etablissementService.CreateEtablissementAsync(newEtabl, idToken);
                        }
                        catch (Exception ex)
                        {
                            return View(new ErrorViewModel { RequestId = ex.Message });
                        }


                        return RedirectToAction("ListeEtablissementOwned");
                    }
                    else
                        RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddHoraire(MonEtablissementViewModel vm)
        {
            vm.Etab.lHoraire.Add(new Horaire());
            return PartialView("AddHoraire", vm);
        }

        [HttpPost]
        public ActionResult DeleteHoraire(MonEtablissementViewModel vm, int id)
        {
            try
            {
                vm.Etab.lHoraire.RemoveAt(id);
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message });
            }

            return PartialView("AddHoraire", vm);
        }


        public ActionResult Test()
        {
            Horaire test = new Horaire
            {
                HeureFermeture = new TimeSpan(12, 0, 0),
                HeureOuverture = new TimeSpan(12, 30, 0),
                Jour = "Lundi",
                Id = Guid.NewGuid()
            };
            return View("~/Views/Shared/EditorTemplates/Horaire.cshtml", test);
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
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message });
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
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = ex.Message });
            }

            return RedirectToAction("ListeEtablissementOwned");

        }
    }
}

