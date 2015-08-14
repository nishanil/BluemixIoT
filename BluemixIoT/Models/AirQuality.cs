using System;
using Newtonsoft.Json;

namespace BluemixIoT
{
	public class AirQuality
	{
		[JsonProperty("lat")]
		public string Lat { get; set; }

		[JsonProperty("weight")]
		public int Weight { get; set; }

		[JsonProperty("long")]
		public string Long { get; set; }

		[JsonProperty("ppm")]
		public double Ppm { get; set; }

	}


}

