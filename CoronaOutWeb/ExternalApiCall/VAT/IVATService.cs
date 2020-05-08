using ModelesApi.ExternalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.VAT
{
    public interface IVATService
    {
        Task<VATResponseModele> GetVATResponse(string VAT);
    }
}
