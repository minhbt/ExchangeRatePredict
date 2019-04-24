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
            services.AddSingleton<ITimeSeriesService, ITimeSeriesService>();
            services.AddTransient<IExchangeRateSourceService, IExchangeRateSourceService>();
            services.AddTransient<IExchangeRatePredictService, IExchangeRatePredictService>();
            services.AddTransient<IRegressionFomularRepository, IRegressionFomularRepository>();
            services.AddHttpClient();
            return services;
        }
    }
}
