using System.Threading;
using System.Threading.Tasks;
using OnSolve.EP.Models.API;
using OnSolve.EP.Models.Business;

namespace OnSolve.EP.Services
{
    public  interface IExchangeRateSourceService
    {
        Task<ExchangeRateBO> GetHistorical(
            ExchangeRateRequest exchangeRateRequest,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
