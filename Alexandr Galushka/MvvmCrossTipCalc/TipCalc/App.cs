using System;
using System.Collections.Generic;
using System.Text;
using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;
using MvvmCross;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace TipCalc.Core
{
    class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<ICalculationService, CalculationService>();
            RegisterAppStart<TipViewModel>();
        }
    }
}
