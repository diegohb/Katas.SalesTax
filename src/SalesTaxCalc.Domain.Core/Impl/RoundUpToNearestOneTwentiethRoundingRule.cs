// *************************************************
// SalesTaxCalc.Domain.Core.RoundUpToNearestOneTwentiethRoundingRule.cs
// Last Modified: 04/20/2015 11:03 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Impl
{
    using System;

    /// <summary>
    /// Applies rounding up from precise value to nearest 0.05.
    /// </summary>
    public class RoundUpToNearestOneTwentiethRoundingRule : IRoundingStrategy
    {
        public decimal GetRoundedValue(decimal pPreciseValue)
        {
            //ref: http://stackoverflow.com/a/1448465/1240322
            return Math.Ceiling(pPreciseValue*20)/20;
        }
    }
}