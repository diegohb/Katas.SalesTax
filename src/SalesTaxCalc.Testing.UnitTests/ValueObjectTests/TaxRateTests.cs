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
        private Percentage _basicSalesTax = new Percentage(10);
        private Percentage _importTaxTariff = new Percentage(5);

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void BasicSalesTax_ShouldBeTenPercent()
        {
            //arrange
            //act
            //assert
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