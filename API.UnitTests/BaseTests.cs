
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.UnitTests
{
    public class BaseTests
    {
        protected readonly Mock<ILogger> mockLog;

        public BaseTests()
        {
            mockLog = new Mock<ILogger>();
        }
    }
}
