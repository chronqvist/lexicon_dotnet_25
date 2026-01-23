using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleAppAssetTrackingV2
{
    internal class App
    {
        private AssetDbContext context; 
        public void Run()
        {
            context = new AssetDbContext();
            context.Database.SetCommandTimeout(120);
            PageMainMenu("assetId");
        }
        private void PageMainMenu(string orderBy)
        {
            Header("Main menu");
            ListAssets(orderBy);
            Console.WriteLine("Select task:");
            Console.WriteLine(" 1) Main menu");
            Console.WriteLine(" 2) Add an asset");
            Console.WriteLine(" 3) Update an asset");
            Console.WriteLine(" 4) Delete an asset");
            Console.WriteLine(" 5) Sort assets according to product name");
            Console.WriteLine(" 6) Sort assets according to purchase date");
            Console.WriteLine(" 7) Sort assets according to office and purchase date");
            Console.WriteLine(" 8) Exit");
            Console.Write("Choice: ");
            string reply = Console.ReadLine();
            switch (reply)
            {
                case "1":
                    PageMainMenu("assetId");
                    break;
                case "2":
                    PageAddAsset();
                    break;
                case "3":
                    PageUpdateAsset();
                    break;
                case "4":
                    PageDeleteAsset();
                    break;
                case "5":
                    PageMainMenu("productName");
                    break;
                case "6":
                    PageMainMenu("purchaseDate");
                    break;
                case "7":
                    PageMainMenu("office_purchaseDate");
                    break;
                case "8":
                    return;
                    break;
                default:
                    Console.Write("Wrong choice");
                    Console.ReadKey();
                    PageMainMenu("assetId");
                    break;
            }
        }



        private void PageAddAsset()
        {
            Header("Add a asset");
            ListAssets("assetId");
            Asset asset = new Asset();
            ListProducts();
            Console.Write("Choose product id: ");
            asset.ProductId = int.Parse(Console.ReadLine());
            Console.Write("Enter brand: ");
            asset.Brand = Console.ReadLine();
            Console.Write("Enter model: ");
            asset.Model = Console.ReadLine();
            ListOffices();
            Console.Write("Choose office id: ");
            asset.OfficeId = int.Parse(Console.ReadLine());
            Console.Write("Enter purchase date (yyyy-mm-dd): ");
            asset.PurchaseDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
            Console.Write("Enter purchase price in USD: ");
            asset.PurchasePriceUSD = decimal.Parse(Console.ReadLine());
            ListCurrencies();
            // list currencies for selection
            Console.Write("Choose currency id: ");
            asset.CurrencyId = int.Parse(Console.ReadLine());
            context.Assets.Add(asset);
            context.SaveChanges();
            Console.Write("Asset is added");
            Console.ReadKey();
            PageMainMenu("assetId");
        }

        private void PageUpdateAsset()
        {
            Header("Update a asset");
            ListAssets("assetId");
            Console.Write("Choose asset id that you want to update: ");
            int assetId = int.Parse(Console.ReadLine());
            Asset asset = context.Assets.Find(assetId);
            if (asset == null)
            {
                Console.Write("Asset not found");
                Console.ReadKey();
                PageMainMenu("assetId");
            }
            ListProducts();
            Console.WriteLine("Current product id is: " + asset.ProductId);
            Console.Write("Choose a new product id: ");
            asset.ProductId = int.Parse (Console.ReadLine());
            Console.WriteLine("Current brand is: " + asset.Brand);
            Console.Write("Enter a new brand: ");
            asset.Brand = Console.ReadLine();
            Console.WriteLine("Current model is: " + asset.Model);
            Console.Write("Enter a new model: ");
            asset.Model = Console.ReadLine();
            ListOffices();
            Console.WriteLine("Current office id is: " + asset.OfficeId);
            Console.Write("Choose a new office id: ");
            asset.OfficeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Current purchase date is: " + asset.PurchaseDate.ToString("yyyy-MM-dd"));
            Console.Write("Enter purchase date (yyyy-mm-dd): ");
            asset.PurchaseDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
            Console.WriteLine("Current purchase price is: " + asset.PurchasePriceUSD);
            Console.Write("Enter purchase price in USD: ");
            asset.PurchasePriceUSD = decimal.Parse(Console.ReadLine());
            ListCurrencies();
            Console.WriteLine("Current currency id is: " + asset.CurrencyId);
            Console.Write("Choose a new currency id: ");
            asset.CurrencyId = int.Parse(Console.ReadLine());
            context.SaveChanges();
            Console.Write("Asset is updated.");
            Console.ReadKey();
            PageMainMenu("assetId");
        }

        private void PageDeleteAsset()
        {
            Header("Delete an asset");
            ListAssets("assetId");
            Console.Write("Choose asset id that you want to delete: ");
            int assetId = int.Parse(Console.ReadLine());
            Asset asset = context.Assets.Find(assetId);
            if (asset != null)
            {
                context.Assets.Remove(asset);
                context.SaveChanges();
                Console.Write("Asset is deleted");
            } else
            {
                Console.Write("Asset not found");
            }
            Console.ReadKey();
            PageMainMenu("assetId");
        }

        private void ListAssets(string orderBy)
        {
            IQueryable<Asset> query = context.Assets
              .Include(x => x.Product)
              .Include(x => x.Office)
              .Include(x => x.Currency);

            switch (orderBy)
            {
                case "assetId":
                    query = query.OrderBy(x => x.AssetId);
                    break;
                case "productName":
                    query = query.OrderBy(x => x.Product.ProductName);
                    break;
                case "purchaseDate":
                    query = query.OrderBy(x => x.PurchaseDate);
                    break;
                case "office_purchaseDate":
                    query = query.OrderBy(x => x.Office.OfficeName).ThenBy(x => x.PurchaseDate);
                    break;
                default:
                    query = query.OrderBy(x => x.AssetId);
                    break;
            }
            List<Asset> assets = query.ToList();

            DateTime today = DateTime.Today;
            //  YELLOW → Less than 6 months away from 3 years.   
            DateTime yellowDate = today.AddMonths(-36 + 6);
            // RED → Less than 3 months away from 3 years. 
            DateTime redDate = today.AddMonths(-36 + 3);
            //Console.WriteLine("today: " + today.ToString("yyyy-MM-dd") + " yellowDate:" +
            //    yellowDate.ToString("yyyy-MM-dd") + " redDate: " + redDate.ToString("yyyy-MM-dd"));

            Console.WriteLine("Asset id".PadRight(10) + "Product".PadRight(14) + "Brand".PadRight(11) + 
                "Model".PadRight(15) + "Office".PadRight(15) + "Purchase date".PadRight(15) + "USD".PadRight(7) + 
                "  " + "Local".PadRight(10) + "  " + "Exchange rate".PadRight(15)  + "Currency".PadRight(8));
            foreach (var a in assets)
            {
                if (a.PurchaseDate < redDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                 else if (a.PurchaseDate < yellowDate)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                decimal priceLocal = a.PurchasePriceUSD * a.Currency.ExchangeRate;
                Console.WriteLine(a.AssetId.ToString().PadLeft(8) + "  " +
                    a.Product.ProductName.ToString().PadRight(14) + 
                    a.Brand.PadRight(11) + a.Model.PadRight(15) + a.Office.OfficeName.ToString().PadRight(15) + 
                    a.PurchaseDate.ToString("yyyy-MM-dd").PadRight(15) + 
                    a.PurchasePriceUSD.ToString("0.00", new CultureInfo("sv-SE")).PadLeft(7) + 
                    "  " + priceLocal.ToString("0.00", new CultureInfo("sv-SE")).PadLeft(10) + 
                     a.Currency.ExchangeRate.ToString("0.00", new CultureInfo("sv-SE")).PadLeft(15) +
                     "        " + a.Currency.CurrencyName.ToString());
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private void ListProducts()
        {
            List<Product> products = context.Products.ToList();
            Console.WriteLine("Product id".PadRight(15) + "Product name".PadRight(15));
            foreach (var p in products)
            {
                Console.WriteLine(p.ProductId.ToString().PadRight(15) + p.ProductName.PadRight(15));
            }
            Console.WriteLine();
        }

        private void ListOffices()
        {
            List<Office> officies = context.Offices.ToList();

            Console.WriteLine("Office id".PadRight(15) + "Office name".PadRight(15));
            foreach (var o in officies)
            {
                Console.WriteLine(o.OfficeId.ToString().PadRight(15) + o.OfficeName.PadRight(15));
            }
            Console.WriteLine();
        }

        private void ListCurrencies()
        {
            List<Currency> currencies = context.Currencies.ToList();

            Console.WriteLine("Currency id".PadRight(15) + "Currency name".PadRight(15) + "Exchange rate".PadRight(15));

            foreach (var c in currencies)
            {
                Console.WriteLine(c.CurrencyId.ToString().PadRight(15) + c.CurrencyName.PadRight(15) + 
                    c.ExchangeRate.ToString().PadRight(15));
            }
            Console.WriteLine();
        }

        private void Header(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(text.ToUpper());
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
