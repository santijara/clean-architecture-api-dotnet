using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebasApiSolid.Domain.Entities;

namespace PruebasApiSolid.Infrastructure.Persistance
{
    public class ConfigurationDataContext: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("UsuariosPrueba");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.IsActivate).IsRequired();
        }
    }
}
