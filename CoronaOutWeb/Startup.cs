using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using CoronaOutWeb.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelesApi.POC;
using Repo.Contexts;

namespace CoronaOutWeb
{
    public class Startup
    {
        protected readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                    .AddFluentValidation();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "cookie";
            })
                    .AddCookie("cookie")
                    .AddOpenIdConnect("oidc", options =>
                    {
                        options.Authority = "https://localhost:57582/";
                        options.ClientId = "openIdConnectClient";
                        options.SignInScheme = "cookie";
                    });

            services.UseServicesVAT();
            services.AddTransient<IValidator<Utilisateur>, UtilisateurValidator>();
            services.AddTransient<IValidator<Etablissement>, EtablissementValidator>();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<EtablissementContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbEtablissement"), sql => sql.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<NewsContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbNews"),sql => sql.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbUser"),sql => sql.MigrationsAssembly(migrationsAssembly)));
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
            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
