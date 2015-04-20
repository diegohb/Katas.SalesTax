﻿// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPriceTests.cs
// Last Modified: 04/20/2015 9:53 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.ValueObjectTests
{
    using System;
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

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ProductPrice_GetRoundedTotalShouldReturnTrueTotalRoundedToOneTwentieth()
        {
            //ARRANGE
            const decimal expectedTrueTotal = basePrice + (basePrice*taxRate);
            var expectedRoundedTotal = roundToNearestOneTwentieth(expectedTrueTotal);

            //ACT
            var productPrice = new ProductPrice(basePrice, taxRate);

            //ASSERT
            Assert.AreEqual(expectedTrueTotal, productPrice.TrueTotal);
            Assert.AreEqual(expectedRoundedTotal, productPrice.GetRoundedTotal());
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

        private decimal roundToNearestOneTwentieth(decimal pValue)
        {
            //ref: http://stackoverflow.com/a/1448465/1240322
            return Math.Ceiling(pValue*20)/20;
        }
    }
}