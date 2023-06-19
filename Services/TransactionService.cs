
using Core.Entities;
using Services.Interfaces;
using Core.Interfaces;
using Services.Model;
using Core.DTOs;
using AutoMapper;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IMapper _mapper;
        public TransactionService(ITransactionRepository tRepo, IMapper mapper)
        {
            _transactionRepo = tRepo;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Transaction>> CreateTransaction(TransactionDto trans)
        {
            try
            {
                var result = await _transactionRepo.CreateTransaction(trans);

                return new ServiceResponse<Transaction>(result);
            }
            catch(Exception ex)
            {
                return new ServiceResponse<Transaction>(ex);
            }
           
        }

        public async Task<ServiceResponse<IReadOnlyList<Transaction>>> CreateTransactions(List<TransactionDto> transactions)
        {
            try
            {
                 var result = await _transactionRepo.CreateTransactions(transactions);

                return new ServiceResponse<IReadOnlyList<Transaction>>(result);
            }
            catch(Exception ex)
            {
                return new ServiceResponse<IReadOnlyList<Transaction>>(ex);
            }
           

        }

        public Task<ServiceResponse<bool>> DeleteTransaction(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTransactionsRecurringly()
        {
            var result =  await _transactionRepo.DeleteTransactionsOnCondition();
            return result;
        }

        public async Task<ServiceResponse<IReadOnlyList<Transaction>>> GetAllTransactions()
        {
            try
            {
                var result = await _transactionRepo.GetAllTransactions();

                return new ServiceResponse<IReadOnlyList<Transaction>>(result);
            }
            catch(Exception ex)
            {
                return new ServiceResponse<IReadOnlyList<Transaction>>(ex);
            }
            
        }
    }
}