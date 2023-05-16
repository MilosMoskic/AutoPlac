using AutoPlac.Modeli.Modeli;
using Microsoft.EntityFrameworkCore;

namespace AutoPlac.Repozitorijumi.Context
{
    public class AutoPlacDBContext : DbContext
    {
        public AutoPlacDBContext()
        {

        }
        public AutoPlacDBContext(DbContextOptions<AutoPlacDBContext> options) : base(options)
        {
        }
        public DbSet<Automobil> Automobil => Set<Automobil>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=DESKTOP-N2RL0HN;Database=AutoPlac;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;");

    }
}

