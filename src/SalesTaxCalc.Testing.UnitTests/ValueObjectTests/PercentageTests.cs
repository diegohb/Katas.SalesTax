// *************************************************
// SalesTaxCalc.Testing.UnitTests.PercentageTests.cs
// Last Modified: 04/17/2015 8:37 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests.ValueObjectTests
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Core.ValueObjects;
    using NUnit.Framework;

    [TestFixture]
    public class PercentageTests
    {
        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TenPercent_ShouldEqualOneTenth()
        {
            //arrange
            const decimal expectedValue = 0.1m;
            const decimal testPercentageValue = 10m;

            //act
            var tenPercent = new Percentage(testPercentageValue); //the ctor is the action.

            //assert
            Assert.AreEqual(expectedValue, tenPercent.Value);
        }
    }
}