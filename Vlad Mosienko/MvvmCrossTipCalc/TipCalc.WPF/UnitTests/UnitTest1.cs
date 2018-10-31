using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipCalc.Core.Services;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CalculationService service = new CalculationService();
            double result = service.TipAmount(344, 10);
            double expected = 34.4;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            CalculationService service = new CalculationService();
            double result = service.TipAmount(100, 100);
            double expected = 100;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            CalculationService service = new CalculationService();
            double result = service.TipAmount(0, 55);
            double expected = 0;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            CalculationService service = new CalculationService();
            double result = service.TipAmount(106, 0);
            double expected = 0;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            CalculationService service = new CalculationService();
            double result = service.TipAmount(-234, 15);
            double expected = 0;
            Assert.AreEqual(expected, result);
        }
    }
}
