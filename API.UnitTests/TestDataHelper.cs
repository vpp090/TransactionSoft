using AutoMapper.Configuration.Conventions;
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

        internal static ServiceResponse<IReadOnlyList<Merchant>> MerchantServiceGetMerchants()
        {
            var merchants = GetMerchants();

            return new ServiceResponse<IReadOnlyList<Merchant>>(merchants);
        }

        internal static DataTable CreateMerchantTable()
        {
            var table = new DataTable();

            table.Columns.Add("Id");
            table.Columns.Add("Name");
            table.Columns.Add("Description");
            table.Columns.Add("Email");
            table.Columns.Add("Status");

           for(int i =1; i < 11; i++)
            {
                table.Rows.Add(i, "Merch" + i, "Description" + i, "mm@kk.com", 1);
            }

            return table;

        }

        internal static ServiceResponse<IReadOnlyList<Merchant>> CreateMockMerchants()
        {
            return new ServiceResponse<IReadOnlyList<Merchant>> (new List<Merchant>());
        }

        internal static List<Transaction> GetTransactions()
        {
            var list = new List<Transaction>();

            for(int i = 0; i < 10; i++)
            {
                list.Add(new Transaction
                {
                    Status = TransactionStatus.Approved,
                    Amount = 100,
                    CustomerEmail = "email" + i + "@email.com",
                    IsProcessed = false,
                    TransactionType = new TransactionType { Id = 1, Name = "Auth" },
                    CustomerPhone = "11111" + i

                }) ;
            }

            return list;
        }
    }
}
