using System;
using System.Linq;
using System.Threading.Tasks;
using OnSolve.EP.Models.Business;
using OnSolve.EP.Repositories;

namespace OnSolve.EP.Services
{
    public class ExchangeRatePredictService:IExchangeRatePredictService
    {
        private readonly ITimeSeriesService _TimeSeriesService;
        private readonly IExchangeRateSourceService _ExchangeRateSourceService;
        private readonly IRegressionFomularRepository _RegressionFomularRepository;

        public ExchangeRatePredictService(ITimeSeriesService timeSeriesService,
            IExchangeRateSourceService exchangeRateSourceService,
            IRegressionFomularRepository regressionFomularRepository)
        {
            _TimeSeriesService = timeSeriesService;
            _ExchangeRateSourceService = exchangeRateSourceService;
            _RegressionFomularRepository = regressionFomularRepository;
        }

        public async Task<decimal> PredictAsync(string from, string to, DateTime targetDate, int numOfSamples = 12)
        {
            // generate time series
            var timeSeries = _TimeSeriesService
                .MoveBackwardByMonth(targetDate, numOfSamples, false);

            var exchangeRates = await Task.WhenAll(timeSeries.Select(date =>
             _ExchangeRateSourceService.GetHistorical(new Models.API.ExchangeRateRequest() {
                 Date=date,
                 Base=from,
                 TargetCurrencies= new[] {to},
             } ))).ConfigureAwait(false);

            var dataPoints = exchangeRates.Select((xRate, index) =>
            {
                var x = numOfSamples - index;
                var y = xRate.Rates[to];
                return new DataPoint2dBO(x, y);
            }).ToList();

            var regressionEquation = _RegressionFomularRepository.Create(dataPoints);

            decimal result = regressionEquation.Calculate(numOfSamples + 1);

            return result;
        }
    }
}
