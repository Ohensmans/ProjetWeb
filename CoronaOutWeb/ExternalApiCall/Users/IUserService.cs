using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Users
{
    public interface IUserService
    {
        Task<List<Utilisateur>> GetAllUserAsync();

        Task<Utilisateur> GetUserAsync(string id);

        Task<Utilisateur> CreateUserAsync(string password, Utilisateur user);

        Task<Utilisateur> UpdateUserAsync(Utilisateur user);

        Task DeleteUserAsync(string id);
    }
}
