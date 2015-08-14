using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BluemixIoT
{
	public class DeviceDataOfflineService : IDeviceDataService
	{
		public async Task<DeviceDataCollection> GetDeviceData()
		{
			return await Task.Run(() =>
				{
					var deviceDataCol = new DeviceDataCollection();

					var csv = DataProvider.GetResourceCsvFileData(@"BluemixIoT.Data.air_quality.csv");
					for (var i = 1; i < csv.Rows.Count; i++)
					{
						var data = csv[i, "d"];
						var deviceData = new DeviceData
						{
							Id = csv[i, "_id"],
							Data = JsonConvert.DeserializeObject<AirQuality>(csv[i, "d"]),
							Timestamp = Convert.ToDateTime(csv[i, "ts"]),
						};
						deviceDataCol.Add(deviceData);
					}

					return deviceDataCol;
				});


		}
	}
}

