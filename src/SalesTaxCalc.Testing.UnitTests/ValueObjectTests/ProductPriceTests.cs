// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPriceTests.cs
// Last Modified: 04/20/2015 9:38 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.ValueObjectTests
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class ProductPriceTests
    {
        private const decimal basePrice = 11.85m;
        private const decimal taxRate = 0.15m;

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ProductPrice_TaxAmountShouldEquateToBasePriceMultipliedByTaxRate()
        {
            //ARRANGE
            const decimal expectedTaxAmount = basePrice*taxRate;

            //ACT
            var productPrice = new ProductPrice(basePrice, taxRate);

            //ASSERT
            Assert.AreEqual(expectedTaxAmount, productPrice.TaxAmount);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ProductPrice_TrueTotalShouldEquateToBaseMultipliedByTaxAddedToBase()
        {
            //ARRANGE
            const decimal expectedTrueTotal = basePrice + (basePrice*taxRate);

            //ACT
            var productPrice = new ProductPrice(basePrice, taxRate);

            //ASSERT
            Assert.AreEqual(expectedTrueTotal, productPrice.TrueTotal);
        }
    }
}