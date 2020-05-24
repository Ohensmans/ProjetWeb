using CoronaOutWeb.ExternalApiCall.Etablissements;
using CoronaOutWeb.ExternalApiCall.VAT;
using Microsoft.Extensions.DependencyInjection;


namespace CoronaOutWeb
{
    public static class Configuration
    {
        public static void UseServicesVAT(this IServiceCollection services)
        {
            services.AddHttpClient<IVATService, VATService>();
        }

        public static void UseServicesEtablissements(this IServiceCollection services)
        {
            services.AddHttpClient<IEtablissementService, EtablissementService>();
        }

    }
}
