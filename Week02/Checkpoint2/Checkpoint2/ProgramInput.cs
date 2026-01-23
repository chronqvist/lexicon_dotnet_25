using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint2
{
    internal class ProgramInput
    {
        public void AddProduct(ProductList productList)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"To enter a new product - follow the steps | To quit - enter: Q");
                Console.ResetColor();
                Console.Write("Enter a Category: ");
                string category = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Category cannot be empty");
                    continue;
                }
                if (category.ToLower() == "q")
                {
                    break;
                }
                Console.Write("Enter a Product Name: ");
                string name = Console.ReadLine();
                if (name.ToLower() == "q")
                {
                    break;
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty");
                    continue;
                }
                Console.Write("Enter a Price: ");
                string price = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(price))
                {
                    Console.WriteLine("Price cannot be empty");
                    continue;
                }
                if (price.ToLower() == "q")
                {
                    break;
                }
                if ((!decimal.TryParse(price, out decimal priceValue)) || (priceValue <= 0))
                {
                    Console.WriteLine("Price must be a positive number");
                    continue;
                }
                productList.AddProduct(new ProductItem(category, name, priceValue));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was succefully added!");
                Console.ResetColor();
                Console.WriteLine("--------------------------------------------------------");
            }
        }
        public bool InputChoice(ProductList productList)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("To enter a new product - enter : \"P\" | To search for a product - enter:   \"S\" | To quit .enter: \"Q\": ");
                Console.ResetColor();
                string choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Choice input cannot be empty");
                    productList.ListProducts();
                }
                switch (choice.ToLower())
                {
                    case "q":
                        return true;
                    case "s":
                        Console.Write("Search term: ");
                        string search = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(search))
                        {
                            Console.WriteLine("Search cannot be empty");
                        }
                        else
                        {
                            productList.ListProducts(true, search);
                        }
                        continue;
                    case "p":
                        return false;
                    default:
                        Console.WriteLine("Only P/S/Q are valid input");
                        productList.ListProducts();
                        return true;
                }

            }
        }
    }
}
