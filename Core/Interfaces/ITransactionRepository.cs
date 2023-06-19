using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransaction(Guid id);
        Task<IReadOnlyList<Transaction>> GetAllTransactions();

        Task<Transaction> CreateTransaction(TransactionDto transaction);
        Task<IReadOnlyList<Transaction>> CreateTransactions(List<TransactionDto> transactions);

        Task<bool> DeleteTransactionsOnCondition();
    }
}