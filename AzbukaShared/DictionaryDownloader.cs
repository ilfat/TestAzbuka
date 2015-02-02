using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzbukaShared
{
	public class DictionaryDownloader
	{
		public async Task<List<T>> DownloadAsync<T>(string path) where T:IDictionary
		{
			return await Task.Factory.StartNew (() => {
				var webClient = new WebClient ();
				var downloadedString = webClient.DownloadString (path);
				return JObject.Parse (downloadedString).SelectToken ("list").ToObject<List<T>> ();
			});
		}
	}
}

