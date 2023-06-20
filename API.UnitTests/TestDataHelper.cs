using Core.Entities;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UnitTests
{
    internal static class TestDataHelper
    {
        internal static List<Merchant> GetMerchants()
        {
            var list = new List<Merchant>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Merchant
                {
                    Name = "Merchant" + i.ToString(),
                    Description = "test test",
                    Email = "testable@test.com",
                    Status = MerchantStatus.Active,
                    Id = i
                });
            }

            return list;
        }

        internal static ServiceResponse<IReadOnlyList<Merchant>> GetServiceResponse()
        {
            var merchants = GetMerchants();

            return new ServiceResponse<IReadOnlyList<Merchant>>(merchants);
        }
    }
}
