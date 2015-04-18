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
        private static void Main(string[] pArguments)
        {
            var products = new List<Product>()
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
            }
        }
    }
}