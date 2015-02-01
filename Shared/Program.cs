using System;
using AzbukaShared;

namespace Shared
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			download ();
		}
		static void download()
		{
			//new PartialCatalogDownloader ().DownloadAsync ("http://api.e-azbuka.ru/1.0/catalog/user.json");
			var done = new DictionaryDownloader ().Download<PubHouse> ("http://api.e-azbuka.ru/1.0/catalog/user/pubhouses.json");
			new object ();
		}
	}
}
