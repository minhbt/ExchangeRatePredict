using System;
using System.Threading.Tasks;
using Xunit;
using OnSolve.EP.Services;
using Microsoft.Extensions.DependencyInjection;
using OnSolve.EP.Common.Helpers;
using FluentAssertions;

namespace OnSolve.EP.Tests.IntergrationTests
{
    public class ExchangeRatePredictIntegrationTest
    {
        [Fact]
        public async Task PredictShouldWork()
        {
            var services = new ServiceCollection();
            services.AddExchangePredict(opts =>
            {
                opts.Endpoint = "https://openexchangerates.org/api/";
                opts.AppId = "573c0c9d12e14355b304fcf52e240699";
            });
            var sp = services.BuildServiceProvider();
            var predictor = sp.GetService<IExchangeRatePredictService>();

            var targetDate = new DateTime(2017, 1, 15);
            var expectedResult = 3.263m;
            var result = await predictor.PredictAsync("USD", "TRY", targetDate, 12);

            result.AlmostEquals(expectedResult, 3).Should().BeTrue();
        }
    }
}
