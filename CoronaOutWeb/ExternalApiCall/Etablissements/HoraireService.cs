

using CoronaOutWeb.Models;
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
    public class HoraireService : IHoraireService
    {

        private readonly string baseUrl;
        private readonly HttpClient client;

        public HoraireService(IOptions<BaseUrl> url)
        {
            this.baseUrl = url.Value.ApiHoraire;
            this.client = Program.client;

        }

        public async Task<Horaire> CreateHoraireAsync(Horaire horaire, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var content = JsonConvert.SerializeObject(horaire);
            var httpResponse = await client.PostAsync(baseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de créer l'horaire");
            }

            var createdTask = JsonConvert.DeserializeObject<Horaire>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public Task DeleteHoraireAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Horaire>> GetAllHorairesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Horaire> GetHoraireAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Horaire> UpdateHoraireAsync(Horaire horaire, string idToken)
        {
            throw new NotImplementedException();
        }
    }
}
