using System;
using System.Collections.Generic;
using OnSolve.EP.Models.Business;

namespace OnSolve.EP.Tests.Helpers
{
    public static class ExchangeRateGenerator
    {
        public static List<ExchangeRateBO> GenerateExchangeRates(DateTime targetDate, List<decimal> rates)
        {
            var samples = new List<ExchangeRateBO>();
            DateTime date;
            ExchangeRateBO exchangeRateItem;
            for (var i = 1; i < 13; i++)
            {
                date = targetDate.AddMonths(-1 * i);
                Dictionary<string, decimal> ratesMap = new Dictionary<string, decimal>
                {
                    { "TRY", rates[i - 1] }
                };
                exchangeRateItem = new ExchangeRateBO(
                    date,
                    rates: ratesMap);

                samples.Add(exchangeRateItem);
            }

            return samples;
        }
    }
}
