// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPricingServiceTests.cs
// Last Modified: 04/20/2015 7:59 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Services
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Core.Impl;
    using Domain.Core.Services;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class ProductPricingServiceTests
    {
        private IPriceProduct _productPricer;
        private readonly Percentage _baseSalesTax = new Percentage(10);
        private readonly Percentage _importTariff = new Percentage(5);

        [TestFixtureSetUp]
        public void Setup()
        {
            var taxService = new TaxRateAssesor(_baseSalesTax, _importTariff);
            _productPricer = new ProductPricingService(taxService);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ProductPricing_ShouldReturnCorrectPricingForProducts()
        {
            //ARRANGE
            var testData = new List<TestPricingData>()
            {
                //TODO: fix the values for isExcluded.
                new TestPricingData(12.49m, true, false),
                new TestPricingData(14.99m, 16.49m, false, false),
                new TestPricingData(0.85m, false, false),
                new TestPricingData(10m, 10.50m, true, false),
                new TestPricingData(47.50m, 54.65m, true, false),
                new TestPricingData(27.99m, 32.19m, true, false),
                new TestPricingData(18.99m, 20.89m, true, false),
                new TestPricingData(9.75m, true, false),
                new TestPricingData(11.25m, 11.85m, true, false)
            };

            //ACT & ASSERT
            foreach (var testPricingData in testData) {}
        }

        private class TestPricingData
        {
            private decimal? _expectedPrice;

            public TestPricingData(decimal pPrice, bool pIsExempt, bool pIsImported)
            {
                Price = pPrice;
                IsExempt = pIsExempt;
                IsImported = pIsImported;
            }

            public TestPricingData(decimal pPrice, decimal pExpectedPrice, bool pIsExempt, bool pIsImported)
                : this(pPrice, pIsExempt, pIsImported)
            {
                _expectedPrice = pExpectedPrice;
            }

            public decimal Price { get; private set; }

            public decimal ExpectedPrice
            {
                get { return _expectedPrice ?? Price; }
                private set { _expectedPrice = value; }
            }

            public bool IsExempt { get; private set; }
            public bool IsImported { get; private set; }
        }
    }
}