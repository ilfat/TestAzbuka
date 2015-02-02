using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzbukaShared
{
	public class Price
	{
		[JsonProperty (PropertyName = "price")]
		public int _Price { get; set; }

		[JsonProperty (PropertyName = "license_type")]
		public string LicenseType { get; set; }

		[JsonProperty (PropertyName = "license_period")]
		public int LicensePeriod { get; set; }

		[JsonProperty (PropertyName = "for")]
		public string For { get; set; }
	}
}

