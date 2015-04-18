// *************************************************
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
        private static ShoppingCart _activeCart;
        private static int _nextProductID;

        private static void Main(string[] pArguments)
        {
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
            {
                Console.WriteLine("{0} - {1} at {2:C2}", product.ProductID, product.Name, product.ShelfPrice);
            }
            Console.WriteLine("Finished listing products.");
        }

        private static void shoppingCartMenu()
        {
            _activeCart = new ShoppingCart();
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
            Console.WriteLine("Choose an item to add your cart.");
            var menu = _products.ToDictionary(p => p.ProductID.ToString(), p => p.Name);
            presentMenu
                ("Add items to cart", menu, "0", pMenuItem =>
                {
                    if (pMenuItem.Equals("0"))
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

                    _activeCart.AddItem(product, 1);
                    Console.WriteLine("Added item '{0}' to your cart.", product.Name);
                });
        }

        private static void viewItemsInCart()
        {
            Console.WriteLine("{0} item{1} currently in cart:", _activeCart.Items.Count, _activeCart.Items.Count > 1 ? "s" : string.Empty);
            foreach (var cartItem in _activeCart.Items)
            {
                Console.WriteLine("{0} {1}", 1, cartItem.Name);
            }

        }

        #endregion

        #region Support Methods

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