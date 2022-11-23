using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using TestAPI.Controllers;
using Xunit;

namespace TestApi.Test
{
    public class WeatherForecastTests
    {
        private readonly WeatherForecastController weatherForecastController;
        private Mock<ILogger<WeatherForecastController>> mockLogger;
        public WeatherForecastTests()
        {
            mockLogger = new Mock<ILogger<WeatherForecastController>>();
            this.weatherForecastController = new WeatherForecastController(mockLogger.Object);
        }

        [Fact]
        public void WeatherForecastController_Should_Return_5_Itmes()
        {
            var weatherData = weatherForecastController.Get();
            weatherData.Should().HaveCount(5);
        }
    }
}