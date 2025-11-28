// Assignment: Checkpoint2 Product list
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

//using System;
//using System.Collections.Generic;
//using System.Text;
using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

namespace Checkpoint2
{
    internal class ProductList
    {
        List<ProductItem> products = new List<ProductItem>();
        public void AddProduct(ProductItem product)
        {
            products.Add(product);
        }
        public void ListProducts()
        {
            ListProducts(false, "");
        }
        public void ListProducts(bool highlight, string searchString)
        {
            List<ProductItem> ordedProducts = products.OrderBy(p => p.Price).ToList();
            Console.WriteLine("--------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-20} {1,-20} {2,-10:F2}", "Category", "Name", "Price");
            Console.ResetColor();
            foreach (var product in ordedProducts)
            {
                bool matchCategory = product.Category.Contains(searchString);
                bool matchName = product.Name.Contains(searchString);


                if (highlight && (matchCategory || matchName))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("{0,-20} {1,-20} {2,10:F2}", product.Category, product.Name, product.Price);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,10:F2}", product.Category, product.Name, product.Price);
                }
            }
            if (!highlight)
            {
                decimal totalPrice = products.Sum(p => p.Price);
                Console.WriteLine("\n{0,-20} {1,-20} {2,10:F2}", "", "Total amount:", totalPrice);
            }
            Console.WriteLine("--------------------------------------------------------");
        }
    }
}
