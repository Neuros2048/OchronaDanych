using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bankowosc.Server.Entities.EntitiesConfiguration
{
    public class TransationHistoryConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired();
            builder.Property(x => x.Money)
                .HasColumnType("decimal(19,4)")
                .IsRequired();
            
            builder.Property(x => x.Receiver)
                .IsRequired();
            builder.Property(x => x.Sender)
                .IsRequired();

            builder.Property(x => x.AccountNumberReceiver)
                .HasMaxLength(26)
                .IsRequired();
            
            builder.Property(x => x.AccountNumberSender)
                .HasMaxLength(26)
                .IsRequired();
            
            builder.HasOne(x => x.AccountSender)
                .WithMany(x => x.TransactionSend)
                .HasForeignKey(x => x.AcountSenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AccountReceiver)
                .WithMany(x => x.TransactionReceived)
                .HasForeignKey(x => x.AcountReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
