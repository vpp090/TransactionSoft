
using Core.DTOs;
using Core.Entities;
using Services.Model;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
    
        Task<ServiceResponse<IReadOnlyList<Transaction>>> GetAllTransactions();
        Task<ServiceResponse<Transaction>> CreateTransaction(TransactionDto transaction);
        Task<ServiceResponse<IReadOnlyList<Transaction>>> CreateTransactions(List<Transaction> transactions);
        
    }
}