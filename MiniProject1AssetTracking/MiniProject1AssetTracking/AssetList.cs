// Assignment: Mini Project 1:  # Asset Tracking 
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com


namespace MiniProject1AssetTracking
{
    internal class AssetList
    {
        List<Asset> assetList = new List<Asset>();
        ExchangeRate exchangeRate = new ExchangeRate();
        public void AddAsset(Asset asset)
        {
            assetList.Add(asset);
        }

        // Items* RED* if date less than 3 months away from 3 years
        // Items* Yellow* if date less than 6 months away from 3 years
        public void ListAssets()
        {
            List<Asset> ordedAssetList = assetList
                .OrderBy(a => a switch
                {
                    Computer => 0,
                    Phone => 1,
                    _ => 2  // Unkown type
                })
                .ThenByDescending(e => e.PurchasePriceUSD)
                .ToList();
            DateTime today = DateTime.Today;
            // 3 years - 6 months
            DateTime yellowDate = today.AddMonths(-30); // 3 years - 6 months
            // 3 years - 3 months
            DateTime redDate = today.AddMonths(-33);
            Console.WriteLine("{0,-10} {1,-15} {2,-20} {3,-15} {4,-13} {5,-12} {6,-8} {7,-17}",
                "Type", "Brand", "Model", "Office", "Purchase Date", "Price in USD", "Currency", "Local price today");
            Console.WriteLine("{0,-10} {1,-15} {2,-20} {3,-15} {4,-13} {5,-12} {6,-8} {7,-17}",
                "----", "-----", "-----", "------", "-------------", "------------", "--------", "-----------------");
            foreach (var asset in ordedAssetList)
            {
                if (asset.PurchaseDate > yellowDate)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                else if (asset.PurchaseDate > redDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("{0,-10} {1,-15} {2,-20} {3,-15} {4,13} {5,12:F2} {6,8} {7,17:F2}", asset.Type,
                    asset.Brand,  asset.Model, asset.Office, asset.PurchaseDate.ToString("yyyy-MM-dd"),
                    asset.PurchasePriceUSD, asset.Currency,
                    asset.PurchasePriceUSD * exchangeRate.FromUSDToLocal(asset.Currency));
                Console.ResetColor();
            }
        }
    }
}
