// *************************************************
// SalesTaxCalc.Testing.UnitTests.Percentage.cs
// Last Modified: 04/17/2015 8:36 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.Domain.Core.ValueObjects
{
    using System;

    public class Percentage : IValueObject
    {
        public Percentage(int pValue)
        {
            throw new NotImplementedException();
        }

        public decimal Value { get; set; }
    }
}