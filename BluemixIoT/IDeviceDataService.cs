using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BluemixIoT
{
	interface IDeviceDataService
	{
		Task<DeviceDataCollection> GetDeviceData();
	}
}

