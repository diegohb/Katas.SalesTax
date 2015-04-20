// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPrice.cs
// Last Modified: 04/20/2015 9:53 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    using System;

    public class ProductPrice : IValueObject
    {
        private readonly decimal _basePrice;
        private readonly decimal _taxRate;

        public ProductPrice(decimal pBasePrice, decimal pTaxRate)
        {
            _basePrice = pBasePrice;
            _taxRate = pTaxRate;
        }

        public decimal TaxAmount
        {
            get { return _basePrice*_taxRate; }
        }

        public decimal TrueTotal
        {
            get { return _basePrice + TaxAmount; }
        }

        public decimal GetRoundedTotal()
        {
            //ref: http://stackoverflow.com/a/1448465/1240322
            return Math.Ceiling(TrueTotal*20)/20;
        }
    }
}