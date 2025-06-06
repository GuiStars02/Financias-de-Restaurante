using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data.EntitiesConfiguration;
using RestauranteAPI.Data.Models;

namespace RestauranteAPI.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Prato> Prato { get; set; }
        public DbSet<CategoriaPrato> CategoriaPrato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PratoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaPratoConfiguration());
        }
    }
}