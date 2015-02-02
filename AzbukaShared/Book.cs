using System;
using System.Collections.Generic;
using System.Drawing;

namespace AzbukaShared
{
	public class Book
	{
		public string id { get; set; }
		public string name { get; set; }
		public int publication_year { get; set; }
		public string file_id { get; set; }
		public string publishing_house { get; set; }
		public string publishing_slug { get; set; }
		public int last_update_date { get; set; }
		public bool is_demo { get; set; }
		public string authors_short_str { get; set; }
		public List<Classificator> classificators { get; set; }
		public List<Price> pricelist { get; set; }
		public string cover_url { get; set; }
	}
}

