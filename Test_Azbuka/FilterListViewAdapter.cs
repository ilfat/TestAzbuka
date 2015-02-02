using System;
using Android.Widget;
using System.Collections.Generic;
using AzbukaShared;
using Android.Views;

namespace Test_azbuka
{
	public class FilterListViewAdapter<T> : BaseAdapter where T: IFilterObject
	{
		List<T> filterObjects;
		LayoutInflater inflater;
		public FilterListViewAdapter(List<T> filterObjects, LayoutInflater inflater)
		{
			this.filterObjects = filterObjects;
			this.inflater = inflater;
		}


		#region implemented abstract members of BaseAdapter

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			if (convertView == null) {
				convertView = inflater.Inflate (Resource.Layout.FilterItem, null);
			}
			var filterItem = convertView.FindViewById (Resource.Id.filterItem) as CheckBox;
			filterItem.Text = filterObjects [position].RelevantString;
			filterItem.SetOnCheckedChangeListener (null);
			filterItem.Checked = filterObjects [position].Included;
			filterItem.SetOnCheckedChangeListener(new FilterItemCheckListener(filterObjects[position]));
			return convertView;
		}

		public override int Count {
			get {
				return filterObjects.Count;
			}
		}

		#endregion
	}
}

