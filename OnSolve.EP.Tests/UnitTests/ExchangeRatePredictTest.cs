using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using OnSolve.EP.Services;
using OnSolve.EP.Repositories;
using OnSolve.EP.Models.Business;
using System.Threading;
using OnSolve.EP.Common.Helpers;
using FluentAssertions;

namespace OnSolve.EP.Tests.UnitTests
{
    public class ExchangeRatePredictTest
    {
        [Fact]
        public async Task PredictShouldCorrect()
        {
            var targetDate = new DateTime(2017, 1, 15);

            var numOfSamples = 12;
            var baseCurrency = "USD";
            var targetCurrency = "TRY";
            var timeSeries = Enumerable.Range(1, numOfSamples).Select(t => targetDate.AddMonths(-t));
            var rates = new List<decimal>
            {
                3.043590m, 2.945926m, 2.893866m,
                2.854589m, 2.970913m, 2.925991m,
                2.990882m, 2.944941m, 2.970704m,
                3.089218m, 3.284672m, 3.503773m
            };
            rates.Reverse();

            var timeSeriesGenerator = new Mock<ITimeSeriesService>();
            var exchangeRatesResource = new Mock<IExchangeRateSourceService>();
            var regressionEquationFactory = new Mock<IRegressionFomularRepository>();
            IExchangeRatePredictService predictor = new ExchangeRatePredictService(
                timeSeriesGenerator.Object,
                exchangeRatesResource.Object,
                regressionEquationFactory.Object);

            timeSeriesGenerator
                .Setup(t => t.MoveBackwardByMonth(targetDate, numOfSamples, false))
                .Returns(timeSeries);

            foreach (var date in timeSeries)
            {
                var exchangeRate = new ExchangeRateBO
                {
                    Base = baseCurrency,
                    TimeStamp = date,
                    Rates = new Dictionary<string, decimal> {
                        { targetCurrency, rates[date.Month - 1] }
                    }
                };

                var exR = exchangeRatesResource.Setup(t =>
                        t.GetHistorical(new Models.API.ExchangeRateRequest
                        {
                            Date = date,
                            Base = It.IsAny<string>(),
                            TargetCurrencies = It.IsAny<string[]>(),

                        }, It.IsAny<CancellationToken>()));
             

                exR.ReturnsAsync(exchangeRate);
            }

            regressionEquationFactory
                .Setup(t => t.Create(It.IsAny<List<DataPoint2dBO>>()))
                .Returns(new RegressionFomularBO(0.035126416m, 2.806600379m));

            decimal expectedResult = 3.263m;


            var result = await predictor.PredictAsync("USD", "TRY", targetDate, numOfSamples);
            result.AlmostEquals(expectedResult, 3).Should().BeTrue();
        }
    }
}
