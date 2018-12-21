using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TipCalc.Core.ViewModels;
using TipCalc.Core.Services;
using Moq;

namespace TipCalc.Core.Tests
{
    [TestFixture]
    class ViewModelsTests 
    {
        [Test]
        public void Test1()
        {
            var mockTipService = new Mock<ICalculationService>();
            mockTipService.Setup(t => t.TipAmount(It.IsAny<double>(), It.IsAny<int>())).Returns(42.0);
            var ViewModel = new TipViewModel(mockTipService.Object);
            ViewModel.SubTotal = 12;
            Assert.AreEqual(42.0, ViewModel.Tip);
        }
    }
}
