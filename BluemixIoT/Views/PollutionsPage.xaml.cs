using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BluemixIoT
{
	public partial class PollutionsPage : ContentPage
	{
		PolutionsPageViewModel vm;
		public PollutionsPage ()
		{
			InitializeComponent ();

			BindingContext = vm =new PolutionsPageViewModel ();

			Device.StartTimer (new TimeSpan (0, 0, 4), vm.GetData);
		}
	}
}

