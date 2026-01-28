using Microsoft.EntityFrameworkCore;
using PruebasApiSolid.Domain.Entities;
using PruebasApiSolid.Infrastructure.Persistance;

namespace PruebasApiSolid.Infrastructure
{
    public class AppDataBaseContext: DbContext
    {
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options) { }

        public DbSet<User> users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigurationDataContext());
        }
    }
}
