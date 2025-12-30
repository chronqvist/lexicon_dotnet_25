// Assignment: Mini Project 1:  # Asset Tracking
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

using MiniProject1AssetTracking;

AssetList assetList = new AssetList();
ProgramStates programStates = new ProgramStates();

/*
DateTime today = DateTime.Today;
// 3 years - 3 months + 1 day
DateTime redDatePlus1 = today.AddMonths(-33).AddDays(1);
// 3 years - 6 months + 1 day
DateTime yellowDatePlus1 = today.AddMonths(-30).AddDays(1); // 3 years - 6 months

Computer computer1 = new Computer("Lenovo", "ThinkPad X1 Carbon", "London", redDatePlus1, 1300.00m, "GBP");
assetList.AddAsset(computer1);
Phone phone1 = new Phone("Apple", "iPhone 13", "London", yellowDatePlus1, 999.00m, "SEK");
assetList.AddAsset(phone1);
Computer computer2 = new Computer("Dell", "XPS 13", "New York", new DateTime(2022,01,15), 1200.00m, "DKK");
assetList.AddAsset(computer2);
Phone phone2 = new Phone("Samsung", "Galaxy S21", "New York", new DateTime(2022, 02, 25), 799.00m, "EUR");
assetList.AddAsset(phone2);
Computer computer3 = new Computer("Apple", "MacBook Pro", "San Francisco", new DateTime(2021,11,20), 1500.00m, "USD");
assetList.AddAsset(computer3);
assetList.ListAssets();
*/

programStates.InputProduct(assetList);
assetList.ListAssets();


