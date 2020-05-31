using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Etablissements
{
    public interface IHoraireService
    {
        Task<List<Horaire>> GetAllHorairesAsync();

        Task<Horaire> GetHoraireAsync(Guid id);

        Task<Horaire> CreateHoraireAsync(Horaire horaire, string idToken);

        Task<Horaire> UpdateHoraireAsync(Horaire horaire, string idToken);

        Task DeleteHoraireAsync(Guid id);


    }
}
