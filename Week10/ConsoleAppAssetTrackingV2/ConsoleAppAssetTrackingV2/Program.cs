// See https://aka.ms/new-console-template for more information
using ConsoleAppAssetTrackingV2;
using Microsoft.EntityFrameworkCore;

// Console.WriteLine("Hello, World!");


// AssetDbContext Context = new AssetDbContext();

//Context.Database.Migrate();

/*
// Seed data
Product Product1 = new Product();
Product1.ProductName = "Mobile phone";
Product Product2 = new Product();
Product2.ProductName = "Smart watch";
Product Product3 = new Product();
Product3.ProductName = "Laptop";
Product Product4 = new Product();
Product4.ProductName = "Desktop";
List<Product> MyProducts = new List<Product>();
MyProducts.Add(Product1);
MyProducts.Add(Product2);
MyProducts.Add(Product3);
MyProducts.Add(Product4);
Context.Products.AddRange(MyProducts);


Office Office1 = new Office();
Office1.OfficeName = "San Francisco";
Office Office2 = new Office();
Office2.OfficeName = "Copenhagen";
Office Office3 = new Office();
Office3.OfficeName = "Tokyo";
Office Office4 = new Office();
Office4.OfficeName = "New York";
Office Office5 = new Office();
Office5.OfficeName = "London";
List<Office> MyOffices = new List<Office>();
MyOffices.Add(Office1);
MyOffices.Add(Office2);
MyOffices.Add(Office3);
MyOffices.Add(Office4);
MyOffices.Add(Office5);
Context.Offices.AddRange(MyOffices);


Currency Currency1 = new Currency();
Currency1.CurrencyName = "USD";
Currency1.ExchangeRate = 1.00m;
Currency Currency2 = new Currency();
Currency2.CurrencyName = "DKK";
Currency2.ExchangeRate = 6.386m;
Currency Currency3 = new Currency();
Currency3.CurrencyName = "GBP";
Currency3.ExchangeRate = 0.74m;
Currency Currency4 = new Currency();
Currency4.CurrencyName = "JPY";
Currency4.ExchangeRate = 158.54m;
List<Currency> MyCurrencies = new List<Currency>();
MyCurrencies.Add(Currency1);
MyCurrencies.Add(Currency2);
MyCurrencies.Add(Currency3);
MyCurrencies.Add(Currency4);
Context.Currencies.AddRange(MyCurrencies);

// Save changes to the database
Context.SaveChanges();


Asset asset1 = new Asset();
asset1.Brand = "Apple";
asset1.Model = "iPhone 13";
asset1.PurchasePriceUSD = 999.00m;
asset1.PurchaseDate = new DateTime(2022, 03, 01);
asset1.ProductId = 1; // Mobile phone
asset1.OfficeId = 2; // Copenhagen
asset1.CurrencyId = 1; // USD
Context.Assets.Add(asset1);
Asset asset2 = new Asset();
asset2.Brand = "Samsung";
asset2.Model = "Galaxy S21";
asset2.PurchasePriceUSD = 799.00m;
asset2.PurchaseDate = new DateTime(2022, 04, 15);
asset2.ProductId = 1; // Mobile phone
asset2.OfficeId = 1; // San Francisco
asset2.CurrencyId = 1; // USD
Context.Assets.Add(asset2);
Asset asset3 = new Asset();
asset3.Brand = "Dell";
asset3.Model = "XPS 13";
asset3.PurchasePriceUSD = 1199.00m;
asset3.PurchaseDate = new DateTime(2022, 05, 20);
asset3.ProductId = 3; // Laptop
asset3.OfficeId = 5; // London
asset3.CurrencyId = 3; // GBP
Context.Assets.Add(asset3);
Asset asset4 = new Asset();
asset4.Brand = "Apple";
asset4.Model = "MacBook Pro";
asset4.PurchasePriceUSD = 1299.00m;
asset4.PurchaseDate = new DateTime(2022, 06, 10);
asset4.ProductId = 3; // Laptop
asset4.OfficeId = 4; // New York
asset4.CurrencyId = 3;
Context.Assets.Add(asset4);
Asset asset5 = new Asset();
asset5.Brand = "Sony";
asset5.Model = "WH-1000XM4";
asset5.PurchasePriceUSD = 349.00m;
asset5.PurchaseDate = new DateTime(2022, 07, 05);
asset5.ProductId = 2; // Smart watch
asset5.OfficeId = 3; // Tokyo
asset5.CurrencyId = 4; // JPY
Context.Assets.Add(asset5);
Asset asset6 = new Asset();
asset6.Brand = "Microsoft";
asset6.Model = "Surface Pro 7";
asset6.PurchasePriceUSD = 899.00m;
asset6.PurchaseDate = new DateTime(2022, 08, 18);
asset6.ProductId = 4; // Desktop
asset6.OfficeId = 1; // San Francisco
asset6.CurrencyId = 1; // USD
Context.Assets.Add(asset6);
Context.SaveChanges();
*/
// End seed data

App app = new App();
app.Run();


// Console.WriteLine("Goodbye, World!");