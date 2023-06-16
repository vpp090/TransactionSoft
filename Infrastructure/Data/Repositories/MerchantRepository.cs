using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private DataContext _context;
        public MerchantRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Merchant> GetMerchantById(int id)
        {
            var merchant = await _context.Merchants.FindAsync(id);

            if(merchant == null)
               throw new ArgumentException("Merchant not found");

            return merchant;
        }

        public async Task<IReadOnlyList<Merchant>> GetMerchants()
        {
            var merchants = await _context.Merchants.ToListAsync();

            if(merchants == null)
                throw new ArgumentException("Merchants not found");

            return merchants;
        }

        
        public async Task<IReadOnlyList<Merchant>> CreateMerchants(List<Merchant> merchants)
        {
            await _context.Merchants.AddRangeAsync(merchants);
            await _context.SaveChangesAsync();

            return merchants;

        }
    }
}