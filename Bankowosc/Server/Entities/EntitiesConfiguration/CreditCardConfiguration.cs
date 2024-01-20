using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankowosc.Server.Entities.EntitiesConfiguration
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.Id);
          
            builder.Property(x => x.Numbers)
                .IsRequired();
            builder.Property(x => x.SpecialNumber)
                .IsRequired();
            builder.Property(x => x.EndDate)
                .IsRequired();
            builder.Property(x => x.Iv)
                .HasColumnType("varbinary(16)")
                .IsRequired();
            builder.Property(x => x.Pin)
                .IsRequired();
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasOne(x => x.Account)
                .WithOne(x => x.CreditCard)
                .HasForeignKey<CreditCard>(x => x.AcountId);
        }
    }
}
