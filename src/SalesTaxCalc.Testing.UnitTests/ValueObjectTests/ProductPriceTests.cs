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
        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ProductPrice_TaxAmountShouldEquateToBasePriceMultipliedByTaxRate()
        {
            //ARRANGE
            const decimal basePrice = 11.85m;
            const decimal taxRate = 0.15m;
            const decimal expectedTaxAmount = basePrice*taxRate;

            //ACT
            var productPrice = new ProductPrice(basePrice, taxRate);

            //ASSERT
            Assert.AreEqual(expectedTaxAmount, productPrice.TaxAmount);
        }
    }
}