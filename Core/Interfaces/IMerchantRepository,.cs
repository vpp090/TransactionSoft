using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMerchantRepository
    {
        Task<IReadOnlyList<Merchant>> GetMerchants();
        Task<Merchant> GetMerchantById(int id);

        Task<IReadOnlyList<Merchant>> CreateMerchants(List<Merchant> merchants);

        Task<bool> DeleteMerchant(int id);
    }
}