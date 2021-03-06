﻿// *************************************************
// SalesTaxCalc.Domain.Core.Percentage.cs
// Last Modified: 04/20/2015 11:03 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.ValueObjects
{
    using System;

    /// <summary>
    /// Value type that represents a percent value of 100.
    /// </summary>
    public class Percentage : IValueObject, IEquatable<Percentage>
    {
        private readonly decimal _percentageValue;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage" /> class.
        /// </summary>
        /// <param name="pPercentageValue">The integer percentage value.</param>
        public Percentage(int pPercentageValue)
        {
            _percentageValue = Convert.ToDecimal(pPercentageValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage"/> class.
        /// </summary>
        /// <param name="pPercentageValue">The decimal percentage value.</param>
        public Percentage(decimal pPercentageValue)
        {
            _percentageValue = pPercentageValue;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the percentage value.
        /// </summary>
        /// <value>
        /// The percentage value.
        /// </value>
        public decimal PercentageValue
        {
            get { return _percentageValue; }
        }

        /// <summary>
        /// Gets the actual value.
        /// </summary>
        /// <value>
        /// The actual value is the <see cref="PercentageValue" /> divided by 100.
        /// </value>
        public decimal ActualValue
        {
            get { return PercentageValue/100m; }
        }

        #endregion

        public override string ToString()
        {
            /*NOTE: 
             * assumption - round up to second decimal.
             * Will format to percentage respecting current culture. 
             * reference https://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.100).aspx#PFormatString
             */
            return ActualValue.ToString("P2");
        }

        #region Value Equality

        /// <summary>
        /// Determines equality with the other specified <see cref="Percentage"/> object.
        /// </summary>
        /// <param name="pOtherPercentage">The other percentage object.</param>
        /// <returns><c>true</c> if are equal value.</returns>
        public bool Equals(Percentage pOtherPercentage)
        {
            if (ReferenceEquals(null, pOtherPercentage)) return false;
            if (ReferenceEquals(this, pOtherPercentage)) return true;
            return _percentageValue == pOtherPercentage._percentageValue;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return _percentageValue.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="pOtherObject">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object pOtherObject)
        {
            if (ReferenceEquals(null, pOtherObject)) return false;
            if (ReferenceEquals(this, pOtherObject)) return true;
            if (pOtherObject.GetType() != this.GetType()) return false;
            return Equals((Percentage) pOtherObject);
        }

        public static bool operator ==(Percentage pLeft, Percentage pRight)
        {
            return Equals(pLeft, pRight);
        }

        public static bool operator !=(Percentage pLeft, Percentage pRight)
        {
            return !Equals(pLeft, pRight);
        }

        #endregion

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="pLeft">The left.</param>
        /// <param name="pRight">The right.</param>
        /// <returns>
        /// The resultant <see cref="Percentage"/> object with values added.
        /// </returns>
        public static Percentage operator +(Percentage pLeft, Percentage pRight)
        {
            return new Percentage(pLeft.PercentageValue + pRight.PercentageValue);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="pLeft">The left.</param>
        /// <param name="pRight">The right.</param>
        /// <returns>
        /// The resultant <see cref="Percentage"/> object with values subtracted.
        /// </returns>
        public static Percentage operator -(Percentage pLeft, Percentage pRight)
        {
            return new Percentage(pLeft.PercentageValue - pRight.PercentageValue);
        }
    }
}