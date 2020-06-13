using CoronaOutWeb.ExternalApiCall.Etablissements;
using CoronaOutWeb.ExternalApiCall.Map;
using CoronaOutWeb.ExternalApiCall.News;
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

        public static void UseServicesNews(this IServiceCollection services)
        {
            services.AddHttpClient<INewsService, NewsService>();
        }

        public static void UseServicesHoraires(this IServiceCollection services)
        {
            services.AddHttpClient<IHoraireService, HoraireService>();
        }

        public static void UseServicesPhotos(this IServiceCollection services)
        {
            services.AddHttpClient<IPhotoService, PhotoService>();
        }

        public static void UseServicesMap(this IServiceCollection services)
        {
            services.AddHttpClient<IMapService, MapService>();
        }


    }
}
