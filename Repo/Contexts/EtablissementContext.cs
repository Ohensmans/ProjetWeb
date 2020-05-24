using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;
using System;

namespace Repo.Contexts
{
    public class EtablissementContext : DbContext
    {

        public EtablissementContext(DbContextOptions<EtablissementContext> options) : base(options)
        {
        }

        public DbSet<Etablissement> Etablissements { get; set; }
        public DbSet<Horaire> Horaires { get; set; }
        public DbSet<PhotoEtablissement> PhotosEtablissement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etablissement>()
                        .Property(e => e.Id)
                        .ValueGeneratedOnAdd()
                        .IsRequired();

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.Type)
                .IsRequired();

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.NumeroTva)
                .IsRequired();

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.AdresseEmailPro)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.ZoneTexteLibre)
                .HasMaxLength(2000);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.CodePostal)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.Ville)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.Pays)
                .IsRequired();

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.Rue)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.NumeroBoite)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.NumeroTelephone)
                .HasMaxLength(25);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.AdresseEmailEtablissement)
                .HasMaxLength(255);
           
            modelBuilder.Entity<Etablissement>()
                .HasMany<Horaire>(e => e.lHoraire)
                .WithOne(h => h.Etablissement)
                //supprime les enfants si l'établissement est supprimé
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Etablissement>()
                .HasMany<PhotoEtablissement>(e => e.lPhotos)
                .WithOne(pe => pe.Etablissement)
                //supprime les enfants si l'établissement est supprimé
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.PublieParUserId)
                .IsRequired();

            modelBuilder.Entity<Etablissement>()
                .Property(e => e.DatePublication)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            modelBuilder.Entity<Horaire>()
                .Property(h => h.Id)
                .IsRequired();

            modelBuilder.Entity<PhotoEtablissement>()
                .Property(pe => pe.Id)
                .IsRequired();

        }
    }
}
