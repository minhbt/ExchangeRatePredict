using System;
using System.Collections.Generic;

namespace OnSolve.EP.Models.DTO
{
    public class ExchangeRateDto
    {
        public ExchangeRateDto()
        {
        }
        public DateTime TimeStamp { get; set; }

        public string Base { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }

    }
}
