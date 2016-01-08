// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductTaxRateAssessorTests.cs
// Last Modified: 04/20/2015 6:46 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Services
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Core;
    using Domain.Core.Impl;
    using Domain.Core.Services;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTaxRateAssessorTests
    {
        private IProvideTaxRateForProduct _taxRateAssesor;
        private Percentage _baseSalesTax;
        private Percentage _importTariff;

        [TestFixtureSetUp]
        public void Setup()
        {
            _baseSalesTax = new Percentage(10);
            _importTariff = new Percentage(5);
            _taxRateAssesor = new TaxRateAssesor(_baseSalesTax, _importTariff);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TaxRateAssessor_ShouldReturnNonExemptTaxRate()
        {
            //ARRANGE
            var expectedRate = _baseSalesTax;

            //ACT
            var actualRate = _taxRateAssesor.GetApplicableTaxRateForProduct(false, false);

            //ASSERT
            Assert.AreEqual(expectedRate, actualRate);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TaxRateAssessor_ShouldReturnExemptTaxRate()
        {
            //ARRANGE
            var expectedRateValue = new Percentage(0);

            //ACT
            var actualRate = _taxRateAssesor.GetApplicableTaxRateForProduct(true, false);

            //ASSERT
            Assert.AreEqual(expectedRateValue, actualRate);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TaxRateAssessor_ShouldReturnExemptTaxRatePlusImportTariff()
        {
            //ARRANGE
            var expectedRate = _importTariff;

            //ACT
            var actualRate = _taxRateAssesor.GetApplicableTaxRateForProduct(true, true);

            //ASSERT
            Assert.AreEqual(expectedRate, actualRate);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TaxRateAssessor_ShouldReturnNonExemptTaxRatePlusImportTariff()
        {
            //ARRANGE
            var expectedRate = _baseSalesTax + _importTariff;

            //ACT
            var actualRate = _taxRateAssesor.GetApplicableTaxRateForProduct(false, true);

            //ASSERT
            Assert.AreEqual(expectedRate, actualRate);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TaxRateAssessor_IsExemptShouldReturnTrueForExemptTypes()
        {
            //ARRANGE
            var exemptTypes = new[] {ProductCategoryEnum.Books, ProductCategoryEnum.Food, ProductCategoryEnum.Medical};

            //ASSERT
            foreach (var productType in exemptTypes)
                Assert.IsTrue(_taxRateAssesor.IsProductCategoryExemptFromBaseTax(productType));
            Assert.IsFalse(_taxRateAssesor.IsProductCategoryExemptFromBaseTax(ProductCategoryEnum.Other));
        }
    }
}