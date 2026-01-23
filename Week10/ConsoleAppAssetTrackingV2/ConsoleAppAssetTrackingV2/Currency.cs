using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppAssetTrackingV2
{
    internal class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
