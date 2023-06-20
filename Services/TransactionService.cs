
using Core.Entities;
using Services.Interfaces;
using Core.Interfaces;
using Services.Model;
using Core.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TransactionService(ITransactionRepository tRepo, IMerchantRepository mRepo, IMapper mapper, ILogger logger)
        {
            _transactionRepo = tRepo;
            _merchantRepository = mRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<Transaction>> CreateTransaction(TransactionDto trans)
        {
            try
            {
                var result = new Transaction();
                
                switch(trans.TransactionTypeId)
                {
                    case (int)TType.Authorize: result = await _transactionRepo.CreateTransaction(trans); break;
                    case (int)TType.Charge: result = await _transactionRepo.CreateTransaction(trans);break;
                    case (int)TType.Refund: 
                        var previousTrans = await _transactionRepo.GetTransaction(trans.LinkedTransactionId);

                        if(previousTrans == null)
                            throw new Exception("No previous transaction");
                            
                        previousTrans.Status = TransactionStatus.Refunded;
                        result = await _transactionRepo.UpdateTransaction(previousTrans);
                        break;
                    case (int)TType.Reversal:
                        var authTrans = await _transactionRepo.GetTransaction(trans.LinkedTransactionId);
                        if(authTrans == null)
                            throw new Exception("No previous transaction");

                        authTrans.Status = TransactionStatus.Reversed;
                        result = await _transactionRepo.UpdateTransaction(authTrans);break;
                }

                return new ServiceResponse<Transaction>(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in creating transaction");
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
                _logger.LogError(ex, "Error in creating transaction");
                return new ServiceResponse<IReadOnlyList<Transaction>>(ex);
            }
           

        }

        public Task<ServiceResponse<bool>> DeleteTransaction(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> DeleteTransactionsRecurringly()
        {
            try
            {
                var result =  await _transactionRepo.DeleteTransactionsOnCondition();
                return new ServiceResponse<bool>(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in deleting  transaction");
                return new ServiceResponse<bool>(ex);
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
                _logger.LogError(ex, "Error in getting all transactions");
                return new ServiceResponse<IReadOnlyList<Transaction>>(ex);
            }
            
        }

        public async Task<ServiceResponse<bool>> ProcessTransaction(Guid transId)
        {
             try
             {
                var result = await _transactionRepo.ProcessTransaction(transId);

                return new ServiceResponse<bool>(result);
             }
             catch(Exception ex)
             {
                _logger.LogError(ex, "Error in processing transaction");
                return new ServiceResponse<bool>(ex);
             }
        }
    }
}