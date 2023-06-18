
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
                var transaction = _mapper.Map<Transaction>(trans);
                var result = await _transactionRepo.CreateTransaction(transaction);

                return new ServiceResponse<Transaction>(result);
            }
            catch(Exception ex)
            {
                return new ServiceResponse<Transaction>(ex);
            }
           
        }

        public async Task<ServiceResponse<IReadOnlyList<Transaction>>> CreateTransactions(List<Transaction> transactions)
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