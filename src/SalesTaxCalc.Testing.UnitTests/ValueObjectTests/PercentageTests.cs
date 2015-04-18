// *************************************************
// SalesTaxCalc.Testing.UnitTests.PercentageTests.cs
// Last Modified: 04/17/2015 9:16 PM
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
        public void TenPercent_ActualValueShouldEqualOneTenth()
        {
            //arrange
            const decimal expectedActualValue = 0.1m;
            const decimal testPercentageValue = 10m;

            //act
            var tenPercent = new Percentage(testPercentageValue); //the ctor is the action.

            //assert
            Assert.AreEqual(expectedActualValue, tenPercent.ActualValue);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void TenPercent_PercentageValueShouldEqualTen()
        {
            //arrange
            const decimal testPercentageValue = 10m;

            //act
            var tenPercent = new Percentage(testPercentageValue); //the ctor is the action.

            //assert
            Assert.AreEqual(testPercentageValue, tenPercent.PercentageValue);
        }

        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void Percentage_ShouldSupportFractionalPercentageValues()
        {
            //arange
            const decimal percentageValue = 11.9m;
            const decimal expectedActualValue = 0.119m;

            //act
            var percentageUnderTest = new Percentage(percentageValue);
            var actualValueFromPercentage = percentageUnderTest.ActualValue;

            //assert
            Assert.AreEqual(expectedActualValue, actualValueFromPercentage);
        }
    }
}