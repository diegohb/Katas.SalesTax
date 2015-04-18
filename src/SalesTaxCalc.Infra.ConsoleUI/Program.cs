// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.Program.cs
// Last Modified: 04/16/2015 11:40 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using Data;

    internal class Program
    {
        private static List<Product> _products;

        private static void Main(string[] pArguments)
        {
            _products = new List<Product>()
            {
                new Product {Name = "book", ProductType = ProductTypeEnum.Book, ShelfPrice = 12.49m},
                new Product {Name = "music CD", ProductType = ProductTypeEnum.Other, ShelfPrice = 12.49m}
            };

            var command = "";

            while (!command.ToLower().Equals("x"))
            {
                Console.WriteLine("[LP] List products");
                Console.WriteLine("[X] Quit");

                command = Console.ReadLine();
                processCommand(command);
            }
        }

        private static void processCommand(string pCommand)
        {
            var cmd = pCommand.ToUpper();
            switch (cmd)
            {
                case "LP":
                    listProducts();
                    break;
                case "X":
                    Console.WriteLine("Now exiting...");
                    return;
                default:
                    Console.WriteLine("Unrecognized command '{0}'. Please try again.", cmd);
                    return;
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        private static void listProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine("{0} - {1} at {2:C2}", product.ProductID, product.Name, product.ShelfPrice);
            }
            
            Console.WriteLine("Finished listing products.");
        }
    }
}