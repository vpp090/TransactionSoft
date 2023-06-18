using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private DataContext _context;
        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {

            
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            var result = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transaction.Id);

            return result;
        }

        public async Task<IReadOnlyList<Transaction>> CreateTransactions(List<Transaction> transactions)
        {
            _context.Transactions.AddRange(transactions);
            await _context.SaveChangesAsync();

            return transactions;
        }

        public async Task<IReadOnlyList<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransaction(Guid id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}