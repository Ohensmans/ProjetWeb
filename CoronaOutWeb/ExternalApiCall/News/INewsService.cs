using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelesApi.POC;

namespace CoronaOutWeb.ExternalApiCall.News
{
    public interface INewsService
    {
        Task<List<ModelesApi.POC.News>> GetAllNewsAsync();

        Task<ModelesApi.POC.News> GetNewsAsync(Guid id);

        Task<ModelesApi.POC.News> CreateNewstAsync(ModelesApi.POC.News news, string idToken);

        Task<ModelesApi.POC.News> UpdateNewsAsync(ModelesApi.POC.News news, string idToken);

        Task DeleteNewsAsync(Guid id, string idToken);
    }
}
