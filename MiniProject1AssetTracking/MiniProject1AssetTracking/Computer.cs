// Assignment: Mini Project 1:  # Asset Tracking 
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com


namespace MiniProject1AssetTracking
{
    internal class Computer : Asset
    {
        public Computer(string brand, string model, string office, DateTime purchaseDate, Decimal purchasePrice,
            string currency) : base("Computer", brand, model, office, purchaseDate, purchasePrice, currency)
        {
        }
    }
}
