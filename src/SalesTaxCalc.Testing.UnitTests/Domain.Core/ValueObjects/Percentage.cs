// *************************************************
// SalesTaxCalc.Testing.UnitTests.Percentage.cs
// Last Modified: 04/17/2015 9:28 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    using System;

    /// <summary>
    /// Value type that represents a percent value of 100.
    /// </summary>
    public class Percentage : IValueObject, IEquatable<Percentage>
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

        /// <summary>
        /// Gets or sets the percentage value.
        /// </summary>
        /// <value>
        /// The percentage value.
        /// </value>
        public decimal PercentageValue { get; private set; }

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

        public bool Equals(Percentage pOtherPercentage)
        {
            return pOtherPercentage != null && PercentageValue.Equals(pOtherPercentage.PercentageValue);
        }

        public override string ToString()
        {
            /*NOTE: 
             * assumption - round up to second decimal.
             * Will format to percentage respecting current culture. 
             * reference https://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.100).aspx#PFormatString
             */
            return ActualValue.ToString("P2");
        }

        public override int GetHashCode()
        {
            return PercentageValue.GetHashCode();
        }

        public override bool Equals(object pOtherObject)
        {
            var percentageObj = pOtherObject as Percentage;
            if (percentageObj == null)
                return false;

            return PercentageValue.Equals(percentageObj.PercentageValue);
        }
    }
}