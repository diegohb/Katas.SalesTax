using NUnit.Framework;
using SalesTaxCalc.Domain.Core;
using SalesTaxCalc.Domain.Core.Data;
using SalesTaxCalc.Domain.Core.Impl;

using SalesTaxCalc.Domain.Core.ValueObjects;

namespace SalesTaxCalc.Testing.UnitTests.Data
{
  [TestFixture]
  public class ProductTests
  {
    [Test]
    public void TestProductTaxAssessment()
    {
      var taxAssessor = new TaxRateAssesor(new Percentage(10), new Percentage(5));

      var p1 = new Product(1, "TEST", 10.00m) { IsImported = true, ProductType = ProductCategoryEnum.Other };
      Assert.AreEqual(0.15d, taxAssessor.GetApplicableTaxRateForProduct(p1.ProductType, p1.IsImported).ActualValue);
    }

  }
}
