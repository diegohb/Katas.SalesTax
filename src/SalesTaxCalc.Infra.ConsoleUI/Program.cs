﻿// *************************************************
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
        private static int _nextProductID = 0;

        private static void Main(string[] pArguments)
        {
            _products = new List<Product>()
            {
                createProduct("book", 12.49m, pType: ProductTypeEnum.Book),
                createProduct("music CD", 14.99m),
                createProduct("chocolate bar", 0.85m, pType: ProductTypeEnum.Food),
                createProduct("imported box of chocolates", 10m, true, ProductTypeEnum.Food),
                createProduct("imported bottle of perfume", 47.50m, true),
                createProduct("imported bottle of perfume", 27.99m, true),
                createProduct("bottle of perfume", 18.99m),
                createProduct("packet of headache pills", 9.75m, pType: ProductTypeEnum.Medical),
                createProduct("box of imported chocolates", 11.25m, true, ProductTypeEnum.Food)
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
                    Console.WriteLine("Thank you, come again...");
                    return;
                default:
                    Console.WriteLine("Unrecognized command '{0}'. Please try again.", cmd);
                    return;
            }

            Console.WriteLine();
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

        #region Support Methods

        private static Product createProduct(string pName, decimal pShelfPrice, bool pIsImported = false, ProductTypeEnum pType = ProductTypeEnum.Other)
        {
            var product = new Product(getNextProductID(), pName, pShelfPrice) {ProductType = pType};
            return product;
        }

        private static int getNextProductID()
        {
            _nextProductID++;
            return _nextProductID;
        }

        #endregion

    }
}