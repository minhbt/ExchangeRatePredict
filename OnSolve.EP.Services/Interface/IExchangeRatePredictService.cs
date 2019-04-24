using System;
using System.Threading;
using System.Threading.Tasks;
using OnSolve.EP.Models.API;

namespace OnSolve.EP.Services
{
    public interface IExchangeRatePredictService
    {

        Task<decimal> PredictAsync(string from, string to, DateTime targetDate, int numOfSamples = 12);
    }
}
