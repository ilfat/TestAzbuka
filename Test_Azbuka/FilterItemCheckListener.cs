using System;
using Android.Widget;
using AzbukaShared;


namespace Test_azbuka
{
	public class FilterItemCheckListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
	{
		IFilterObject filterObject;
		public FilterItemCheckListener (IFilterObject filterObject)
		{
			this.filterObject = filterObject;
		}

		#region IOnCheckedChangeListener implementation

		public void OnCheckedChanged (CompoundButton buttonView, bool isChecked)
		{
			filterObject.Included = isChecked;
		}

		#endregion
	}
}

