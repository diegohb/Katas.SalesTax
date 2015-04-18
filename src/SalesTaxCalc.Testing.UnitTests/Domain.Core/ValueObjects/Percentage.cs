// *************************************************
// SalesTaxCalc.Testing.UnitTests.Percentage.cs
// Last Modified: 04/17/2015 8:54 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    using System;

    /// <summary>
    /// Value type that represents a percent value of 100.
    /// </summary>
    public class Percentage : IValueObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage" /> class.
        /// </summary>
        /// <param name="pValue">The integer value.</param>
        public Percentage(int pValue)
        {
            Value = Convert.ToDecimal(pValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage"/> class.
        /// </summary>
        /// <param name="pValue">The decimal value.</param>
        public Percentage(decimal pValue)
        {
            Value = pValue;
        }

        #endregion

        public decimal Value { get; set; }
    }
}