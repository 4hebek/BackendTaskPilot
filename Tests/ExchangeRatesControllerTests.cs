using BackendTaskPilot.Contracts;
using BackendTaskPilot.Controllers;
using BackendTaskPilot.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests
{
    public class ExchangeRatesControllerTests
    {
        [Fact]
        public async Task GetExchangeRates_ReturnsOkResult_WithExpectedRates()
        {
            // Arrange
            var currencies = new List<string> { "USD", "EUR" };
            var expectedRates = new List<ExchangeRate>
        {
            new ExchangeRate { CurrencyCode = "USD", RateValue = 1.0m },
            new ExchangeRate { CurrencyCode = "EUR", RateValue = 0.85m }
        };

            var mockService = new Mock<IExchangeRateService>();
            mockService.Setup(service => service.GetExchangeRates("CZK", currencies))
                       .ReturnsAsync(expectedRates);

            var controller = new ExchangeRateController(mockService.Object);

            // Act
            var result = await controller.GetExchangeRates(targetCurrencies: currencies);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnRates = Assert.IsType<List<ExchangeRate>>(okResult.Value);
            Assert.Equal(expectedRates.Count, returnRates.Count);
            Assert.Equal("USD", returnRates[0].CurrencyCode);
        }

        [Fact]
        public async Task GetExchangeRates_ReturnsNotFound_WhenNoRates()
        {
            // Arrange
            var currencies = new List<string> { "JPY" };

            var mockService = new Mock<IExchangeRateService>();
            mockService.Setup(service => service.GetExchangeRates("CZK", currencies))
                       .ReturnsAsync((List<ExchangeRate>)null);  // Simulate no data

            var controller = new ExchangeRateController(mockService.Object);

            // Act
            var result = await controller.GetExchangeRates(targetCurrencies: currencies);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
