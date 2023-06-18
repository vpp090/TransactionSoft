using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransaction(Guid id);
        Task<IReadOnlyList<Transaction>> GetAllTransactions();

        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<IReadOnlyList<Transaction>> CreateTransactions(List<Transaction> transactions);
    }
}