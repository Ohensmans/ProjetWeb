using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;

namespace Repo.Contexts
{
    public class UtilisateurContext : DbContext
    {
        public UtilisateurContext(DbContextOptions<UtilisateurContext> options) : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

    }
}

