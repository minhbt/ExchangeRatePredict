using System;
namespace OnSolve.EP.Models.API
{
    public class ExchangeRateRequest
    {
        public ExchangeRateRequest()
        {
        }

        public DateTime Date { get; set; }

        public string AppID { get; set; }

        public string Base { get; set; }

        public string Symbol { get; set; }

        public bool ShowAlternative { get; set; }

        public bool PrettyPrint { get; set; }

        public string[] TargetCurrencies { get; set; }

    }
}
