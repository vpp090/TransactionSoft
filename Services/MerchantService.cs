using Core.Interfaces;
using Core.Entities;
using Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace Services
{
    public class MerchantService : IMerchantService
    {
        private IMerchantRepository _repository;
        private ICsvReader<DataTable> _reader;

        public MerchantService(IMerchantRepository repository, ICsvReader<DataTable> reader)
        {
            _repository = repository;
            _reader = reader;
        }

        public async Task<IReadOnlyList<Merchant>> CreateMerchants(IFormFile csvFile)
        {
             var table = await _reader.ReadCsvFile(csvFile);

             var merchants = new List<Merchant>();
             foreach(DataRow row in table.Rows)
             {
                var merchant = new Merchant();
                merchant.Name = row[nameof(merchant.Name)].ToString();
                merchant.Description = row[nameof(merchant.Description)].ToString();
                merchant.Email = row[nameof(merchant.Email)].ToString();
                merchant.Status =(MerchantStatus)int.Parse(row[nameof(merchant.Status)].ToString());
                merchant.TotalTransactionSum = decimal.Parse(row[nameof(merchant.TotalTransactionSum)].ToString());

                merchants.Add(merchant);
             }

             var result = await _repository.CreateMerchants(merchants);

             return result;
        }

        public async Task<Merchant> GetMerchantById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Merchant>> GetMerchants()
        {
            return await _repository.GetMerchants();
        }
    }
}