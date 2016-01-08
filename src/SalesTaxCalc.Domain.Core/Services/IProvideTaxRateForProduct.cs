// *************************************************
// SalesTaxCalc.Domain.Core.IProvideTaxRateForProduct.cs
// Last Modified: 04/20/2015 7:33 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Services
{
    using ValueObjects;

    public interface IProvideTaxRateForProduct
    {
        ProductCategoryEnum[] GetExemptCategories();

        bool IsProductCategoryExemptFromBaseTax(ProductCategoryEnum pProductCategory);
        
        Percentage GetApplicableTaxRateForProduct(bool pIsExempt, bool pIsImported);

        Percentage GetApplicableTaxRateForProduct(ProductCategoryEnum pProductCategory, bool pIsImported);
    }
}