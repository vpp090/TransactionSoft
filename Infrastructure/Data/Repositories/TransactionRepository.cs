using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private DataContext _context;
        private IMapper _mapper;
        public TransactionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Transaction> CreateTransaction(TransactionDto trans)
        {
            var transaction = _mapper.Map<Transaction>(trans);

            var merch = await _context.Merchants.Include(m => m.Transactions).FirstOrDefaultAsync(m => m.Id == trans.MerchantId);
            var transType = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Id == trans.TransactionTypeId);

            if(merch == null)
                throw new Exception("Merchant not found");
            
            if(transType == null)
                throw new Exception("Transaction Type not found");
        
            transaction.Merchant = merch;
            transaction.TransactionType = transType;
            merch.Transactions.Add(transaction);

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            var result = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transaction.Id);

            return result;
        }

        public async Task<IReadOnlyList<Transaction>> CreateTransactions(List<TransactionDto> trans)
        {
            var transactions = _mapper.Map<List<Transaction>>(trans);

            await _context.Transactions.AddRangeAsync(transactions);
            await _context.SaveChangesAsync();

            return transactions;
        }

        public async Task<bool> DeleteTransactionsOnCondition()
        {
            var date = DateTime.Now.AddHours(-1);
            var transactions = await _context.Transactions.Where(t => t.CreatedDate < date).ToListAsync();

            _context.Transactions.RemoveRange(transactions);

            await _context.SaveChangesAsync();

            return true;
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