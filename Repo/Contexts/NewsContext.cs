using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;
using System;

namespace Repo.Contexts
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {
        }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                        .Property(e => e.Id)
                        .IsRequired();

            modelBuilder.Entity<News>()
                .Property(n => n.PublieParUserId)
                .IsRequired();

            modelBuilder.Entity<News>()
                .Property(n => n.DatePublication)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
