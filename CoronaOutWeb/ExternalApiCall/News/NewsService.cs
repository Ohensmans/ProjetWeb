

using CoronaOutWeb.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.News
{
    public class NewsService : INewsService
    {

        private readonly string baseUrl;
        private readonly HttpClient client;

        public NewsService(IOptions<BaseUrl> url)
        {
            this.baseUrl = url.Value.ApiNews;
            this.client = Program.client;
        }

        public async Task<ModelesApi.POC.News> CreateNewstAsync(ModelesApi.POC.News news, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var content = JsonConvert.SerializeObject(news);
            var httpResponse = await client.PostAsync(baseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de créer la news");
            }

            var createdTask = JsonConvert.DeserializeObject<ModelesApi.POC.News>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeleteNewsAsync(Guid id, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var httpResponse = await client.DeleteAsync($"{baseUrl}{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de supprimer la news");
            }
        }

        public async Task<List<ModelesApi.POC.News>> GetAllNewsAsync()
        {
            var httpResponse = await client.GetAsync(baseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer les news");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<List<ModelesApi.POC.News>>(content);
        }

        public async Task<ModelesApi.POC.News> GetNewsAsync(Guid id)
        {
            var httpResponse = await client.GetAsync($"{baseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer la news");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var news = JsonConvert.DeserializeObject<ModelesApi.POC.News>(content);

            return news;
        }

        public async Task<ModelesApi.POC.News> UpdateNewsAsync(ModelesApi.POC.News news, string idToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var content = JsonConvert.SerializeObject(news);

            var httpResponse = await client.PutAsync($"{baseUrl}{news.Id}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de modifier la news");
            }

            var createdTask = JsonConvert.DeserializeObject<ModelesApi.POC.News>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }
    }
}
