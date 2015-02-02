using System;
using Newtonsoft.Json;

namespace AzbukaShared
{
	public class Category : FilterObject, IDictionary, IFilterObject
	{
		[JsonProperty (PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty (PropertyName = "qty")]
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

