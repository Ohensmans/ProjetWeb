using ModelesApi.POC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;
        private const string BaseUrl = "https://localhost:5001/User/";

        public UserService()
        {
            this.client = Program.client;
        }


        public async Task<Utilisateur> CreateUserAsync(string password, Utilisateur user)
        {
            var content = JsonConvert.SerializeObject(user);
            var httpResponse = await client.PostAsync($"{BaseUrl}PostUser//{password}", new StringContent(content, Encoding.Default, "application/json"));

            if (httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de rajouter l'utilisateur");
            }

            var createdTask = JsonConvert.DeserializeObject<Utilisateur>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeleteUserAsync(string id)
        {
            var httpResponse = await client.DeleteAsync($"{BaseUrl}DeleteUser//{id}");
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de supprimer cet utilisateur");
            }
        }

        public async Task<List<Utilisateur>> GetAllUserAsync()
        {
            var httpResponse = await client.GetAsync($"{BaseUrl}GetAllUser");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer les utilisateurs");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Utilisateur>>(content);

            return tasks;

        }

        public async Task<Utilisateur> GetUserAsync(string id)
        {
            var httpResponse = await client.GetAsync($"{BaseUrl}GetUser//{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer l'utilisateur");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Utilisateur>(content);

            return user;
        }

        public async Task<Utilisateur> UpdateUserAsync(Utilisateur user)
        {
            var content = JsonConvert.SerializeObject(user);
            var httpResponse = await client.PutAsync($"{BaseUrl}PutUser//", new StringContent(content, Encoding.Default, "application/json"));
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de mettre à jour l'utilisateur");
            }

            var createdTask = JsonConvert.DeserializeObject<Utilisateur>(await httpResponse.Content.ReadAsStringAsync());

            return createdTask;
        }
    }
}
