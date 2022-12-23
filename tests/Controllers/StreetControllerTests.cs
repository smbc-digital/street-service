namespace street_service_tests.Controllers;

public class StreetControllerTests
{
    private readonly StreetController _controller;

    private readonly Mock<IStreetService> _mockService = new();
    private readonly Mock<ILogger<StreetController>> _mockLogger = new();

    public StreetControllerTests() => _controller = new StreetController(_mockService.Object, _mockLogger.Object);

    [Fact]
    public async Task Get_ShouldCallStreetService_AndReturnSingleItem()
    {
        // Arrange
        _mockService.Setup(_ => _.SearchAsync(It.IsAny<EStreetProvider>(), It.IsAny<string>())).ReturnsAsync(new List<AddressSearchResult> { new() });

        // Act
        var response = await _controller.Get(EStreetProvider.CRM,"test");

        // Assert
        Assert.IsType<OkObjectResult>(response);
        _mockService.Verify(_ => _.SearchAsync(It.IsAny<EStreetProvider>(), It.IsAny<string>()), Times.Once);
    }
}