using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankowosc.Server.Entities.EntitiesConfiguration;

public class BlockAccountConfiguration : IEntityTypeConfiguration<BlockAccount>
{
    public void Configure(EntityTypeBuilder<BlockAccount> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.UserNumber)
            .IsUnique();
            
        builder.Property(x => x.LastLogin)
            .IsRequired();
        builder.Property(x => x.LoginAttempts)
            .IsRequired();
        builder.Property(x => x.UserNumber)
            .IsRequired()
            .HasMaxLength(10);
    }
}