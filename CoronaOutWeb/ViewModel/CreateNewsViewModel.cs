using Microsoft.AspNetCore.Http;
using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ViewModel
{
    public class CreateNewsViewModel
    {
        public CreateNewsViewModel(int tailleMaxImages)
        {
            TailleMaxImages = tailleMaxImages;
            this.news = new News();
        }


        public CreateNewsViewModel()
        {
        }


        public News news { get; set; }

        public IFormFile image {get; set;}

        public int TailleMaxImages { get; set; }

        public string PathLogo { get; set; }
    }
}
