using System;
using System.Threading.Tasks;
using OnSolve.EP.Models.API;

namespace OnSolve.EP.Repositories.Interfaces.RestAPI
{
    public interface IExchangeRateRepository
    {

        Task<ExchangeRateResponse> GetExchangeRateAsync(ExchangeRateRequest ExchangeRateRqst);
    }
}
