using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMerchantRepository
    {
        Task<IReadOnlyList<Merchant>> GetMerchants();
        Task<Merchant> GetMerchantById(int id);

        Task<IReadOnlyList<Merchant>> CreateMerchants(List<Merchant> merchants);
    }
}