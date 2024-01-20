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
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(x => x.Iv)
                .HasColumnType("varbinary(16)")
                .IsRequired();

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(60)
            .IsRequired();
            
            builder.Property(p => p.Pesel)
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
