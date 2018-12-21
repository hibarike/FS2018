using MvvmCross.ViewModels;
using TipCalc.Core.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using System.Collections.Generic;
using MvvmCross.Navigation;

namespace TipCalc.Core.ViewModels
{
	public class TipViewModel : MvxViewModel
	{
		readonly ICalculationService _calculationService;
		readonly IMvxNavigationService _navigationService;
		public TipViewModel(ICalculationService calculationService)
		{
			_calculationService = calculationService;
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			_subTotal = 100;
			_generosity = 10;

			Recalculate();
		}

		private double _subTotal;
		public double SubTotal
		{
			get => _subTotal;
			set {
				SetProperty(ref _subTotal, value);
				//_subTotal = value;
				//RaisePropertyChanged(() => SubTotal);

				Recalculate();
			}
		}

		public int _generosity;
		public int Generosity
		{
			get => _generosity;
			set
			{
				SetProperty(ref _generosity, value);
				//_generosity = value;
				//RaisePropertyChanged(() => Generosity);

				Recalculate();
			}
		}

		private double _tip;
		public double Tip
		{
			get => _tip;
			set
			{
				SetProperty(ref _tip, value);
				//_tip = value;
				//RaisePropertyChanged(() => Tip);
			}

		}

		private void Recalculate()
		{
			Tip = _calculationService.TipAmount(SubTotal, Generosity);
		}

	}
		
	}
