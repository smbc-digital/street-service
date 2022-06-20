using street_service.Controllers;
using Moq;
using Xunit;
using street_service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.Addresses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace street_service_tests.Controllers
{
    public class StreetControllerTests
    {
        private readonly StreetController _controller;
        private readonly Mock<IStreetService> _mockService = new Mock<IStreetService>();

        private readonly Mock<ILogger<StreetController>> _mockLogger = new Mock<ILogger<StreetController>>();

        public StreetControllerTests()
        {
            _controller = new StreetController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Get_ShouldCallStreetService_AndReturnSingleItem()
        {
            _mockService.Setup(_ => _.SearchAsync(It.IsAny<EStreetProvider>(), It.IsAny<string>())).ReturnsAsync(new List<AddressSearchResult> { new AddressSearchResult() });

            // Act
            var response = await _controller.Get(EStreetProvider.CRM,"test");

            // Assert
            var listResponse = Assert.IsType<OkObjectResult>(response);
            _mockService.Verify(_ => _.SearchAsync(It.IsAny<EStreetProvider>(), It.IsAny<string>()), Times.Once);
        }
    }
}
