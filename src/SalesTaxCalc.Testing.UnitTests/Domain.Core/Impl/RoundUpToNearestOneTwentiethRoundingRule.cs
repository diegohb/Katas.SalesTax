// *************************************************
// SalesTaxCalc.Testing.UnitTests.RoundUpToNearestOneTwentiethRoundingRule.cs
// Last Modified: 04/20/2015 10:30 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.Impl
{
    using System;

    /// <summary>
    /// Applies rounding up from precise value to nearest 0.05.
    /// </summary>
    internal class RoundUpToNearestOneTwentiethRoundingRule : IRoundingStrategy
    {
        public decimal GetRoundedValue(decimal pPreciseValue)
        {
            //ref: http://stackoverflow.com/a/1448465/1240322
            return Math.Ceiling(pPreciseValue*20)/20;
        }
    }
}