using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankowosc.Server.Entities.EntitiesConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Acount>
    {
        public void Configure(EntityTypeBuilder<Acount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.money)
                .IsRequired();
        }
    }
}
