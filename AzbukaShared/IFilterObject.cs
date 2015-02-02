using System;

namespace AzbukaShared
{
	public interface IFilterObject
	{
		/// <summary>
		/// Включен ли объект фильтра
		/// </summary>
		/// <value><c>true</c> if included; otherwise, <c>false</c>.</value>
		bool Included{ get; set;}
		string RelevantString{get;}
		event IncludedChangedEventHandler OnIncludedChanged;
	}
	public delegate void IncludedChangedEventHandler(bool state);
}

