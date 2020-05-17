using CoronaOutWeb.ExternalApiCall.Users;
using CoronaOutWeb.ExternalApiCall.VAT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoronaOutWeb
{
    public static class Configuration
    {
        public static void UseServicesVAT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IVATService, VATService>(x => x.BaseAddress = new Uri(configuration.GetConnectionString("VATUrl")));
        }

        public static void UseServicesUser(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IUserService, UserService>(x => x.BaseAddress = new Uri(configuration.GetConnectionString("UserUrl")));
        }
    }
}
