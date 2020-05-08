﻿using CoronaOutWeb.ExternalApiCall.VAT;
using Microsoft.Extensions.DependencyInjection;


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
