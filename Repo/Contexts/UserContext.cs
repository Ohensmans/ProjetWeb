using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repo.Contexts
{
    public class UserContext : IdentityDbContext<Utilisateur>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utilisateur>()
                        .Property(u => u.Nom)
                        .IsRequired()
                        .HasMaxLength(50);
           
            modelBuilder.Entity<Utilisateur>()
                        .Property(u => u.Prenom)
                        .IsRequired()
                        .HasMaxLength(50);

            modelBuilder.Entity<Utilisateur>()
                        .Property(u => u.UserName)
                        .IsRequired()
                        .HasMaxLength(255);

            modelBuilder.Entity<Utilisateur>()
                        .Property(u => u.PhoneNumber)
                        .HasMaxLength(25);

            modelBuilder.Entity<Utilisateur>()
                        .Property(u => u.Sexe)
                        .IsRequired();
           
            modelBuilder.Entity<Utilisateur>()
                        .Property(u => u.DateNaissance)
                        .IsRequired();

            modelBuilder.Entity<Utilisateur>()
                        .Property(u => u.estProfessionel)
                        .IsRequired();
        }
    }
}
