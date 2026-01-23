// Assignment: Checkpoint2 Product list
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

//using System;
//using System.Collections.Generic;
//using System.Text;

namespace Checkpoint2
{
    internal class ProductItem
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // I don't know to handle errors in a constructor
        public ProductItem(string category, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Category should not be empty");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name should not be empty");
            }
            if (price < 0)
            {
                Console.WriteLine("Price should not be negative");
            }
            Category = category;
            Name = name;
            Price = price;
        }
    }
}