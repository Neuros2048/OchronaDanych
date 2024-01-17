using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankowosc.Server.Entities.EntitiesConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.AccountNumber)
                .IsUnique();
            builder.Property(x => x.Money)
                .HasColumnType("decimal(19,4)")
                .IsRequired();
            
            builder.Property(p => p.AccountNumber)
                .HasMaxLength(26)
                .IsRequired();


            builder.HasOne(x => x.User)
                .WithOne(x => x.Account)
                .HasForeignKey<Account>(x => x.UserId);
            
        }
    }
}
