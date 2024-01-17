using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Bankowosc.Server.Entities.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ClientNumber)
                .IsUnique();
            builder.Property(p => p.Email)
            .IsRequired();
            
            builder.Property(p => p.PhoneNumber)
                .IsRequired();
            
            builder.Property(p => p.ClientNumber)
                .IsRequired();

            builder.Property(p => p.PasswordHash)
            .IsRequired();

            builder.Property(p => p.PasswordSalt)
            .IsRequired();
            
            builder.Property(p => p.PeselSalt)
                .IsRequired();
            
            builder.Property(p => p.PasswordHash)
                .IsRequired();

            builder.Property(p => p.Role)
                .IsRequired();

            builder.Property(p => p.Username)
                .IsRequired();

            builder.Property(p => p.DateCreated)
                .IsRequired();
        }
    }
}
