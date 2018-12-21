using NUnit.Framework;
using System;
using TipCalc.Core.Services;

namespace TipCalc.Core.Tests
{
    [TestFixture]
    public class TipServiceTests
    {
        [Test]
        public void Test1()
        {
            var Tip = new CalculationService();
            var result = Tip.TipAmount(42.35, 0);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Test2()
        {
            var Tip = new CalculationService();
            var result = Tip.TipAmount(42.35, 10);
            Assert.AreEqual(4.235, result);
        }
    }
}
