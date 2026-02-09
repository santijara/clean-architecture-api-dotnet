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
            builder.Property(x => x.Name).HasConversion(name => name.Value, value => new Name(value)).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).HasConversion(email => email.Value, value => new Email(value)).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).HasConversion(password => password.Value, value => new PasswordHash(value)).IsRequired();
            builder.Property(x => x.IsActivate).IsRequired();
        }
    }
}
