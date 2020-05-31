using Microsoft.AspNetCore.Http;
using ModelesApi.POC;
using System.Collections.Generic;

namespace CoronaOutWeb.ViewModel
{
    public class CreateEtablissementViewModel
    {
        public CreateEtablissementViewModel(int nombrePhotos, int tailleMaxImages)
        {
            lTypeEtablissement = new TypeEtablissement().types;
            lPays = new Pays().lPays;
            lJoursSemaines = new JoursSemaine().lJours;
            NombrePhotos = nombrePhotos;
            TailleMaxImages = tailleMaxImages;
            this.Etab = new Etablissement();
            this.lHoraire = new List<Horaire>();

            this.Photos = new PhotoGeneriqueViewModel[NombrePhotos];
            for (int i = 0; i< NombrePhotos; i++)
            {
                Photos[i] = new PhotoGeneriqueViewModel();
            }
        }

        public CreateEtablissementViewModel()
        {
            lTypeEtablissement = new TypeEtablissement().types;
            lPays = new Pays().lPays;
            lJoursSemaines = new JoursSemaine().lJours;
            this.Etab = new Etablissement();
            this.lHoraire = new List<Horaire>();

            this.Photos = new PhotoGeneriqueViewModel[NombrePhotos];
            for (int i = 0; i < NombrePhotos; i++)
            {
                Photos[i] = new PhotoGeneriqueViewModel();
            }

        }

        public Etablissement Etab { get; set; }

        public List<string> lTypeEtablissement { get; set; }

        public List<string> lPays { get; set; }

        public List<string> lJoursSemaines { get; set; }

        public IFormFile Logo { get; set; }

        public PhotoGeneriqueViewModel[] Photos { get; set; }

        public List<Horaire> lHoraire { get; set; }
        public int NombrePhotos { get; set; }
        public int TailleMaxImages { get; set; }
    }
}
