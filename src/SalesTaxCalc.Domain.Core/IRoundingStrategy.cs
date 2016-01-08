// *************************************************
// SalesTaxCalc.Domain.Core.IRoundingStrategy.cs
// Last Modified: 04/20/2015 11:03 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core
{
    public interface IRoundingStrategy
    {
        decimal GetRoundedValue(decimal pPreciseValue);
    }
}