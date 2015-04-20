// *************************************************
// SalesTaxCalc.Testing.UnitTests.IRoundingStrategy.cs
// Last Modified: 04/20/2015 10:30 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core
{
    public interface IRoundingStrategy
    {
        decimal GetRoundedValue(decimal pPreciseValue);
    }
}