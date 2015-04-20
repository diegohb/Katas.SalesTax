// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPrice.cs
// Last Modified: 04/20/2015 9:37 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    using System;

    public class ProductPrice : IValueObject
    {
        public ProductPrice(decimal pBasePrice, decimal pTaxRate)
        {
            throw new NotImplementedException();
        }

        public decimal TaxAmount { get; private set; }
    }
}