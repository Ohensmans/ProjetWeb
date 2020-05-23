
using CoronaOutWeb.ExternalApiCall.Users;
using CoronaOutWeb.Models;
using CoronaOutWeb.Validator;
using CoronaOutWeb.ViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddControllersWithViews();

            services.AddMvc(options => options.EnableEndpointRouting = false)
                    .AddFluentValidation();

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

                        options.Scope.Add("Api");
                        options.Scope.Add("ApiExterne");
                    });

            
            

            services.UseServicesVAT(Configuration);
            services.UseServicesUser(Configuration);
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IValidator<Utilisateur>, UtilisateurValidator>();
            services.AddTransient<IValidator<Etablissement>, EtablissementValidator>();
            services.AddTransient<IValidator<CreateRoleViewModel>, CreateRoleValidator>();
            services.AddTransient<IValidator<EditRoleViewModel>, EditRoleValidator>();

            IConfigurationSection sec = Configuration.GetSection("BaseUrl");
            services.Configure<BaseUrl>(sec);

            /*
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<EtablissementContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbEtablissement"), sql => sql.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<NewsContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbNews"),sql => sql.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbUser"),sql => sql.MigrationsAssembly(migrationsAssembly)));
            
            services.AddIdentity<Utilisateur, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();
            */
                
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
