
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<TransactionType> TransactionTypes {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
        public DbSet<Merchant> Merchants {get; set;}
    }
}