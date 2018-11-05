using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipCalc.Core.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void TestMethod1()
        {
            CalculationService service = new CalculationService();
            double actual = service.TipAmount(155,10);
            double expected = 15.5;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            CalculationService service = new CalculationService();
            double actual = service.TipAmount(-155, 10);
            double expected = -15.5;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            CalculationService service = new CalculationService();
            double actual = service.TipAmount(155, 0);
            double expected = 0;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            CalculationService service = new CalculationService();
            double actual = service.TipAmount(155, 100);
            double expected = 155;

            Assert.AreEqual(expected, actual);
        }
    }
}
