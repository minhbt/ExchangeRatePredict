using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using OnSolve.EP.Tests.Helpers;
using OnSolve.EP.SDK;
using OnSolve.EP.Services;
using System.Net.Http;
using Microsoft.Extensions.Options;
using FluentAssertions;

namespace OnSolve.EP.Tests.UnitTests
{
    public class ExchangeRateSourceTest
    {
        [Fact]
        public async Task GetHistoricalDataShouldReturnListOfExchangeRates()
        {
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var options = new Mock<IOptions<OpenExchangeRateConfig>>();
            var json = "{}";
            var httpClient = HttpClientMockHelper.CreateHttpClient(json);
            var from = "USD";
            var to = "TRY";
            var configuration = new OpenExchangeRateConfig
            {
                Endpoint = "https://amazon.com",
                AppId = "12345"
            };

            options.Setup(t => t.Value).Returns(configuration);
            httpClientFactory
                .Setup(t => t.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            IExchangeRateSourceService exchangeRate = new ExchangeRateSourceService(
                httpClientFactory.Object,
                options.Object);
            var targetDate = new DateTime(2017, 1, 15);

           
            var historicalData = await exchangeRate.GetHistorical( new Models.API.ExchangeRateRequest { 
                Date= targetDate,
                Base= from,
                TargetCurrencies= new[] { to }
                });


            historicalData.Should().NotBeNull();
        }
    }
}
