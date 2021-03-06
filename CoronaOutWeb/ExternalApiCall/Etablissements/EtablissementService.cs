﻿using CoronaOutWeb.Models;
using Microsoft.Extensions.Options;
using ModelesApi.POC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Etablissements
{
    public class EtablissementService : IEtablissementService
    {
        private readonly string baseUrl;
        private readonly HttpClient client;

        public EtablissementService(IOptions<BaseUrl> url, HttpClient client)
        {
            this.baseUrl = url.Value.ApiEtablissement;
            this.client = client;
            
        }

        public async Task<Etablissement> CreateEtablissementAsync(Etablissement etablissement, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var content = JsonConvert.SerializeObject(etablissement);
            var httpResponse = await client.PostAsync(baseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de créer l'établissement");
            }

            var createdTask = JsonConvert.DeserializeObject<Etablissement>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;

        }

        public async Task DeleteEtablissementAsync(Guid id, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var httpResponse = await client.DeleteAsync($"{baseUrl}{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de supprimer l'établissement");
            }
        }

        public async Task<List<Etablissement>> GetAllEtablissementsAsync()
        {
            var httpResponse = await client.GetAsync(baseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer les établissements");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<List<Etablissement>>(content);
        }

        public async Task<Etablissement> GetEtablissementAsync(Guid id)
        {
            var httpResponse = await client.GetAsync($"{baseUrl}{id}");
            
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer l'établissements");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var etablissement = JsonConvert.DeserializeObject<Etablissement>(content);

            return etablissement;

        }

        public async Task<Etablissement> UpdateEtablissementAsync(Etablissement etablissement, string idToken)
        {

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var content = JsonConvert.SerializeObject(etablissement);

            var httpResponse = await client.PutAsync($"{baseUrl}{etablissement.Id}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de modifier l'établissement");
            }

            var createdTask = JsonConvert.DeserializeObject<Etablissement>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
            
        }
    }
}
