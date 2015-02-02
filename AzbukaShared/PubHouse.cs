using System;
using Newtonsoft.Json;

namespace AzbukaShared
{
	public class PubHouse : FilterObject, IDictionary, IFilterObject
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

		[JsonProperty(PropertyName = "qty")]
		public int Qty { get; set; }

		#region IFilterObject implementation

		public override string RelevantString {
			get {
				return Name;
			}
		}
		#endregion
	}
}

