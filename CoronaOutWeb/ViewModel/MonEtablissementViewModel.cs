using Microsoft.AspNetCore.Http;
using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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
        }

        public Etablissement Etab { get; set; }

        public List<string> lTypeEtablissement { get; set; }

        public List<string> lPays { get; set; }

        public List<string> lJoursSemaines { get; set; }

        public IFormFile Logo { get; set; }

        public IFormFile[] Photos { get; set; }
        public int NombrePhotos { get; set; }
        public int TailleMaxImages { get; }
    }
}
