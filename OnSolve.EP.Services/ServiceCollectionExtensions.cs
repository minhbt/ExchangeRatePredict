using System;
using OnSolve.EP.Repositories;
using OnSolve.EP.SDK;
using OnSolve.EP.Services;

namespace Microsoft.Extensions.DependencyInjection
{


    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExchangePredict(this IServiceCollection services, Action<OpenExchangeRateConfig> configure)
        {

            services.Configure(configure);
            services.AddSingleton<ITimeSeriesService, TimeSeriesService>();
            services.AddTransient<IExchangeRateSourceService, ExchangeRateSourceService>();
            services.AddTransient<IExchangeRatePredictService, ExchangeRatePredictService>();
            services.AddTransient<IRegressionFomularRepository, RegressionFomularRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
