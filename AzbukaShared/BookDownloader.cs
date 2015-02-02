using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace AzbukaShared
{
	/// <summary>
	/// Простейший загрузчик объекта из сети. Скачивает и создает c# объект из rest api.
	/// </summary>
	public class BookDownloader
	{
		public async Task<Book> DownloadAsync (string path)
		{
			return await Task.Factory.StartNew (() => {
				try {
				var webClient = new WebClient ();

				string downloadedString = webClient.DownloadString (new Uri (path));
				return JsonConvert.DeserializeObject<Book> (downloadedString);
				}
				catch {return null;}
			});
		}
	}
}

