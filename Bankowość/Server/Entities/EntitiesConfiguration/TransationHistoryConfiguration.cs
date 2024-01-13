using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankowość.Server.Entities.EntitiesConfiguration
{
    public class TransationHistoryConfiguration : IEntityTypeConfiguration<TransacionHistory>
    {
        public void Configure(EntityTypeBuilder<TransacionHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired();
        }
    }
}
