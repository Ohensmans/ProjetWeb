using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModelesApi.POC;
using Repo.Contexts;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<UserContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<Utilisateur, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UserContext>();
                    context.Database.Migrate();

                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var admin = roleMgr.FindByNameAsync("Administrateur").Result;
                    if (admin == null)
                    {
                        admin = new IdentityRole
                        {
                            Name = "Administrateur"
                        };
                        var result = roleMgr.CreateAsync(admin).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("admin created");
                    }
                    else
                    {
                        Log.Debug("admin already exists");
                    }

                    var gest = roleMgr.FindByNameAsync("Gestionnaire").Result;
                    if (gest == null)
                    {
                        gest = new IdentityRole
                        {
                            Name = "Gestionnaire"
                        };
                        var result = roleMgr.CreateAsync(gest).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("gestionnaire created");
                    }
                    else
                    {
                        Log.Debug("gestionnaire already exists");
                    }

                    var user = roleMgr.FindByNameAsync("Utilisateur").Result;
                    if (user == null)
                    {
                        user = new IdentityRole
                        {
                            Name = "Utilisateur"
                        };
                        var result = roleMgr.CreateAsync(user).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("Utilisateur created");
                    }
                    else
                    {
                        Log.Debug("Utilisateur already exists");
                    }



                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<Utilisateur>>();
                    var alice = userMgr.FindByNameAsync("alice@merveille.be").Result;
                    if (alice == null)
                    {
                        alice = new Utilisateur
                        {
                            UserName = "alice@merveille.be",
                            Nom = "Merveille",
                            Prenom = "Alice",
                            Sexe = "Femme",
                            PhoneNumber = "010123456",
                            DateNaissance = new DateTime(1920, 10, 1),
                            estProfessionel = false

                        };
                        var result = userMgr.CreateAsync(alice, "Ephec*1234").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("alice created");
                    }
                    else
                    {
                        Log.Debug("alice already exists");
                    }

                    var robinson = userMgr.FindByNameAsync("robinson@crusoe.be").Result;
                    if (robinson == null)
                    {
                        robinson = new Utilisateur
                        {
                            UserName = "robinson@crusoe.be",
                            Nom = "Crusoé",
                            Prenom = "Robinson",
                            Sexe = "Femme",
                            PhoneNumber = "010123456",
                            DateNaissance = new DateTime(1920, 10, 1),
                            estProfessionel = false

                        };
                        var result = userMgr.CreateAsync(robinson, "Ephec*1234").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("robinson created");
                    }
                    else
                    {
                        Log.Debug("robinson already exists");
                    }
                }
            }

        }
    }
}
