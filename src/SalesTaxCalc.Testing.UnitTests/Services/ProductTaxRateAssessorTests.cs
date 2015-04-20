// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductTaxRateAssessorTests.cs
// Last Modified: 04/20/2015 6:46 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Services
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Core.Impl;
    using Domain.Core.Services;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTaxRateAssessorTests
    {
        private IProvideTaxRateForProduct _taxRateAssesor;

        [TestFixtureSetUp]
        public void Setup()
        {
            _taxRateAssesor = new TaxRateAssesor(new Percentage(10), new Percentage(5));
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TaxRateAssessor_ShouldReturnNonExemptTaxRate()
        {
            //ARRANGE
            const decimal expectedRate = 0.10m;

            //ACT
            var actualRate = _taxRateAssesor.GetApplicableTaxRateForProduct(false, false);

            //ASSERT
            Assert.AreEqual(expectedRate, actualRate);
        }
    }
}