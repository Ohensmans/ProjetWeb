
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //pour seeder la bdd 
            /*var host = CreateHostBuilder(args).Build();

            var config = host.Services.GetRequiredService<IConfiguration>();
            var connectionString = config.GetConnectionString("DbUser");
            SeedData.EnsureSeedData(connectionString);
            */

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
