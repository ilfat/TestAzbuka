using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace AzbukaShared
{
	public class Book
	{
		public Book()
		{
			//FIXME: фейковое значение, когда исправят на сервере - убрать.
			Category = "Обществознание";
		}
		[JsonProperty (PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty (PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty (PropertyName = "publication_year")]
		public int PublicationYear { get; set; }

		[JsonProperty (PropertyName = "file_id")]
		public string FileId { get; set; }

		[JsonProperty (PropertyName = "publishing_house")]
		public string PublishingHouse { get; set; }

		[JsonProperty (PropertyName = "publishing_slug")]
		public string PublishingSlug { get; set; }

		[JsonProperty (PropertyName = "last_update_date")]
		public int LastUpdateDate { get; set; }

		[JsonProperty (PropertyName = "is_demo")]
		public bool IsDemo { get; set; }

		[JsonProperty (PropertyName = "authors_short_str")]
		public string AuthorsShortStr { get; set; }

		[JsonProperty (PropertyName = "classificators")]
		public List<Classificator> Classificators { get; set; }

		[JsonProperty (PropertyName = "pricelist")]
		public List<Price> PriceList { get; set; }

		[JsonProperty (PropertyName = "cover_url")]
		public string CoverUrl { get; set; }


		/// <summary>
		/// Категория книги. В данный момент этого поля нет в rest-api, но по логике оно там должно быть
		/// </summary>
		/// <value>The category.</value>
		[JsonProperty (PropertyName = "category")]
		public string Category { get; set; }
	}
}

