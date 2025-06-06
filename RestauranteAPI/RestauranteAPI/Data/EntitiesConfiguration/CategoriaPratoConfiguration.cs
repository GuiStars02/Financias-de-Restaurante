using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteAPI.Data.Models;

namespace RestauranteAPI.Data.EntitiesConfiguration
{
    public class CategoriaPratoConfiguration : IEntityTypeConfiguration<CategoriaPrato>
    {
        public void Configure(EntityTypeBuilder<CategoriaPrato> builder)
        {
            builder.HasKey(x => x.IdCategoriaPrato);
            builder.Property(x => x.DescricaoCategoria).HasMaxLength(255);
        }
    }
}
