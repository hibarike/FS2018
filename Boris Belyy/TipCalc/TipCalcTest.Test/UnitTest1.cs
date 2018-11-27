using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipCalc.Core.Services;

namespace TipCalcTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
      
            public void TestThatZeroGenerosityReturnZeroTip()
            {
                //Arrange
                var tip = new CalculationService();
                //Act
                var result = tip.TipAmount(42.35, 0);
                //Assert
                Assert.AreEqual(0, result);
            }

        }
    }
