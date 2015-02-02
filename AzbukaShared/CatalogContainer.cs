using System;
using System.Collections.Generic;

namespace AzbukaShared
{
	public class CatalogContainer
	{
		public CatalogContainer()
		{
			catalog = new List<Book> ();
		}
		public int previous_cursor { get; set; }
		public int next_cursor { get; set; }
		public int total { get; set; }
		public List<Book> catalog { get; set; }
		public static CatalogContainer operator+(CatalogContainer catalogLeft, CatalogContainer catalogRight)
		{
			catalogLeft.catalog.AddRange (catalogRight.catalog);
			catalogLeft.next_cursor = catalogRight.next_cursor;
			catalogLeft.previous_cursor = catalogRight.previous_cursor;
			catalogLeft.total = catalogRight.total;
			return catalogLeft;
		}
	}
}

