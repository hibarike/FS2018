using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            double input = service.TipAmount(100, 100);
            double output = 100;

            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void TestMethod2()
        {
            CalculationService service = new CalculationService();
            double input = service.TipAmount(675, 13);
            double output = 87.75;

            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void TestMethod3()
        {
            CalculationService service = new CalculationService();
            double input = service.TipAmount(-520, 27);
            double output = -140.4;

            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void TestMethod4()
        {
            CalculationService service = new CalculationService();
            double input = service.TipAmount(0, 100);
            double output = 0;

            Assert.AreEqual(output, input);
        }

        [TestMethod]
        public void TestMethod5()
        {
            CalculationService service = new CalculationService();
            double input = service.TipAmount(0, 0);
            double output = 0;

            Assert.AreEqual(output, input);
        }

    }
}
