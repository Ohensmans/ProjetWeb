using ModelesApi.POC;
using System.Data.Entity;


namespace Repo.Contexts
{
    public class EtablissementContext : DbContext
    {
        public EtablissementContext() : base()
        {

        }

        public DbSet<Etablissement> Etablissements { get; set; }
        public DbSet<Horaire> Horaires { get; set; }
        public DbSet<PhotoEtablissement> PhotosEtablissement { get; set; }

    }
}
