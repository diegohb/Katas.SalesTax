// *************************************************
// SalesTaxCalc.Testing.UnitTests.Utility.cs
// Last Modified: 04/17/2015 12:27 AM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Testing.UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;

    [TestFixture]
    [Ignore("Not intended to be executed by CI.")]
    public class Utility
    {
        [Test]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void HelloTest_ShouldPass()
        {
            Assert.Pass("hello world!");
        }
    }
}