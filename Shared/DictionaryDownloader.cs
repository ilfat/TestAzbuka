using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AzbukaShared
{
	public class DictionaryDownloader
	{
		public List<T> Download<T>(string path) where T:IDictionary
		{
			var webClient = new WebClient ();
			var downloadedString = webClient.DownloadString (path);
			return JObject.Parse(downloadedString).SelectToken("list").ToObject<List<T>>();
		}
	}
}

