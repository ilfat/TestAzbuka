using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzbukaShared
{
	public class Classificator
	{
		[JsonProperty (PropertyName = "logical_name")]
		public string LogicalName { get; set; }

		[JsonProperty (PropertyName = "human_readable_name")]
		public string HumanReadableName { get; set; }

		[JsonProperty (PropertyName = "value")]
		public string Value { get; set; }
	}
}

