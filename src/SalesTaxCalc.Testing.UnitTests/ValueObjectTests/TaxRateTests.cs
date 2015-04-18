// *************************************************
// SalesTaxCalc.Testing.UnitTests.TaxRateTests.cs
// Last Modified: 04/17/2015 8:06 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.ValueObjectTests
{
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;

    [TestFixture]
    public class TaxRateTests
    {
        private TaxRate _basicSalesTax = new TaxRate(10);
        private TaxRate _importTaxRate = new TaxRate(5);

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
        public void ImportSalesTax_ShouldBeFivePercent()
        {
            //arrange
            //act
            //assert
        }
    }
}