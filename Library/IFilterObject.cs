using System;

namespace AzbukaShared
{
	public interface IFilterObject
	{
		bool Included{ get; set;}
		string RelevantString{get; set;}
	}
}

