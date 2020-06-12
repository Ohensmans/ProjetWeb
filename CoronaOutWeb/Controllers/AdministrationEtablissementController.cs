using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        private int NOMBREMAXPHOTOS;
        private int TAILLEMAXIMAGE;
        private int TAILLEMAXLOGO;

        public AdministrationEtablissementController(IEtablissementService etablissementService, IWebHostEnvironment hostingEnvironment, IPhotoService photoService, IHoraireService horaireService, IOptions<BaseParams> baseParams)
        {
            this.etablissementService = etablissementService;
            this.hostingEnvironment = hostingEnvironment;
            this.photoService = photoService;
            this.horaireService = horaireService;
            this.NOMBREMAXPHOTOS = baseParams.Value.NbMaxPhotos;
            this.TAILLEMAXIMAGE = baseParams.Value.TailleMaxImage;
            this.TAILLEMAXLOGO = baseParams.Value.TailleMaxLogo;
        }


        [HttpGet]
        public async Task<IActionResult> EditHoraires(Guid etablissementId)
        {
            try
            {
                EditHoraireViewModel model = new EditHoraireViewModel();
                List<Horaire> lHoraire = await horaireService.GetAllHorairesAsync();
                lHoraire = lHoraire.Where(x => x.EtablissementId == etablissementId).ToList();

                if (lHoraire != null)
                {
                    List<string> lJours = new JoursSemaine().lJours;
                    lHoraire = lHoraire.OrderBy(h => lJours.IndexOf(h.Jour)).ThenBy(h => h.HeureOuverture).ToList();

                    model.lHoraire = lHoraire;
                }
                else
                {
                    model.lHoraire = new List<Horaire>();
                }
                model.EtablissementId = etablissementId;

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditHoraires(EditHoraireViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var idToken = await HttpContext.GetTokenAsync("access_token");

                    List<Horaire> lHoraireTotal = await horaireService.GetAllHorairesAsync();
                    List<Horaire> lHoraireEtab = lHoraireTotal.Where(x => x.EtablissementId == model.EtablissementId).ToList();

                    foreach(Horaire horaire in model.lHoraire)
                    {
                        horaire.EtablissementId = model.EtablissementId;
                    }


                    // fait l'update des horaires qui sont toujours dans le model
                    foreach (Horaire horaire in model.lHoraire)
                    {
                        if (lHoraireEtab.Contains(horaire))
                        {
                            var result = await horaireService.UpdateHoraireAsync(horaire, idToken);
                        }
                    }

                    //supprime les horaires qui ne sont plus dans le model
                    foreach (Horaire horaire in lHoraireEtab)
                    {
                        if (!model.lHoraire.Contains(horaire))
                        {
                            await horaireService.DeleteHoraireAsync(horaire.Id, idToken);
                        }
                    }

                    //ajoute les horaires qui ne sont pas dans la DB
                    foreach (Horaire horaire in model.lHoraire)
                    {
                        if (!lHoraireEtab.Contains(horaire))
                        {
                            var result = await horaireService.CreateHoraireAsync(horaire, idToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                    return View("Error", vme);
                }
            }
            return RedirectToAction("ListeEtablissementOwned");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEtablissement(Guid etablissementId)
        {
            try
            {
                var idToken = await HttpContext.GetTokenAsync("access_token");
                await etablissementService.DeleteEtablissementAsync(etablissementId, idToken);

                return RedirectToAction("ListeEtablissementOwned");
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditEtablissement(Guid etablissementId)
        {
            try
            {
                Etablissement etab = await etablissementService.GetEtablissementAsync(etablissementId);
                EditEtablissementViewModel model = new EditEtablissementViewModel();
                model.Etab = etab;
                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEtablissement(EditEtablissementViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idToken = await HttpContext.GetTokenAsync("access_token");
                    var result = await etablissementService.UpdateEtablissementAsync(model.Etab, idToken);
                }
                catch (Exception ex)
                {
                    ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                    return View("Error", vme);
                }

            }
            else
                return View(model);

            return RedirectToAction("ListeEtablissementOwned");
        }

        [HttpGet]
        public async Task<IActionResult> EditImages(Guid etablissementId)
        {
            try
            {
                EditImagesViewModel model = new EditImagesViewModel(NOMBREMAXPHOTOS, TAILLEMAXIMAGE, etablissementId, TAILLEMAXLOGO);

                //récupère le path vers le logo si il existe
                Etablissement etabl = await etablissementService.GetEtablissementAsync(etablissementId);
                if (etabl.Logo != null)
                {
                    model.PathLogo = Path.Combine("\\", "img", "Etablissement", etabl.Id.ToString(), "Logo", etabl.Logo);
                }

                //récupère les path vers les images
                List<PhotoEtablissement> lPhotos = await photoService.GetAllPhotosAsync();
                lPhotos = lPhotos.Where(x => x.EtablissementId == etablissementId).ToList();
                List<PhotoGeneriqueViewModel> lPathImages = new List<PhotoGeneriqueViewModel>();
                if (lPhotos != null)
                {
                    foreach (PhotoEtablissement photo in lPhotos)
                    {
                        PhotoGeneriqueViewModel photoGenerique = new PhotoGeneriqueViewModel();
                        photoGenerique.Path = Path.Combine("\\", "img", "Etablissement", etabl.Id.ToString(), "Photos", photo.NomFichier);
                        photoGenerique.id = photo.Id;
                        lPathImages.Add(photoGenerique);
                    }
                }
                model.lPathImages = lPathImages;

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditImages(EditImagesViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idToken = await HttpContext.GetTokenAsync("access_token");
                    
                    //met à jour l'établissement avec le nouveau logo le cas échéant
                    if (model.PathLogo == null && model.Logo != null)
                    {
                        Etablissement etab = await etablissementService.GetEtablissementAsync(model.EtablissementId);

                        if (etab.Logo !=null)
                        {
                            string PathLogo = Path.Combine(hostingEnvironment.WebRootPath, "img", "Etablissement", etab.Id.ToString(), "Logo", etab.Logo);
                            deleteImage(PathLogo);
                        }

                        etab.Logo = createLogo(etab.Id, model.Logo);
                        var result = await etablissementService.UpdateEtablissementAsync(etab, idToken);
                    }

                    //supprime les photos le cas échéant
                    if (model.lPathImages != null)
                    {
                        List<PhotoGeneriqueViewModel> lPhotosASupprimer = new List<PhotoGeneriqueViewModel>();
                        lPhotosASupprimer = model.lPathImages.Where(x => x.IsToBeDeleted).ToList();
                        if (lPhotosASupprimer != null)
                        {
                            foreach (PhotoGeneriqueViewModel photo in lPhotosASupprimer)
                            {
                                string PathLogo = Path.Join(hostingEnvironment.WebRootPath, photo.Path);
                                deleteImage(PathLogo);
                                var result = photoService.DeletePhotoAsync(photo.id, idToken);
                            }
                        }
                    }

                    //rajoute les photos le cas échéant
                    List<PhotoGeneriqueViewModel> lPhotosARajouter = new List<PhotoGeneriqueViewModel>();
                    lPhotosARajouter = model.Photos.Where(x => x.Photo != null).ToList();
                    if (lPhotosARajouter!=null)
                    {
                        foreach (PhotoGeneriqueViewModel photo in lPhotosARajouter)
                        {
                            createPhoto(model.EtablissementId, photo);
                        }
                    }


                }
                catch (Exception ex)
                {
                    ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                    return View("Error", vme);
                }


            }
            return RedirectToAction("ListeEtablissementOwned");
        }


        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                CreateEtablissementViewModel model = new CreateEtablissementViewModel(NOMBREMAXPHOTOS, TAILLEMAXIMAGE, TAILLEMAXLOGO);

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
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
                        newEtabl.NomUrl = await getNomUrl(newEtabl.Nom);
                        
                        if (model.Logo != null)
                        {
                            //stocke le logo sur le serveur et renvoie son nom
                            newEtabl.Logo = createLogo(newEtabl.Id, model.Logo);
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
                                createPhoto(newEtabl.Id, photo);
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
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }

            return View(model);
        }

        private async Task<string> getNomUrl(string nom)
        {
            try
            {
                List<Etablissement> lEtab = await etablissementService.GetAllEtablissementsAsync();
                string NomUrl = Regex.Replace(nom, @"\s", "");
                NomUrl = Regex.Replace(nom, @"é|è", "e");
                NomUrl = Regex.Replace(nom, @"\$|\§", "s");
                NomUrl = Regex.Replace(nom, @"ç", "c");

                if (lEtab.Any(x => x.NomUrl.ToUpper() == NomUrl.ToUpper()))
                {
                    int i = 1;
                    while (lEtab.Any(x => x.NomUrl.ToUpper() == (NomUrl + i).ToUpper()))
                    {
                        i++;
                    }
                    NomUrl += i;
                }

                return NomUrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void createPhoto(Guid EtabId, PhotoGeneriqueViewModel photo)
        {
            var idToken = await HttpContext.GetTokenAsync("access_token");

            if (photo.Photo != null)
            {
                //charge la photo sur le serveur
                string PhotoNom = "";
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img", "Etablissement", EtabId.ToString(), "Photos");

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
                photoNew.EtablissementId = EtabId;

                try
                {
                    var result = await photoService.CreatePhotoAsync(photoNew, idToken);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
        }

        private void deleteImage (string Path)
        {
            try
            {
                if (System.IO.File.Exists(Path))
                {
                    System.IO.File.Delete(Path);
                }
                else
                {
                    throw new Exception("Le fichier n'existe pas");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string createLogo(Guid EtablId, IFormFile Logo)
        {
            try
            {
                string logoNom = "";
                //charge le logo sur le serveur
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img", "Etablissement", EtablId.ToString(), "Logo");

                if (!Directory.Exists(uploadFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(uploadFolder);
                }

                logoNom = Guid.NewGuid().ToString() + "_" + Logo.FileName;
                string logoPath = Path.Combine(uploadFolder, logoNom);
                Logo.CopyTo(new FileStream(logoPath, FileMode.Create));

                //retourne le nom du fichier dans le nouvel établissement
                return logoNom;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }


        [HttpPost]
        public ActionResult AddHoraire(CreateEtablissementViewModel vm)
        {
            try
            {
                vm.lHoraire.Add(new Horaire());
                return PartialView("ListeHoraire", vm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }

        [HttpDelete]
        public ActionResult DeleteHoraire(CreateEtablissementViewModel vm, int id)
        {
            try
            {
                vm.lHoraire.RemoveAt(id);
                return PartialView("ListeHoraire", vm);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
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
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
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
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }

            return RedirectToAction("ListeEtablissementOwned");

        }
    }
}

