using Moq;
using NUnit.Framework;
using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;

using MvvmCross.Tests;

namespace TipCalc.Tests
{
	[TestFixture]
	public class TipViewModelTests : MvxIoCSupportingTest
	{
		[Test]
		public void TestThatWhenSubTotalChangesThenTipIsRecalculated()
		{
			//Arrange
			base.ClearAll();
			var mockCalculationService = new Mock<ICalculationService>();
			mockCalculationService.Setup(t => t.TipAmount(It.IsAny<double>(), It.IsAny<int>()))
			.Returns(42.0);
			var tipViewModel = new TipViewModel(mockCalculationService.Object);

			//Act
			tipViewModel.SubTotal = 12;

			//Assert
			Assert.AreEqual(42.0, tipViewModel.Tip);
		}

		[Test]
		public void TestThatWhenGenerosityChangesThenTipIsRecalculated()
		{
			//Arrange
			base.ClearAll();
			var mockCalculationService = new Mock<ICalculationService>();
			mockCalculationService.Setup(t => t.TipAmount(It.IsAny<double>(), It.IsAny<int>()))
			.Returns(37.0);
			var tipViewModel = new TipViewModel(mockCalculationService.Object);

			//Act
			tipViewModel.Generosity = 12;

			//Assert
			Assert.AreEqual(37.0, tipViewModel.Tip);
		}

		[Test]
		public void TestThatWhenTipIsRecalculatedThenTipNotificationIsSent()
		{
			//Arrange
			base.ClearAll();
			var mockCalculationService = new Mock<ICalculationService>();
			mockCalculationService.Setup(t => t.TipAmount(It.IsAny<double>(), It.IsAny<int>()))
			.Returns(19.0);

			/*var mockDispatcher = new MockDispather();
			Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
			Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);*/

			int tipChangeCount = 0;
			int generosityChangeCount = 0;
			int subTotalChangeCount = 0;
			var tipViewModel = new TipViewModel(mockCalculationService.Object);
			tipViewModel.PropertyChanging += (sender, args) =>
		   {
			   switch (args.PropertyName)
			   {

				   case "Tip":
					   tipChangeCount++;
					   break;
				   case "SubTotal":
					   subTotalChangeCount++;
					   break;
				   case "Generosity":
					   generosityChangeCount++;
					   break;
			   }

		   };
			//Act
			tipViewModel.Generosity = 12;


			//Assert
			Assert.AreEqual(1, tipChangeCount);
			Assert.AreEqual(0, subTotalChangeCount);
			Assert.AreEqual(1, generosityChangeCount);
		}
	}

	
}
