using Core.Interfaces;
using Core.Entities;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Data;
using Services.Model;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class MerchantService : IMerchantService
    {
        private IMerchantRepository _repository;
        private ICsvReader<DataTable> _reader;

        private ILogger _logger;

        public MerchantService(IMerchantRepository repository, ICsvReader<DataTable> reader, ILogger logger)
        {
            _repository = repository;
            _reader = reader;
        }

        public async Task<ServiceResponse<IReadOnlyList<Merchant>>> CreateMerchants(IFormFile csvFile)
        {
            try
            {
                var table = await _reader.ReadCsvFile(csvFile);

                var merchants = new List<Merchant>();
                foreach (DataRow row in table.Rows)
                {
                    var merchant = new Merchant();
                    merchant.Name = row[nameof(merchant.Name)].ToString();
                    merchant.Description = row[nameof(merchant.Description)].ToString();
                    merchant.Email = row[nameof(merchant.Email)].ToString();
                    merchant.Status = (MerchantStatus)int.Parse(row[nameof(merchant.Status)].ToString());
                   
                    merchants.Add(merchant);
                }

                var result = await _repository.CreateMerchants(merchants);

                return new ServiceResponse<IReadOnlyList<Merchant>>(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in creating merchants");
                return new ServiceResponse<IReadOnlyList<Merchant>>(ex);
            }
            
        }

        public async Task<ServiceResponse<bool>> DeleteMerchant(int id)
        {
            try
            {
                var result = await _repository.DeleteMerchant(id);

                return new ServiceResponse<bool>(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in deleting merchants");
                return new ServiceResponse<bool>(ex);
            }
            
        }

        public async Task<ServiceResponse<Merchant>> GetMerchantById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<IReadOnlyList<Merchant>>> GetMerchants()
        {
            try
            {
                 var result = await _repository.GetMerchants();

                 return new ServiceResponse<IReadOnlyList<Merchant>>(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in getting merchants");
                return new ServiceResponse<IReadOnlyList<Merchant>>(ex);
            }
           
        }
    }
}