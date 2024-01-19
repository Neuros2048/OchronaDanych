using Bankowosc.Server.Entities.EntitiesConfiguration;
using Bankowosc.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bankowosc.Server.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> CreditCredits { get; set; }
        public DbSet<Account> Acounts { get; set; }
        public DbSet<Transaction> TransacionHistory { get; set; }
        public DbSet<BlockAccount> BlockAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CreditCardConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransationHistoryConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlockAccount).Assembly);
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(Seeder.GenerateUsers());
            modelBuilder.Entity<Account>().HasData(Seeder.GenerateAccounts());
            modelBuilder.Entity<CreditCard>().HasData(Seeder.GenerateCreditCards());
        }
    }
}
