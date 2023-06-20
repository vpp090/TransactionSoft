using API.Controllers;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UnitTests
{
    public class MerchantTests
    {
        [Fact]
        public async Task GetALlMerchants()
        {
            var mockRepo = new Mock<IMerchantRepository>();
            mockRepo.Setup(repo => repo.GetMerchants())
                .ReturnsAsync(TestDataHelper.GetMerchants());

            var fileMock = new Mock<IFormFile>();

            var mockReader = new Mock<ICsvReader<DataTable>>();
            mockReader.Setup(reader => reader.ReadCsvFile(fileMock.Object))
               .ReturnsAsync(new DataTable());

            var mockService = new Mock<IMerchantService>();
            mockService.Setup(s => s.GetMerchants())
                .ReturnsAsync(TestDataHelper.GetServiceResponse());
            
            var mockLog = new Mock<ILogger>();

            var controller = new MerchantController(mockService.Object, mockLog.Object);

            var result = (await controller.GetAllMerchants()).Result as OkObjectResult;
            Assert.NotNull(result);

            var response = result.Value as ServiceResponse<IReadOnlyList<Merchant>>;

            Assert.NotNull(response);
            Assert.Equal(10, response.Data.Count);
          
        }
    }
}
