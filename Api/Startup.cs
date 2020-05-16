using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repo.Contexts;
using System.Reflection;

namespace Api
{
    public class Startup
    {

        protected readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<EtablissementContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbEtablissement"), sql => sql.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<NewsContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DbNews"), sql => sql.MigrationsAssembly(migrationsAssembly)));

            services.AddAuthentication(defaultScheme: "Bearer")
                .AddIdentityServerAuthentication(authenticationScheme: "Bearer", configureOptions: options =>
        {
            options.Authority = "http://localhost:5001";
            options.RequireHttpsMetadata = false;
            options.ApiName = "Api";
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
