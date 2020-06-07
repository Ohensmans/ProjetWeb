using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoronaOutWeb.ExternalApiCall.News;
using CoronaOutWeb.Models;
using CoronaOutWeb.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModelesApi.POC;

namespace CoronaOutWeb.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdministrationNewsController : Controller
    {
        private readonly INewsService newsService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly int TAILLEMAXPHOTO;

        public AdministrationNewsController(INewsService newsService, IWebHostEnvironment hostingEnvironment, IOptions<BaseParams> baseParams)
        {
            this.newsService = newsService;
            this.hostingEnvironment = hostingEnvironment;
            this.TAILLEMAXPHOTO = baseParams.Value.TailleMaxImage;
        }

        [HttpGet]
        public async Task<IActionResult> ListeNews()
        {
            try
            {
                ListeNewsViewModel model = new ListeNewsViewModel();
                model.lNews = await newsService.GetAllNewsAsync();
                return View(model);
            }
            catch (Exception ex )
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message};
                return View("Error", vme);
            }            
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateNewsViewModel model = new CreateNewsViewModel(TAILLEMAXPHOTO);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var idToken = await HttpContext.GetTokenAsync("access_token");

                model.news.DatePublication = DateTime.Now;
                model.news.estAffichePremier = false;
                model.news.ImageName = createImage(model.news.Id, model.image);
                model.news.PublieParUserId = User.Claims.FirstOrDefault(x => x.Type.ToString() == "sub").Value;

                try
                {
                    var result = await newsService.CreateNewstAsync(model.news, idToken);
                    return RedirectToAction("ListeNews");
                }
                catch (Exception ex)
                {
                    ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                    return View("Error", vme);
                }

            }
            return View(model);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                CreateNewsViewModel model = new CreateNewsViewModel(TAILLEMAXPHOTO);
                model.news = await newsService.GetNewsAsync(id);

                if (model.news.ImageName != null)
                {
                    model.PathLogo = Path.Combine("\\", "img", "News", model.news.Id.ToString(), "Image", model.news.ImageName);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateNewsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    News news = new News();
                    news = model.news;

                    var idToken = await HttpContext.GetTokenAsync("access_token");

                    if (model.PathLogo==null && news.ImageName!=null)
                    {
                        deleteDirectory(news.Id.ToString());
                        news.ImageName = "";
                    }

                    if (model.image!=null)
                    {
                        if (news.ImageName!=null)
                        {
                            deleteFile(news.Id, news.ImageName);
                            news.ImageName = "";
                        }
                        news.ImageName = createImage(news.Id, model.image);
                    }

                    news.DatePublication = DateTime.Now;
                    news.PublieParUserId = User.Claims.FirstOrDefault(x => x.Type.ToString() == "sub").Value;

                    var result = newsService.UpdateNewsAsync(model.news, idToken);

                    return RedirectToAction("ListeNews");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }

        }


        [HttpPost]
        public async Task<IActionResult> DeleteNews(Guid id)
        {
            try
            {
                var idToken = await HttpContext.GetTokenAsync("access_token");

                deleteDirectory(id.ToString());

                await newsService.DeleteNewsAsync(id, idToken);

                return RedirectToAction("ListeNews");
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Afficher(Guid id)
        {
            var idToken = await HttpContext.GetTokenAsync("access_token");
            try
            {
                List<News> lNewsTotale = await newsService.GetAllNewsAsync();

                //vérifie si il y a déjà une news qui doit être affichée en premier, si oui retire la propriété
                if (lNewsTotale.Any(n => n.estAffichePremier == true))
                {
                    News newsAModifier = lNewsTotale.First(n => n.estAffichePremier == true);
                    newsAModifier.estAffichePremier = false;

                    var result = await newsService.UpdateNewsAsync(newsAModifier, idToken);
                }

                //modifie la news pour qu'elle soit affichée en premier
                if (lNewsTotale.Any(n => n.Id == id))
                {
                    News newsAAfficher = lNewsTotale.First(n => n.Id == id);
                    newsAAfficher.estAffichePremier = true;

                    var result = await newsService.UpdateNewsAsync(newsAAfficher, idToken);
                }
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }

            return RedirectToAction("ListeNews");
        }


        private string createImage(Guid newsId, IFormFile image)
        {
            string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "img", "News", newsId.ToString(), "Image");

            if (!Directory.Exists(uploadFolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(uploadFolder);
            }

            Guid imageGuid = Guid.NewGuid();
            string imageNom = imageGuid.ToString() + "_" + image.FileName;
            string logoPath = Path.Combine(uploadFolder, imageNom);
            image.CopyTo(new FileStream(logoPath, FileMode.Create));

            return imageNom;
        }


        private void deleteFile(Guid newsId, string fileName)
        {
            try
            {
                string PathLogo = Path.Combine("\\", "img", "News", newsId.ToString(), "Image", fileName);

                if (System.IO.File.Exists(PathLogo))
                {
                    System.IO.File.Delete(PathLogo);
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

        private void deleteDirectory(string PathDirectory)
        {
            try
            {
                string PathCible = Path.Join(hostingEnvironment.WebRootPath, "img", "news", PathDirectory);

                string[] files = Directory.GetFiles(PathCible);
                string[] dirs = Directory.GetDirectories(PathCible);

                foreach (string file in files)
                {
                    System.IO.File.SetAttributes(file, FileAttributes.Normal);
                    System.IO.File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    string[] paths = dir.Split("\\");
                    int nb = paths.Length-2;

                    string PathDir = Path.Join(paths[nb], paths[nb + 1]);

                    deleteDirectory(PathDir);
                }

                Directory.Delete(PathCible, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
