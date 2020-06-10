
using CoronaOutWeb.ExternalApiCall.Etablissements;
using CoronaOutWeb.ExternalApiCall.Map;
using CoronaOutWeb.ExternalApiCall.News;
using CoronaOutWeb.ExternalApiCall.VAT;
using CoronaOutWeb.Models;
using CoronaOutWeb.Validator;
using CoronaOutWeb.ViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ModelesApi.POC;
using System.IdentityModel.Tokens.Jwt;

namespace CoronaOutWeb
{
    public class Startup
    {
        protected readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options => options.EnableEndpointRouting = false)
                    .AddFluentValidation();

            services.AddControllersWithViews();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                    .AddCookie("Cookies")
                    .AddOpenIdConnect("oidc", options =>
                    {
                        options.SignInScheme = "Cookies";

                        options.Authority = "http://localhost:5001";
                        options.RequireHttpsMetadata = false;
                        
                        options.ResponseType = "code id_token";
                        options.GetClaimsFromUserInfoEndpoint = true;

                        options.ClientId = "CoronaOutWeb";
                        options.ClientSecret = "secret" ;
                        options.SaveTokens = true;

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            NameClaimType = "name",
                            RoleClaimType = "role"
                        };

                        options.Scope.Add("Api");
                        options.Scope.Add("ApiExterne");
                        options.Scope.Add("role");



                        //options.ClaimActions.Add(new JsonKeyClaimAction("role", "role", "role"));
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("role", "Administrateur"));
                options.AddPolicy("Gestio", policy => policy.RequireClaim("role", "Gestionnaire"));
                options.AddPolicy("Modificateur", policy => policy.RequireClaim("role", "Gestionnaire", "Administrateur"));
            });
            

            services.UseServicesVAT();
            services.UseServicesEtablissements();
            services.AddTransient<IVATService, VATService>();
            services.AddTransient<IEtablissementService, EtablissementService>();
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IHoraireService, HoraireService>();
            services.AddTransient<IMapService, MapService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IValidator<Horaire>, HoraireValidator>();
            services.AddTransient<IValidator<Etablissement>, EtablissementValidator>();
            services.AddTransient<IValidator<News>, NewsValidator>();
            services.AddTransient<IValidator<CreateEtablissementViewModel>, MonEtablissementViewValidator>();
            services.AddTransient<IValidator<CreateNewsViewModel>, CreateNewsViewModelValidator>();

            services.Configure<BaseUrl>(Configuration.GetSection("BaseUrl"));
            services.Configure<BaseKey>(Configuration.GetSection("ApiKey"));
            services.Configure<BaseParams>(Configuration.GetSection("ParamsApi"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();
        }

    }
}
