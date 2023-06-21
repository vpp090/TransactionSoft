using API.Controllers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Hangfire;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Services;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UnitTests
{
    public class TransactionTests : BaseTests
    {
        public TransactionTests() : base()
        {
            
        }

        [Fact]
        public async Task GetAllTransactions()
        {
            var mockRepo = new Mock<ITransactionRepository>();

            mockRepo.Setup(repo => repo.GetAllTransactions())
                .ReturnsAsync(TestDataHelper.GetTransactions());

            var service = new TransactionService(mockRepo.Object, new Mock<IMerchantRepository>().Object, new Mock<IMapper>().Object, mockLog.Object);

            var controller = new TransactionController(service, new Mock<IRecurringJobManager>().Object);
            var result = (await controller.GetAllTransactions()).Result as OkObjectResult;

            Assert.NotNull(result);
            var response = result.Value as ServiceResponse<IReadOnlyList<Transaction>>;

            Assert.NotNull(response);
            Assert.Equal(10, response.Data.Count);
        }

        [Fact]
        public async Task ProcessTransaction()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "testdb").Options;

            var id = Guid.Parse("d156b5b8-7cd8-44a0-aa7f-0cc193dede7d");
            using (var context = new DataContext(options))
            {
                context.Transactions.
                    Add(new Transaction { Id = id, Amount = 100, CustomerEmail = "email here", CustomerPhone = "1111", CreatedDate = DateTime.Now, IsProcessed = false, Status = TransactionStatus.Approved });

                context.SaveChanges();

                var repo = new TransactionRepository(context, new Mock<IMapper>().Object);
                var service = new TransactionService(repo, new Mock<IMerchantRepository>().Object, new Mock<IMapper>().Object, mockLog.Object);

                var controller = new TransactionController(service, new Mock<IRecurringJobManager>().Object);

                var result = (await controller.ProcessTransaction(id)).Result as OkObjectResult;

                Assert.NotNull(result);
                var response = result.Value as ServiceResponse<bool>;

                Assert.NotNull(response);
                Assert.True(response.Data);
            }


        }
    }
}
