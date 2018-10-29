using MvvmCross;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;

namespace TipCalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Mvx.RegisterType<ICalculationService, CalculationService>();
#pragma warning restore CS0618 // Type or member is obsolete

            RegisterAppStart<TipViewModel>();
        }
    }
}
