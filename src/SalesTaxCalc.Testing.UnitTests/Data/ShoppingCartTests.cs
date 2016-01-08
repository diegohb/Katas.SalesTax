// *************************************************
// SalesTaxCalc.Testing.UnitTests.ShoppingCartTests.cs
// Last Modified: 01/08/2016 2:50 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Core;
    using Domain.Core.Data;
    using Domain.Core.Impl;
    using Domain.Core.Services;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class ShoppingCartTests
    {
        private List<Product> _products;
        private IProvideTaxRateForProduct _taxAssessor;
        private static IRoundingStrategy _roundingStrategy;

        [TestFixtureSetUp]
        public void Setup()
        {
            var id = 0;
            _products = new List<Product>()
            {
                createProduct(id++, "book", 12.49m, pType: ProductCategoryEnum.Books),
                createProduct(id++, "music CD", 14.99m),
                createProduct(id++, "chocolate bar", 0.85m, pType: ProductCategoryEnum.Food),
                createProduct(id++, "imported box of chocolates", 10m, true, ProductCategoryEnum.Food),
                createProduct(id++, "imported bottle of perfume", 47.50m, true),
                createProduct(id++, "imported bottle of perfume", 27.99m, true),
                createProduct(id++, "bottle of perfume", 18.99m),
                createProduct(id++, "packet of headache pills", 9.75m, pType: ProductCategoryEnum.Medical),
                createProduct(id++, "box of imported chocolates", 11.25m, true, ProductCategoryEnum.Food)
            };
            _taxAssessor = new TaxRateAssesor(new Percentage(10), new Percentage(5));
            _roundingStrategy = new RoundUpToNearestOneTwentiethRoundingRule();
        }

        [Test]
        public void TestScenario1()
        {
            var cart = new ShoppingCart(_taxAssessor, _roundingStrategy);
            cart.AddItem(getProduct("book"), 2);
            cart.AddItem(getProduct("music CD"), 1);
            cart.AddItem(getProduct("chocolate bar"), 1);
            var items = cart.GetLineItems().ToList();
            Assert.AreEqual(3, items.Count());
            Assert.AreEqual("book: 24.98 (2 @ 12.49)", items[0].PrintableMessage);
            Assert.AreEqual("music CD: 16.49", items[1].PrintableMessage);
            Assert.AreEqual("chocolate bar: 0.85", items[2].PrintableMessage);
            Assert.AreEqual(1.50m, cart.GetTotalSalesTax());
            Assert.AreEqual(42.32m, cart.GetGrandTotal());
        }

        [Test]
        public void TestScenario2()
        {
            var cart = new ShoppingCart(_taxAssessor, _roundingStrategy);
            cart.AddItem(getProduct("imported box of chocolates"), 1);
            cart.AddItem(getProduct("imported bottle of perfume", 47.50m), 1);
            var items = cart.GetLineItems().ToList();
            Assert.AreEqual(2, items.Count());
            Assert.AreEqual("imported box of chocolates: 10.50", items[0].PrintableMessage);
            Assert.AreEqual("imported bottle of perfume: 54.65", items[1].PrintableMessage);
            Assert.AreEqual(7.65m, cart.GetTotalSalesTax());
            Assert.AreEqual(65.15m, cart.GetGrandTotal());
        }

        [Test]
        public void TestScenario3()
        {
            var cart = new ShoppingCart(_taxAssessor, _roundingStrategy);
            cart.AddItem(getProduct("imported bottle of perfume", 27.99m), 1);
            cart.AddItem(getProduct("bottle of perfume"), 1);
            cart.AddItem(getProduct("packet of headache pills"), 1);
            cart.AddItem(getProduct("box of imported chocolates"), 2);
            var items = cart.GetLineItems().ToList();
            Assert.AreEqual(4, items.Count());
            Assert.AreEqual("imported bottle of perfume: 32.19", items[0].PrintableMessage);
            Assert.AreEqual("bottle of perfume: 20.89", items[1].PrintableMessage);
            Assert.AreEqual("packet of headache pills: 9.75", items[2].PrintableMessage);
            Assert.AreEqual("box of imported chocolates: 23.70 (2 @ 11.85)", items[3].PrintableMessage);
            Assert.AreEqual(7.30m, cart.GetTotalSalesTax());
            Assert.AreEqual(86.53m, cart.GetGrandTotal());
        }

        private Product createProduct
            (int pID, string pName, decimal pShelfPrice, bool pIsImported = false, ProductCategoryEnum pType = ProductCategoryEnum.Other)
        {
            var product = new Product(pID, pName, pShelfPrice) {ProductType = pType, IsImported = pIsImported};
            return product;
        }

        private Product getProduct(string pName)
        {
            return _products.FirstOrDefault(pProduct => pProduct.Name == pName);
        }

        private Product getProduct(string pName, decimal pPrice)
        {
            return _products.FirstOrDefault(pProduct => pProduct.Name == pName && pProduct.ShelfPrice == pPrice);
        }
    }
}