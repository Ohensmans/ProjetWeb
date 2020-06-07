using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ViewModel
{
    public class ListeNewsViewModel
    {
        public ListeNewsViewModel()
        {
            this.lNews = new List<News>();
        }

        public List<News> lNews { get; set; }

    }
}
