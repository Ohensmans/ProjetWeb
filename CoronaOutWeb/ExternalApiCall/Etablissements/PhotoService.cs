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

        public Task DeletePhotoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PhotoEtablissement>> GetAllPhotosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PhotoEtablissement> GetPhotoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PhotoEtablissement> UpdatePhotoAsync(PhotoEtablissement photo, string idToken)
        {
            throw new NotImplementedException();
        }
    }
}
