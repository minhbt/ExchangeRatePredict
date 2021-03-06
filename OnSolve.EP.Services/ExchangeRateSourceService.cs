﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnSolve.EP.Models.API;
using OnSolve.EP.Models.Business;
using OnSolve.EP.SDK;
using OnSolve.EP.SDK.OpenExchangeRate;


namespace OnSolve.EP.Services
{
    public class ExchangeRateSourceService: IExchangeRateSourceService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenExchangeRateConfig _configuration;
        //private readonly string _url;

        public ExchangeRateSourceService(IHttpClientFactory httpClientFactory, IOptions<OpenExchangeRateConfig> options)
        {
            _configuration = options.Value ?? throw new ArgumentNullException(nameof(options));
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }

            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_configuration.Endpoint);

        }


        public async Task<ExchangeRateBO> GetHistorical(
            ExchangeRateRequest exchangeRateRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            ExchangeRateSDK exchangeRateSDK = new ExchangeRateSDK(exchangeRateRequest, _configuration);
            var url = exchangeRateSDK.GetHistoricalURL();

            return await _httpClient.GetAsync<ExchangeRateBO>(url,
                                                               cancellationToken).ConfigureAwait(false);
        }



    }
}
