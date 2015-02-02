using System;

namespace AzbukaShared
{
	public class Category:IDictionary, IFilterObject
	{
			public string name { get; set; }
			public int qty { get; set; }


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

