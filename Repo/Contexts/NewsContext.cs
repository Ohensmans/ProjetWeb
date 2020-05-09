using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;

namespace Repo.Contexts
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {
        }
        public DbSet<News> News { get; set; }

    }
}
