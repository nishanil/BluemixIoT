using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BluemixIoT
{
	public class CloudantDataService : IDeviceDataService
	{
		string username = "50dc0e84-6c69-4f2e-916e-4874c103a19f-bluemix";
		string password = "31b0ea4d42dfe1feab6dbb3bfc07c4403fb25b67a10261372b10cb481f8f2d0a";
		string url = "https://50dc0e84-6c69-4f2e-916e-4874c103a19f-bluemix.cloudant.com/pollution1/_all_docs?include_docs=true&limit=100";

		#region IDeviceDataService implementation

		public async Task<DeviceDataCollection> GetDeviceData ()
		{
			using (var client = new HttpClient (new HttpClientHandler { Credentials = new NetworkCredential (username, password) })) {
				var data = await client.GetStringAsync (url).ConfigureAwait(false);
				return await HandleResponse (data);
			}
		}

		private async Task<DeviceDataCollection> HandleResponse(string data)
		{
			return await Task.Run (()=>{

				var cloudantData = JsonConvert.DeserializeObject<CloudantData> (data);
				if (cloudantData == null) {
					return null;
				}

				var deviceDataCollection = new DeviceDataCollection ();
				foreach (var item in cloudantData.Rows) {
					item.Doc.DeviceData.Timestamp = item.Doc.DeviceData.Timestamp.ToLocalTime();
					deviceDataCollection.Add (item.Doc.DeviceData);
				}

				return deviceDataCollection;
			});

		}

		#endregion

		public CloudantDataService ()
		{
			
		}
	}
}






