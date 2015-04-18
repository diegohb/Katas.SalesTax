// *************************************************
// SalesTaxCalc.Testing.UnitTests.Percentage.cs
// Last Modified: 04/17/2015 8:44 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    /// <summary>
    /// Value type that represents a percent value of 100.
    /// </summary>
    public class Percentage : IValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage"/> class.
        /// </summary>
        /// <param name="pValue">The integer value.</param>
        public Percentage(int pValue)
        {
            Value = pValue;
        }

        public decimal Value { get; set; }
    }
}