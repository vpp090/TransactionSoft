using Core.Entities;
using Microsoft.AspNetCore.Http;
using Services.Model;

namespace Services.Interfaces
{
    public interface IMerchantService
    {
         Task<ServiceResponse<Merchant>> GetMerchantById(string id);
         Task<ServiceResponse<IReadOnlyList<Merchant>>> GetMerchants();

         Task<ServiceResponse<IReadOnlyList<Merchant>>> CreateMerchants(IFormFile csvFile);

         Task<ServiceResponse<bool>> DeleteMerchant(int id);
    }
}