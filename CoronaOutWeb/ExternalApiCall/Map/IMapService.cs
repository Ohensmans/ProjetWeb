using CoronaOutWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.Map
{
    public interface IMapService
    {
        Task<Marker> GetCoordinates (string adresse);
    }
}
