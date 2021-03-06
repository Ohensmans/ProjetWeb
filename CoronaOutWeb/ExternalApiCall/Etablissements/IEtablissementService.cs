﻿using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Etablissements
{
    public interface IEtablissementService
    {
        Task<List<Etablissement>> GetAllEtablissementsAsync();

        Task<Etablissement> GetEtablissementAsync(Guid id);

        Task<Etablissement> CreateEtablissementAsync(Etablissement etablissement, string idToken);

        Task<Etablissement> UpdateEtablissementAsync(Etablissement etablissement, string idToken);

        Task DeleteEtablissementAsync(Guid id, string idToken);

    }
}
