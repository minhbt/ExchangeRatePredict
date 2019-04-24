using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OnSolve.EP.Models.Business
{
    public class ExchangeRateBO
    {
        public ExchangeRateBO()
        {
        }

        public ExchangeRateBO(
            DateTime timeStamp,
            Dictionary<string, decimal> rates,
            string @base = "USD")
        {
            Base = @base;
            TimeStamp = timeStamp;
            Rates = rates;
        }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }

        public string Base { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }
    }
}
