using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoronaOutWeb.ExternalApiCall.News;
using CoronaOutWeb.Models;
using CoronaOutWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ModelesApi.POC;

namespace CoronaOutWeb.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ListeNewsViewModel model = new ListeNewsViewModel();
                model.lNews = await newsService.GetAllNewsAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                ErrorViewModel vme = new ErrorViewModel() { RequestId = ex.Message };
                return View("Error", vme);
            }
        }


        public async Task<IActionResult> Get(Guid newsId)
        {
            News news = await newsService.GetNewsAsync(newsId);
            ViewBag.photoPath = Path.Combine("\\", "img", "News", newsId.ToString(), "Image", news.ImageName);
            ViewBag.isLogged = User.Identity.IsAuthenticated;

            return View(news);
        }

        [HttpGet]
        public async Task<IActionResult> GetPopUp()
        {
            List<News> lNewsTotale = await newsService.GetAllNewsAsync();

            if (lNewsTotale != null)
            {
                News newsPopUp = lNewsTotale.FirstOrDefault(n => n.estAffichePremier == true);

                if (newsPopUp!=null)
                {
                    ViewBag.photoPath = Path.Combine("\\", "img", "News", newsPopUp.Id.ToString(), "Image", newsPopUp.ImageName);
                    return PartialView("Get", newsPopUp);
                }
            }
            return null;           
        }
    }
}