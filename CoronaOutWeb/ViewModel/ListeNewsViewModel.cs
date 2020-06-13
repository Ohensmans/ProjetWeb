using ModelesApi.POC;
using System.Collections.Generic;

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
