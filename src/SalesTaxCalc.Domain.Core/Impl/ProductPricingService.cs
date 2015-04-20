// *************************************************
// SalesTaxCalc.Domain.Core.ProductPricingService.cs
// Last Modified: 04/20/2015 7:57 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Impl
{
    using Services;

    public class ProductPricingService : IPriceProduct
    {
        private IProvideTaxRateForProduct _taxService;

        public ProductPricingService(IProvideTaxRateForProduct pTaxAssessor)
        {
            _taxService = pTaxAssessor;
        }
    }
}