using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Etablissements
{
    public interface IPhotoService
    {
        Task<List<PhotoEtablissement>> GetAllPhotosAsync();

        Task<PhotoEtablissement> GetPhotoAsync(Guid id);

        Task<PhotoEtablissement> CreatePhotoAsync(PhotoEtablissement photo, string idToken);

        Task<PhotoEtablissement> UpdatePhotoAsync(PhotoEtablissement photo, string idToken);

        Task DeletePhotoAsync(Guid id);
    }
}
