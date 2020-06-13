using CoronaOutWeb.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Map
{
    public class MapService : IMapService
    {
        private readonly string baseUrl;
        private readonly HttpClient _client;
        private readonly string baseKey;
        private readonly string baseParam;

        public MapService(IOptions<BaseUrl> url, IOptions<BaseKey> key, IOptions<BaseParams> param, HttpClient client)
        {
            _client = client;
            this.baseUrl = url.Value.MapQuest;
            this.baseKey = key.Value.MapQuest;
            this.baseParam = param.Value.MapQuest;
        }

        public async Task<Marker> GetCoordinates(string adresse)
        {
            var key = "key=" + baseKey;
            var location = "&location=" + adresse;

            var content = baseUrl + key + location + baseParam;

            var httpResponse = await _client.GetAsync(content);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Impossible de récupérer les coordonnées");
            }

            var response = await httpResponse.Content.ReadAsStringAsync();

            var oMycustomclassname = JsonConvert.DeserializeObject<dynamic>(response);

            Marker marker = new Marker();
            marker.Latitude = oMycustomclassname.results[0].locations[0].displayLatLng.lat;
            marker.Longitude = oMycustomclassname.results[0].locations[0].displayLatLng.lng;

            return marker;
        }

    }
}
