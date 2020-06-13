using ModelesApi.POC;
using System.Collections.Generic;

namespace CoronaOutWeb.ViewModel
{
    public class FicheViewModel
    {

        public FicheViewModel()
        {
            lPathPhotos = new List<PhotoGeneriqueViewModel>();
            Etab = new Etablissement();
            Etab.lHoraire = new List<Horaire>();
        }

        public Etablissement Etab { get; set; }
        public List<PhotoGeneriqueViewModel> lPathPhotos { get; set; }
        public string PathLogo { get; set; }
    }
}
