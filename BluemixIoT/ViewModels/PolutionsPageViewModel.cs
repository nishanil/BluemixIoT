using System;
using System.Threading.Tasks;

namespace BluemixIoT
{
	public class PolutionsPageViewModel : ViewModelBase
	{
		private DeviceDataCollection data;
		public DeviceDataCollection Data {

			get{
				return data;
			}
			set {
				data = value; RaisePropertyChanged ();
			}
		}
		
		public PolutionsPageViewModel ()
		{
			Title = "Pollution in your City";

		}


		public bool GetData()
		{
			
			//IsBusy = true;
			new CloudantDataService ().GetDeviceData ().ContinueWith((d)=> {
				Data = d.Result;
			
				//IsBusy = false;
			});

			return true;
		}
	}


}

