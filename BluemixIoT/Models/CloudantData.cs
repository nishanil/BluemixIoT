using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BluemixIoT
{
	public class Value
	{

		[JsonProperty("rev")]
		public string Rev { get; set; }
	}

//	public class D
//	{
//
//		[JsonProperty("lat")]
//		public string Lat { get; set; }
//
//		[JsonProperty("weight")]
//		public int Weight { get; set; }
//
//		[JsonProperty("long")]
//		public string Long { get; set; }
//
//		[JsonProperty("ppm")]
//		public int Ppm { get; set; }
//	}

//	public class Payload
//	{
//
//		[JsonProperty("d")]
//		public AirQuality D { get; set; }
//
//		[JsonProperty("ts")]
//		public DateTime Ts { get; set; }
//	}

	public class Doc
	{

		[JsonProperty("_id")]
		public string Id { get; set; }

		[JsonProperty("_rev")]
		public string Rev { get; set; }

		[JsonProperty("topic")]
		public string Topic { get; set; }

		[JsonProperty("payload")]
		public DeviceData DeviceData { get; set; }

		[JsonProperty("deviceId")]
		public string DeviceId { get; set; }

		[JsonProperty("deviceType")]
		public string DeviceType { get; set; }

		[JsonProperty("eventType")]
		public string EventType { get; set; }

		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("msgid")]
		public string Msgid { get; set; }
	}

	public class Row
	{

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("value")]
		public Value Value { get; set; }

		[JsonProperty("doc")]
		public Doc Doc { get; set; }
	}

	public class CloudantData
	{

		[JsonProperty("total_rows")]
		public int TotalRows { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }

		[JsonProperty("rows")]
		public IList<Row> Rows { get; set; }
	}

}

