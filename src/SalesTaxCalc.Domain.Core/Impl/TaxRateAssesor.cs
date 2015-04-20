// *************************************************
// SalesTaxCalc.Domain.Core.TaxRateAssesor.cs
// Last Modified: 04/20/2015 6:46 PM
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

        public decimal GetApplicableTaxRateForProduct(bool pIsExempt, bool pIsImported)
        {
            throw new NotImplementedException();
        }
    }
}