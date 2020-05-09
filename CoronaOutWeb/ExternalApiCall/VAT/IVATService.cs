using Microsoft.Extensions.Configuration;
using ModelesApi.ExternalApi;
using System.Threading.Tasks;

namespace CoronaOutWeb.ExternalApiCall.VAT
{
    public interface IVATService
    {

        Task<VATResponseModele> GetVATResponse(string VAT);
    }
}
