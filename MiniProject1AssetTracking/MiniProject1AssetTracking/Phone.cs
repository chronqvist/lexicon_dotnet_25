// Assignment: Mini Project 1:  # Asset Tracking 
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com


namespace MiniProject1AssetTracking
{
    internal class Phone : Asset
    {
        public Phone(string brand, string model, string office, DateTime purchaseDate, Decimal purchasePrice,
            string currency) : base("Phone", brand, model, office, purchaseDate, purchasePrice, currency)
        {
        }
    }
}
