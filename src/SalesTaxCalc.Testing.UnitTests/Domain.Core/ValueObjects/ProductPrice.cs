// *************************************************
// SalesTaxCalc.Testing.UnitTests.ProductPrice.cs
// Last Modified: 04/20/2015 10:30 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    using System;

    /// <summary>
    /// Represents the base price, tax amount, and total values of a single product. 
    /// </summary>
    public class ProductPrice : IValueObject, IEquatable<ProductPrice>
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
        public decimal GetRoundedTotal(IRoundingStrategy pRoundingStrategy)
        {
            try
            {
                return pRoundingStrategy.GetRoundedValue(TrueTotal);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Failed to apply rounding strategy to value '{0:0.00}'", TrueTotal), e);
            }
        }

        #region Equality Members

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="pOther">The other.</param>
        /// <returns></returns>
        public bool Equals(ProductPrice pOther)
        {
            if (ReferenceEquals(null, pOther)) return false;
            if (ReferenceEquals(this, pOther)) return true;
            return _basePrice == pOther._basePrice && _taxRate == pOther._taxRate;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="pObj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object pObj)
        {
            if (ReferenceEquals(null, pObj)) return false;
            if (ReferenceEquals(this, pObj)) return true;
            if (pObj.GetType() != typeof (ProductPrice)) return false;
            return Equals((ProductPrice) pObj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (_basePrice.GetHashCode()*397) ^ _taxRate.GetHashCode();
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="pLeft">The left.</param>
        /// <param name="pRight">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(ProductPrice pLeft, ProductPrice pRight)
        {
            return Equals(pLeft, pRight);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="pLeft">The left.</param>
        /// <param name="pRight">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(ProductPrice pLeft, ProductPrice pRight)
        {
            return !Equals(pLeft, pRight);
        }

        #endregion
    }
}