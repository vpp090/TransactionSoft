using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Services.Interfaces
{
    public interface IMerchantService
    {
         Task<Merchant> GetMerchantById(string id);
         Task<IReadOnlyList<Merchant>> GetMerchants();

         Task<IReadOnlyList<Merchant>> CreateMerchants(IFormFile csvFile);
    }
}