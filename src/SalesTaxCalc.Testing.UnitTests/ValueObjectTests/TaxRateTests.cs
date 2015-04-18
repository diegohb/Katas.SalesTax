// *************************************************
// SalesTaxCalc.Testing.UnitTests.TaxRateTests.cs
// Last Modified: 04/17/2015 8:37 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.ValueObjectTests
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class TaxRateTests
    {
        private readonly Percentage _basicSalesTax = new Percentage(10);
        private Percentage _importTaxTariff = new Percentage(5);

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void BasicSalesTax_ShouldBeTenPercent()
        {
            //arrange
            const decimal expectedActualValue = 0.1m;
            const string expectedPercentageValueFormatted = "10.00 %";
            
            //act
            var actualActualValue = _basicSalesTax.ActualValue;
            var actualFormattedPercentageValue = _basicSalesTax.ToString();

            //assert
            Assert.AreEqual(expectedActualValue, actualActualValue);
            Assert.AreEqual(expectedPercentageValueFormatted, actualFormattedPercentageValue);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void ImportTariff_ShouldBeFivePercent()
        {
            //arrange
            //act
            //assert
        }
    }
}