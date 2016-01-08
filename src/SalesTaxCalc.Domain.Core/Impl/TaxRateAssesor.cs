// *************************************************
// SalesTaxCalc.Domain.Core.TaxRateAssesor.cs
// Last Modified: 04/20/2015 7:36 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Impl
{
    using System;
    using Services;
    using ValueObjects;

    public class TaxRateAssesor : IProvideTaxRateForProduct
    {
        private readonly Percentage _basicSalesTax;
        private readonly Percentage _importTaxTariff;

        public TaxRateAssesor(Percentage pBaseSalesTax, Percentage pImportTariff)
        {
            _basicSalesTax = pBaseSalesTax;
            _importTaxTariff = pImportTariff;
        }

        public ProductCategoryEnum[] GetExemptCategories()
        {
            return new[] {ProductCategoryEnum.Books, ProductCategoryEnum.Food, ProductCategoryEnum.Medical};
        }

        public bool IsProductCategoryExemptFromBaseTax(ProductCategoryEnum pProductCategory)
        {
            return Array.IndexOf(GetExemptCategories(), pProductCategory) != -1;
        }

        public Percentage GetApplicableTaxRateForProduct(bool pIsExempt, bool pIsImported)
        {
            var rate = new Percentage(0);

            if (!pIsExempt)
                rate = _basicSalesTax;

            if (pIsImported)
                rate += _importTaxTariff;

            return rate;
        }

        public Percentage GetApplicableTaxRateForProduct(ProductCategoryEnum pProductCategory, bool pIsImported)
        {
            return GetApplicableTaxRateForProduct(IsProductCategoryExemptFromBaseTax(pProductCategory), pIsImported);
        }
    }
}