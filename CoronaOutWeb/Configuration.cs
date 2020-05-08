using CoronaOutWeb.ExternalApiCall.VAT;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace CoronaOutWeb
{
    public static class Configuration
    {
        public static void UseServicesVAT(this IServiceCollection services)
        {
            services.AddHttpClient<IVATService, VATService>();
        }
    }
}
