using System;
using System.Threading.Tasks;
using OnSolve.EP.Models.API;
using OnSolve.EP.Repositories.Interfaces.RestAPI;



namespace OnSolve.EP.Repositories.RestAPI
{
    public class ExchangeRateRepository:IExchangeRateRepository
    {

        public Task<ExchangeRateResponse> GetExchangeRateAsync(ExchangeRateRequest ExchangeRateRqst)
        {
            throw new NotImplementedException();
        }
    }
}
