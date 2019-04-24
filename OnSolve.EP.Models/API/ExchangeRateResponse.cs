
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OnSolve.EP.Models.API
{
    public class ExchangeRateResponse
    {

        public ExchangeRateResponse()
        {
        }

        public string Disclaimer { get; set; }

        public string License { get; set; }

        public DateTime Timestamp { get; set; }
       
        public string Base { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }


    }
}
