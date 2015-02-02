using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzbukaShared
{
	public class CatalogContainer
	{
		public CatalogContainer()
		{
			Catalog = new List<Book> ();
		}
		[JsonProperty (PropertyName = "previous_cursor")]
		public int PreviousCursor { get; set; }

		[JsonProperty (PropertyName = "next_cursor")]
		public int NextCursor { get; set; }

		[JsonProperty (PropertyName = "total")]
		public int Total { get; set; }

		[JsonProperty (PropertyName = "catalog")]
		public List<Book> Catalog { get; set; }

		public static CatalogContainer operator+(CatalogContainer catalogLeft, CatalogContainer catalogRight)
		{
			catalogLeft.Catalog.AddRange (catalogRight.Catalog);
			catalogLeft.NextCursor = catalogRight.NextCursor;
			catalogLeft.PreviousCursor = catalogRight.PreviousCursor;
			catalogLeft.Total = catalogRight.Total;
			return catalogLeft;
		}
	}
}

