using ModelesApi.POC;
using System.Data.Entity;

namespace Repo.Contexts
{
    public class UtilisateurContext
    {
        public UtilisateurContext() : base()
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

    }
}

