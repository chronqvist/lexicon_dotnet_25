// Assignment: Mini Project 1:  # Asset Tracking 
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

using System.Collections.Generic;
using System.Globalization;

namespace MiniProject1AssetTracking
{
    internal class ProgramStates
    {
        List<string> validCurrencies = new List<string>
        {
             "DKK", "EUR", "GBP", "SEK", "USD"
        };


        public void InputProduct(AssetList assetList)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"To enter a new asset - follow the steps | To quit - enter: Q");
                Console.ResetColor();
                Console.Write("Enter a Type (Computer or Phone): ");
                string type = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(type))
                {
                    Console.WriteLine("Type cannot be empty");
                    continue;
                }
                if (type.ToLower() == "q")
                {
                    break;
                }
                if (type.ToLower() != "computer" && type.ToLower() != "phone")
                {
                    Console.WriteLine("The only valid types are Computer and Phone");
                    continue;
                }
                Console.Write("Enter Brand: ");
                string brand = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(brand))
                {
                    Console.WriteLine("Brand cannot be empty");
                    continue;
                }
                if (brand.ToLower() == "q")
                {
                    break;
                }
                Console.Write("Enter Model: ");
                string model = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(model))
                {
                    Console.WriteLine("Model cannot be empty");
                    continue;
                }
                if (model.ToLower() == "q")
                {
                    break;
                }
                Console.Write("Enter Office: ");
                string office = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(office))
                {
                    Console.WriteLine("Office cannot be empty");
                    continue;
                }
                if (office.ToLower() == "q")
                {
                    break;
                }
                Console.Write("Enter Purchase Date (yyyy-MM-dd): ");
                string purchaseDate = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(purchaseDate))
                {
                    Console.WriteLine("Purchase Date cannot be empty");
                    continue;
                }
                if (purchaseDate.ToLower() == "q")
                {
                    break;
                }
                if (!DateTime.TryParseExact(purchaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime validDate))
                {
                    Console.WriteLine("Purchase Date is not valid date");
                    continue;
                }
                Console.Write("Enter Price in USD: ");
                string purchasePrice = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(purchasePrice))
                {
                    Console.WriteLine("Price cannot be empty");
                    continue;
                }
                if (purchasePrice.ToLower() == "q")
                {
                    break;
                }
                if ((!decimal.TryParse(purchasePrice,
                    out decimal validPurchasePriceValue)) || (validPurchasePriceValue <= 0))
                {
                    Console.WriteLine("Purchase Price must be a positive number");
                    continue;
                }
                Console.Write("Enter Currency (DKK, EUR, GBP, SEK, or USD): ");
                string currency = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(currency))
                {
                    Console.WriteLine("Currency cannot be empty");
                    continue;
                }
                if (currency.ToLower() == "q")
                {
                    break;
                }
                if (!validCurrencies.Contains(currency.ToUpper()))
                {
                    Console.WriteLine("The only valid currencies are DKK, EUR, GBP, SEK, and USD");
                    continue;
                }
                if (type.ToLower() == "computer")
                {
                    Computer computer = new Computer(brand, model, office, validDate, validPurchasePriceValue, currency);
                    assetList.AddAsset(computer);
                }
                else if (type.ToLower() == "phone")
                {
                    Phone phone = new Phone(brand, model, office, validDate, validPurchasePriceValue, currency);
                    assetList.AddAsset(phone);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was succefully added!\n");
                Console.ResetColor();
            }
        }
    }
}
