using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankowosc.Server.Entities.EntitiesConfiguration
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Numbers)
                .IsUnique();
            builder.Property(x => x.Numbers)
                .HasMaxLength(12)
                .IsRequired();
            builder.Property(x => x.SpecialNumber)
                .HasMaxLength(3)
                .IsRequired();
            builder.Property(x => x.EndDate)
                .HasMaxLength(4)
                .IsRequired();

            builder.HasOne(x => x.Account)
                .WithOne(x => x.CreditCard)
                .HasForeignKey<CreditCard>(x => x.AcountId);
        }
    }
}
