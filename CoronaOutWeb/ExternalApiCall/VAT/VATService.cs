using CoronaOutWeb.Models;
using Microsoft.Extensions.Options;
using ModelesApi.ExternalApi;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.VAT
{
    public class VATService : IVATService
    {
        private readonly string baseUrl;
        private readonly string baseKey;
        private readonly HttpClient _client;


        public VATService(IOptions<BaseUrl> url, IOptions<BaseKey> key)
        {
            _client = Program.client;
            this.baseKey = key.Value.VATApi;
            this.baseUrl = url.Value.VAT;
        }

        public async Task<VATResponseModele> GetVATResponse(String VAT)
        {
            string vatRequest = "vat_number=" + VAT;
            var httpResponse = await _client.GetAsync(this.baseUrl + this.baseKey + vatRequest);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var VATResponseItem = JsonConvert.DeserializeObject<VATResponseModele>(content);

            return VATResponseItem;
        }
    }
}
