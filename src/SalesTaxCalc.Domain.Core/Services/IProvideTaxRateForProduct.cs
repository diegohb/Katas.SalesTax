// *************************************************
// SalesTaxCalc.Domain.Core.IProvideTaxRateForProduct.cs
// Last Modified: 04/20/2015 6:46 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Services
{
    public interface IProvideTaxRateForProduct
    {
        decimal GetApplicableTaxRateForProduct(bool pIsExempt, bool pIsImported);
    }
}