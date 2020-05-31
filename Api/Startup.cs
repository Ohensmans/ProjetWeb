using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repo.Contexts;
using System.Linq;
using System.Reflection;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddControllers();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<EtablissementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbEtablissement"), sql => sql.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<NewsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbNews"), sql => sql.MigrationsAssembly(migrationsAssembly)));

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "http://localhost:5001";
                        options.RequireHttpsMetadata = false;
                        options.Audience = "Api";
                    });
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Services", Version = "v1" });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //InitializeDatabase(app);
            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Services v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<EtablissementContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<EtablissementContext>();
                context.Database.Migrate();

                if (!context.Etablissements.ToList().Any())
                {
                    foreach (var client in Config.Etablissements)
                    {
                        context.Etablissements.Add(client);
                    }
                    context.SaveChanges();
                }

            }
        }
    }
}
