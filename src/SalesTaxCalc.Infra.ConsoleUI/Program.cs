﻿// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.Program.cs
// Last Modified: 04/18/2015 1:26 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    internal class Program
    {
        private const decimal baseSalesTaxValue = 0.1m;
        private const decimal importTariffValue = .05m;

        private static List<Product> _products;
        private static int _nextProductID;

        private static void Main(string[] pArguments)
        {
            initializeInventory();

            var command = "";

            var mainMenu = new Dictionary<string, string>() { { "P", "Products" }, { "N", "New Shopping Cart" } };
            presentMenu(mainMenu, "x", processCommand);
            Console.WriteLine("Thank you, come again...");
        }

        private static void processCommand(string pCommand)
        {
            switch (pCommand)
            {
                case "P":
                    productMenu();
                    break;
                case "L":
                    listProducts();
                    break;
                case "N":
                    shoppingCartMenu();
                    break;
                default:
                    Console.WriteLine("Unrecognized command '{0}'. Please try again.", pCommand);
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        #region Input Command Processors

        private static void productMenu()
        {
            Console.Clear();
            Console.WriteLine("PRODUCTS");

            var productMenu = new Dictionary<string, string>() {{"L", "List all products"}};
            presentMenu(productMenu, "", processCommand);

        }

        private static void listProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine("{0} - {1} at {2:C2}", product.ProductID, product.Name, product.ShelfPrice);
            }

            Console.WriteLine("Finished listing products.");
        }

        private static void shoppingCartMenu()
        {
            Console.Clear();
            Console.WriteLine("Quick Checkout");
        }

        #endregion

        #region Support Methods

        private static void presentMenu(Dictionary<string, string> pMenu, string pExitCmd, Action<string> pMenuCommandHandler)
        {
            var command = "";
            while (!command.Equals(pExitCmd, StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (var menuItem in pMenu)
                    Console.WriteLine("[{0}] {1}", menuItem.Key, menuItem.Value);

                Console.WriteLine("[{0}] Exit", pExitCmd);

                command = Console.ReadLine() ?? "";
                if (pMenu.Select(pItem => pItem.Key).Any(pItem => pItem.Equals(command, StringComparison.CurrentCultureIgnoreCase)))
                    pMenuCommandHandler.Invoke(command.ToUpper());
            }
        }

        private static void initializeInventory()
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
        }

        private static Product createProduct
            (string pName, decimal pShelfPrice, bool pIsImported = false, ProductTypeEnum pType = ProductTypeEnum.Other)
        {
            var basicSalesTaxApplicable = pType == ProductTypeEnum.Other ? baseSalesTaxValue : 0m;
            var importTariffApplicable = pIsImported ? importTariffValue : 0m;
            var assessedTaxValue = basicSalesTaxApplicable + importTariffApplicable;
            var product = new Product(getNextProductID(), pName, pShelfPrice) { ProductType = pType, TaxRateValue = assessedTaxValue };
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