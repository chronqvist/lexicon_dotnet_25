// Assignment: Mini Project 1:  # Asset Tracking 
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com


namespace MiniProject1AssetTracking
{
    internal class ExchangeRate
    {
        public decimal USDToDKK { get; set; }
        public decimal USDToEUR { get; set; }
        public decimal USDToGBP { get; set; }
        public decimal USDToSEK { get; set; }
        public decimal USDToUSD { get; set; }

        public ExchangeRate()
        {
            USDToDKK = 6.93m;
            USDToEUR = 0.85m;
            USDToGBP = 0.74m;
            USDToSEK = 9.39m;
            USDToUSD = 1.00m;
        }
        public decimal FromUSDToLocal(string currency)
        {
            switch (currency.ToUpper())
            {
                case "DKK":
                    return USDToDKK;
                case "EUR":
                    return USDToEUR;
                case "GBP":
                    return USDToGBP;
                case "SEK":
                    return USDToSEK;
                case "USD":
                    return USDToUSD;
                default:
                    Console.WriteLine("Invalid currency");
                    return -1.00m;
            }
        }
    }
}
