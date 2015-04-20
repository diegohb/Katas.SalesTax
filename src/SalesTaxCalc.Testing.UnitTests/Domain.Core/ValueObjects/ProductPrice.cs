// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPrice.cs
// Last Modified: 04/20/2015 9:57 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    using System;

    /// <summary>
    /// Represents the base price, tax amount, and total values of a single product. 
    /// </summary>
    public class ProductPrice : IValueObject
    {
        private readonly decimal _basePrice;
        private readonly decimal _taxRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductPrice"/> class.
        /// </summary>
        /// <param name="pBasePrice">The base price.</param>
        /// <param name="pTaxRate">The tax rate.</param>
        public ProductPrice(decimal pBasePrice, decimal pTaxRate)
        {
            _basePrice = pBasePrice;
            _taxRate = pTaxRate;
        }

        #region Properties

        /// <summary>
        /// Gets the tax amount.
        /// </summary>
        /// <value>
        /// The tax amount.
        /// </value>
        public decimal TaxAmount
        {
            get { return _basePrice*_taxRate; }
        }

        /// <summary>
        /// Gets the true total value.
        /// </summary>
        /// <value>
        /// The true total value.
        /// </value>
        public decimal TrueTotal
        {
            get { return _basePrice + TaxAmount; }
        }

        #endregion

        /// <summary>
        /// Gets the rounded total.
        /// </summary>
        /// <returns>The <see cref="TrueTotal"/> value with rounding logic applied.</returns>
        public decimal GetRoundedTotal()
        {
            //ref: http://stackoverflow.com/a/1448465/1240322
            return Math.Ceiling(TrueTotal*20)/20;
        }
    }
}