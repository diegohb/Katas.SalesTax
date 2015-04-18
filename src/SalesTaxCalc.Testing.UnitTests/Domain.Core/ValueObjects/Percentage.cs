// *************************************************
// SalesTaxCalc.Testing.UnitTests.Percentage.cs
// Last Modified: 04/17/2015 9:00 PM
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
        /// <param name="pPercentageValue">The integer percentage value.</param>
        public Percentage(int pPercentageValue)
        {
            PercentageValue = Convert.ToDecimal(pPercentageValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage"/> class.
        /// </summary>
        /// <param name="pPercentageValue">The decimal percentage value.</param>
        public Percentage(decimal pPercentageValue)
        {
            PercentageValue = pPercentageValue;
        }

        #endregion

        public decimal PercentageValue { get; set; }
    }
}