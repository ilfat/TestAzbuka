using System;
using Newtonsoft.Json;

namespace AzbukaShared
{
	public class PubHouse:IDictionary, IFilterObject
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

		public bool Included {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public string RelevantString {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

