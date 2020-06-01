using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;


namespace CoronaOutWeb.ViewModel
{
    public class EditImagesViewModel
    {
        public EditImagesViewModel(int nombrePhotos, int tailleMaxImages, Guid etablissementId)
        {
            this.Photos = new PhotoGeneriqueViewModel[nombrePhotos];
            for (int i = 0; i < nombrePhotos; i++)
            {
                Photos[i] = new PhotoGeneriqueViewModel();
            }
            NombrePhotos = nombrePhotos;
            TailleMaxImages = tailleMaxImages;
            EtablissementId = etablissementId;
            lPathImages = new List<PhotoGeneriqueViewModel>();
        }

        public EditImagesViewModel()
        {
            this.Photos = new PhotoGeneriqueViewModel[NombrePhotos];
            for (int i = 0; i < NombrePhotos; i++)
            {
                Photos[i] = new PhotoGeneriqueViewModel();
            }
        }

        public Guid EtablissementId { get; set; }

        public int NombrePhotos { get; set; }
        public int TailleMaxImages { get; set; }

        public IFormFile Logo { get; set; }

        public PhotoGeneriqueViewModel[] Photos { get; set; }

        public List<PhotoGeneriqueViewModel> lPathImages { get; set; }

        public string PathLogo { get; set; }
    }
}
