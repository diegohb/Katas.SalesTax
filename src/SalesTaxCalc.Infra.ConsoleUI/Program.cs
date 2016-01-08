// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.Program.cs
// Last Modified: 04/18/2015 5:03 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI
{
  using Domain.Core;
  using Domain.Core.Data;
  using Domain.Core.Impl;
  using Domain.Core.Services;
  using Domain.Core.ValueObjects;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  internal class Program
    {

        private static List<Product> _products;
        private static ShoppingCart _activeCart;
        private static int _nextProductID;
        private static IProvideTaxRateForProduct taxAssessor;
        private static IRoundingStrategy _roundingStrategy;

    private static void Main(string[] pArguments)
        {
            taxAssessor = new TaxRateAssesor(new Percentage(10), new Percentage(5));
            _roundingStrategy = new RoundUpToNearestOneTwentiethRoundingRule();
            initializeInventory();

            var mainMenu = new Dictionary<string, string>() { { "P", "Products" }, { "N", "New Shopping Cart" } };
            presentMenu("Main Menu", mainMenu, "X", processCommand);
            Console.WriteLine();
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
                case "A":
                    addItemToCart();
                    break;
                case "V":
                    viewItemsInCart();
                    break;
                case "R":
                    printReceipt();
                    break;
                default:
                    Console.WriteLine("Unrecognized command '{0}'. Please try again.", pCommand);
                    return;
            }
        }

        #region Input Command Processors

        private static void productMenu()
        {
            var productMenu = new Dictionary<string, string>() { { "L", "List all products" } };
            presentMenu("Products", productMenu, "X", processCommand);
        }

        private static void listProducts()
        {
            foreach (var product in _products)
                Console.WriteLine(product);

            Console.WriteLine();
        }

        private static void shoppingCartMenu()
        {
            _activeCart = new ShoppingCart(taxAssessor, _roundingStrategy);
            var shoppingCart = new Dictionary<string, string>()
            {
                {"A", "Add an item to the cart."},
                {"V", "View items in cart."},
                {"R", "View final receipt"}
            };
            presentMenu("Shopping Cart", shoppingCart, "X", processCommand);
        }

        private static void addItemToCart()
        {
            ensureActiveCartIsInitialized();

            Console.WriteLine("Choose an item to add your cart.");
            var menu = _products.ToDictionary(p => p.ProductID.ToString(), p => p.GetNameWithPrice());
            presentMenu
                ("Add items to cart", menu, "x", pMenuItem =>
                {
                    if (pMenuItem.Equals("X"))
                        return;

                    int productID;
                    if (!int.TryParse(pMenuItem, out productID))
                    {
                        Console.WriteLine("Invalid product code. Try again.");
                        return;
                    }

                    var product = _products.SingleOrDefault(pProduct => pProduct.ProductID.Equals(productID));
                    if (product == null)
                    {
                        Console.WriteLine("Product no longer exists. Choose another");
                        return;
                    }

                    Console.Write("How many '{0}' would you like to add? ", product.GetNameWithPrice());
                    int quantity;
                    if (int.TryParse(Console.ReadLine(), out quantity))
                    {
                        _activeCart.AddItem(product, quantity);
                        Console.WriteLine("Added {0} '{1}' item{2} to your cart.", quantity, product.Name, quantity > 1 ? "s" : string.Empty);
                    }
                    else
                        Console.WriteLine("Invalid quantity value. Select a product again.");
                });
        }

        private static void viewItemsInCart()
        {
            ensureActiveCartIsInitialized();

            Console.WriteLine("{0} item{1} currently in cart:", _activeCart.Items.Count, _activeCart.Items.Count > 1 ? "s" : string.Empty);
            foreach (var cartItem in _activeCart.Items)
            {
                Console.WriteLine("{0} {1}", 1, cartItem.GetNameWithPrice());
            }
        }

        private static void printReceipt()
        {
            ensureActiveCartIsInitialized();

            var lineItems = _activeCart.GetLineItems();
            var lineItemStrings = lineItems.Where(pItem => pItem.Quantity > 0)
                .Select
                (pItem => pItem.PrintableMessage);
            Console.WriteLine(string.Join("\n", lineItemStrings));

            var salesTaxTotal = _activeCart.GetTotalSalesTax();
            var grandTotal = _activeCart.GetGrandTotal();
            Console.WriteLine("Sales Taxes: {0:C2}", salesTaxTotal);
            Console.WriteLine("Total: {0:C2}", grandTotal);
            
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        #endregion

        #region Support Methods

        private static void ensureActiveCartIsInitialized()
        {
            if (_activeCart == null)
                throw new NullReferenceException("Active cart is not initialized!");
        }

        private static void presentMenu(string pMenuTitle, Dictionary<string, string> pMenu, string pExitCmd, Action<string> pMenuCommandHandler)
        {
            Console.Clear();
            string command;
            do
            {
                Console.WriteLine();
                Console.WriteLine(pMenuTitle.ToUpper());
                Console.WriteLine("***********************");

                foreach (var menuItem in pMenu)
                    Console.WriteLine("[{0}] {1}", menuItem.Key, menuItem.Value);

                Console.WriteLine("[{0}] Exit", pExitCmd);
                Console.WriteLine();
                Console.Write("Choice> ");
                command = Console.ReadLine() ?? "";
                Console.WriteLine();

                if (pMenu.Select(pItem => pItem.Key).Any(pItem => pItem.Equals(command, StringComparison.CurrentCultureIgnoreCase)))
                    pMenuCommandHandler.Invoke(command.ToUpper());
                else
                    Console.WriteLine("Invalid selection.");
            } while (!command.Equals(pExitCmd, StringComparison.CurrentCultureIgnoreCase));

            Console.Clear();
        }

        private static void initializeInventory()
        {
            _products = new List<Product>()
            {
                createProduct("book", 12.49m, pType: ProductCategoryEnum.Books),
                createProduct("music CD", 14.99m),
                createProduct("chocolate bar", 0.85m, pType: ProductCategoryEnum.Food),
                createProduct("imported box of chocolates", 10m, true, ProductCategoryEnum.Food),
                createProduct("imported bottle of perfume", 47.50m, true),
                createProduct("imported bottle of perfume", 27.99m, true),
                createProduct("bottle of perfume", 18.99m),
                createProduct("packet of headache pills", 9.75m, pType: ProductCategoryEnum.Medical),
                createProduct("box of imported chocolates", 11.25m, true, ProductCategoryEnum.Food)
            };
        }

        private static Product createProduct
            (string pName, decimal pShelfPrice, bool pIsImported = false, ProductCategoryEnum pType = ProductCategoryEnum.Other)
        {

            var product = new Product(getNextProductID(), pName, pShelfPrice) { ProductType = pType, IsImported = pIsImported };
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