using System;
using System.Collections.Generic;

using MvvmCross.Core.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Core;

namespace TipCalc.Tests
{
	public class MockDispather : MvxMainThreadDispatcher, IMvxViewDispatcher
	{
		public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();
		public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

		public bool ChangePresentation(MvxPresentationHint hint)
		{
			Hints.Add(hint);
			return true;
		}

		public bool RequestMainThreadAction(Action action, bool maskExceptions = true)
		{
			action();
			return true;
		}

		public bool ShowViewModel(MvxViewModelRequest request)
		{
			Requests.Add(request);
			return true;
		}
	}
}
