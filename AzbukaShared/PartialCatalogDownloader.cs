using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace AzbukaShared
{
	/// <summary>
	/// Класс-утилита для загрузки каталога. Так как способ загрузки отличается от справочников, был сделан отдельный загрузчик.
	/// </summary>
	public class PartialCatalogDownloader
	{
		/// <summary>
		/// Загружает каталог по частям. Параметр для загрузки следующей части не был указан в задании, пришлось догадаться:)
		/// </summary>
		/// <returns>Каталог, содержащий все скаченные книги</returns>
		/// <param name="path">PathПуть к срипту для получения каталога</param>
		public async Task<List<Book>> DownloadAsync (string path)
		{
			return await Task.Factory.StartNew (() => {
				try {
					var webClient = new WebClient ();
					var catalogContainer = new CatalogContainer ();
					while (true) {
						string downloadedString = webClient.DownloadString (new Uri (path + "?cursor=" + catalogContainer.NextCursor));
						var downloadedCatalogPart = JsonConvert.DeserializeObject<CatalogContainer> (downloadedString);
						catalogContainer += downloadedCatalogPart;
						if (catalogContainer.NextCursor >= catalogContainer.Total)
							break;
					}
					return catalogContainer.Catalog;
				} catch {
					return null;
				}
			});
		}
	}
}


