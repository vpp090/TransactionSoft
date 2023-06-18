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
               throw new Exception("Merchant not found");

            return merchant;
        }

        public async Task<IReadOnlyList<Merchant>> GetMerchants()
        {
            var merchants = await _context.Merchants.ToListAsync();

            if(merchants == null)
                throw new Exception("Merchants not found");

            return merchants;
        }

        
        public async Task<IReadOnlyList<Merchant>> CreateMerchants(List<Merchant> merchants)
        {
            await _context.Merchants.AddRangeAsync(merchants);
            await _context.SaveChangesAsync();

            return merchants;

        }

        public async Task<bool> DeleteMerchant(int id)
        {
            try
            {
                var merchant = await _context.Merchants.Include(m => m.Transactions).FirstOrDefaultAsync(m => m.Id == id);
                
                if(merchant.Transactions != null)
                    throw new Exception("Merchant has related transactions");

                var result = _context.Remove(merchant);

                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception)
            {
                throw;
            }
           
        }
    }
}