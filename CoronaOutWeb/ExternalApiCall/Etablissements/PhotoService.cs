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
    public class PhotoService : IPhotoService
    {
        private readonly string baseUrl;
        private readonly HttpClient client;

        public PhotoService(IOptions<BaseUrl> url)
        {
            this.baseUrl = url.Value.ApiPhoto;
            this.client = Program.client;

        }

        public async Task<PhotoEtablissement> CreatePhotoAsync(PhotoEtablissement photo, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var content = JsonConvert.SerializeObject(photo);
            var httpResponse = await client.PostAsync(baseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de créer la photo");
            }

            var createdTask = JsonConvert.DeserializeObject<PhotoEtablissement>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeletePhotoAsync(Guid id, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var httpResponse = await client.DeleteAsync($"{baseUrl}{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de supprimer la photo");
            }
        }

        public async Task<List<PhotoEtablissement>> GetAllPhotosAsync()
        {
            var httpResponse = await client.GetAsync(baseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer les établissements");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<List<PhotoEtablissement>>(content);
        }

        public async Task<PhotoEtablissement> GetPhotoAsync(Guid id)
        {
            var httpResponse = await client.GetAsync($"{baseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer la photo");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var photo = JsonConvert.DeserializeObject<PhotoEtablissement>(content);

            return photo;
        }

        public Task<PhotoEtablissement> UpdatePhotoAsync(PhotoEtablissement photo, string idToken)
        {
            throw new NotImplementedException();
        }
    }
}
