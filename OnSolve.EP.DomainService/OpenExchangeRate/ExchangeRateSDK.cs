using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using OnSolve.EP.Models.API;

namespace OnSolve.EP.SDK.OpenExchangeRate
{
    public class ExchangeRateSDK : IExchangeRateSDK
    {
        private  ExchangeRateRequest _Exr;
        private string APP_ID_PARAM = "app_id";
        private readonly OpenExchangeRateConfig _configuration;

        public ExchangeRateSDK(ExchangeRateRequest exchangeRateRequest, OpenExchangeRateConfig config)
        {
            _Exr = exchangeRateRequest;
            _configuration = config;
        }

        public string GetHistoricalURL()
        {
            var dateStr = _Exr.Date.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("us"));
            var @params = new Dictionary<string, string>
                {
                    { "base", _Exr.Base },
                    { "symbols", string.Join(",", _Exr.TargetCurrencies) }
                };
            string url = BuildUrl(
                $"historical/{dateStr}.json",
                @params);

            return url;
        }

       

        private string BuildUrl(string path, Dictionary<string, string> @params=null)
        {
            //Dictionary<string, string> @params = null;
             if (string.IsNullOrEmpty(_Exr.AppID))
            {
                @params = new Dictionary<string, string>
                {
                    { APP_ID_PARAM, _configuration.AppId }
                };
            }
            else if (!@params.ContainsKey(APP_ID_PARAM))
            {
                @params.Add(APP_ID_PARAM, _configuration.AppId);
            }

            var paramList = @params.Select(
                    item => $"{item.Key}={Uri.EscapeDataString(item.Value)}");

            var query = "?" + string.Join("&", paramList);

            return $"/{path}{query}";
        }

       
    }
}
