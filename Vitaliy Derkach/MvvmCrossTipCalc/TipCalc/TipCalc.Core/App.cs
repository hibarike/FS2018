using MvvmCross;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;

namespace TipCalc.Core
{
	class App: MvxApplication
	{
		public override void Initialize()
		{
			Mvx.RegisterType<ICalculationService, CalculationService>();

			RegisterAppStart<TipViewModel>();
		}
	}
}
