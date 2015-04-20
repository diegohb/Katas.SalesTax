// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPriceTests.cs
// Last Modified: 04/20/2015 10:30 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.ValueObjectTests
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Core.Impl;
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

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ProductPrice_GetRoundedTotalShouldReturnTrueTotalRoundedToOneTwentiethPerStrategy()
        {
            //ARRANGE
            var roundingStrategy = new RoundUpToNearestOneTwentiethRoundingRule();
            const decimal expectedTrueTotal = basePrice + (basePrice*taxRate);
            var expectedRoundedTotal = roundingStrategy.GetRoundedValue(expectedTrueTotal);

            //ACT
            var productPrice = new ProductPrice(basePrice, taxRate);

            //ASSERT
            Assert.AreEqual(expectedTrueTotal, productPrice.TrueTotal);

            Assert.AreEqual(expectedRoundedTotal, productPrice.GetRoundedTotal(roundingStrategy));
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ProductPrice_EqualProductPriceObjectsShouldReturnEqualityTrue()
        {
            //ARRANGE
            var productPriceUnderTest = new ProductPrice(basePrice, taxRate);

            //ACT
            var expectedProductPrice = new ProductPrice(basePrice, taxRate);
            var differentProducPrice = new ProductPrice(basePrice, 0.1m);
            var copyRef = expectedProductPrice;

            //ASSERT
            Assert.IsTrue(productPriceUnderTest.Equals(expectedProductPrice));
            Assert.IsFalse(productPriceUnderTest.Equals(differentProducPrice));
            Assert.IsTrue(productPriceUnderTest == expectedProductPrice);
            Assert.IsFalse(productPriceUnderTest == differentProducPrice);

            Assert.IsTrue(expectedProductPrice.Equals(copyRef));
            Assert.AreEqual(expectedProductPrice, copyRef);
        }
    }
}