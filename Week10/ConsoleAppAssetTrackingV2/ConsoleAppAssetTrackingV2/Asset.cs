using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppAssetTrackingV2
{
    internal class Asset
    {
        public int AssetId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal PurchasePriceUSD { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
    }
}
