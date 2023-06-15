
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<AuthorizeTransaction> AuthorizeTransactions {get; set;}
        public DbSet<ChargeTransaction> ChargeTransaction {get; set;}
        public DbSet<RefundTransaction> RefundTransaction {get; set;}
        public DbSet<ReversalTransaction> ReversalTransactions {get; set;}
        public DbSet<Merchant> Merchants {get; set;}
    }
}