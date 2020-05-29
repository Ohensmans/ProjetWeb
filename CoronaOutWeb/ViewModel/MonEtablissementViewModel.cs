using Microsoft.AspNetCore.Http;
using ModelesApi.POC;
using System.Collections.Generic;

namespace CoronaOutWeb.ViewModel
{
    public class MonEtablissementViewModel
    {
        public MonEtablissementViewModel(int nombrePhotos, int tailleMaxImages)
        {
            lTypeEtablissement = new TypeEtablissement().types;
            lPays = new Pays().lPays;
            lJoursSemaines = new JoursSemaine().lJours;
            NombrePhotos = nombrePhotos;
            TailleMaxImages = tailleMaxImages;
            this.Photos = new IFormFile[NombrePhotos];
            this.Etab = new Etablissement();
            this.Etab.lHoraire = new List<Horaire>();
        }

        public MonEtablissementViewModel()
        {
            lTypeEtablissement = new TypeEtablissement().types;
            lPays = new Pays().lPays;
            lJoursSemaines = new JoursSemaine().lJours;
            this.Photos = new IFormFile[NombrePhotos];
            this.Etab = new Etablissement();
            this.Etab.lHoraire = new List<Horaire>();

        }

        public Etablissement Etab { get; set; }

        public List<string> lTypeEtablissement { get; set; }

        public List<string> lPays { get; set; }

        public List<string> lJoursSemaines { get; set; }

        public IFormFile Logo { get; set; }

        public IFormFile[] Photos { get; set; }
        public int NombrePhotos { get; set; }
        public int TailleMaxImages { get; set; }
    }
}
