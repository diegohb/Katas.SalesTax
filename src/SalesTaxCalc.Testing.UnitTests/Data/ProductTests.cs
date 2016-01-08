// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductTests.cs
// Last Modified: 01/08/2016 2:50 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Data
{
    using Domain.Core;
    using Domain.Core.Data;
    using Domain.Core.Impl;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void TestProductTaxAssessment()
        {
            var taxAssessor = new TaxRateAssesor(new Percentage(10), new Percentage(5));

            var p1 = new Product(1, "TEST", 10.00m) {IsImported = true, ProductType = ProductCategoryEnum.Other};
            Assert.AreEqual(0.15d, taxAssessor.GetApplicableTaxRateForProduct(p1.ProductType, p1.IsImported).ActualValue);
        }
    }
}