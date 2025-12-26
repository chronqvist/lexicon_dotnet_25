// Assignment: Mini Project 1:  # Asset Tracking
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

//using System;
//using System.Collections.Generic;
//using System.Text;

namespace MiniProject1AssetTracking
{
    internal class Asset : ILocalPrice
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Office { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePriceUSD { get; set; }
        public string Currency { get; set; }
        public Asset(string type, string brand, string model, string office, DateTime purchaseDate,
            Decimal purchasePriceUSD, string currency)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Office = office;
            PurchaseDate = purchaseDate;
            PurchasePriceUSD = purchasePriceUSD;
            Currency = currency;
        }
        public decimal getLocalPrice()
        {
            decimal exchangeRate = 1.0m; // Placeholder for actual exchange rate retrieval logic    
            return PurchasePriceUSD * exchangeRate;
        }
    }
}
