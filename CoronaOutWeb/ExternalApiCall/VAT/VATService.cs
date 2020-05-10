using Microsoft.Extensions.Configuration;
using ModelesApi.ExternalApi;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.VAT
{
    public class VATService : IVATService
    {
        private const string baseUrl = "apilayer.net/api/validate";
        private readonly HttpClient _client;

        public string apiKey { get; set; }

        public VATService()
        {
            _client = Program.client;
            //this.apiKey = config.GetConnectionString("VATApi");
            this.apiKey = "?access_key=e69175a478f42ba9c0dff7a8285c4d1b";
        }

        public async Task<VATResponseModele> GetVATResponse(String VAT)
        {
            string vatRequest = "vat_number=" + VAT;
            var httpResponse = await _client.GetAsync(baseUrl + this.apiKey + vatRequest);

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
