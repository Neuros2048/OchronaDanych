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
        public DbSet<CreditCard> Credits { get; set; }
        public DbSet<Acount> Acounts { get; set; }
        public DbSet<TransacionHistory> TransacionHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CreditCardConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransationHistoryConfiguration).Assembly);
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {

        }
    }
}
