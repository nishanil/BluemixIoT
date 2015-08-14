using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BluemixIoT
{
	public class DeviceData : ObservableObject
	{
		// since device sends out data in this form: ObjectID(55b6270f74f4041d0069107d),
		// it's ok to hold it in string. 
		private string id;
		public string Id {

			get{
				return id;
			}
			set {
				id = value; RaisePropertyChanged ();
			}
		}

		public double Ppm {
			get;
			set;
		}

		private AirQuality data;

		[JsonProperty("d")]
		public AirQuality Data {

			get{
				return data;
			}
			set{
				data = value; RaisePropertyChanged ();
			}
		}

		private DateTime timestamp;

		[JsonProperty("ts")]
		public DateTime Timestamp {

			get{
				return timestamp;
			}
			set {
				timestamp = value; RaisePropertyChanged ();
			}
		}
	}

	public class DeviceDataCollection : List<DeviceData>
	{}




}

