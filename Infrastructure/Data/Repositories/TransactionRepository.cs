using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private DataContext _context;
        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        
    }
}