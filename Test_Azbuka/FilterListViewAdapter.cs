using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.App;
using Library;
using AzbukaShared;

namespace Test_azbuka
{
	public class FilterListViewAdapter : BaseExpandableListAdapter
	{
		MyClass s;
		List<List<IFilterObject>> items;
		Activity context;
		public FilterListViewAdapter (Context context, List<List<IFilterObject>> items)
		{
			this.items = items;
			this.context = context as Activity;
		}

		#region implemented abstract members of BaseExpandableListAdapter

		public override Java.Lang.Object GetChild (int groupPosition, int childPosition)
		{
			return null;// items [groupPosition] [childPosition];
		}

		public override long GetChildId (int groupPosition, int childPosition)
		{
			throw new NotImplementedException ();
		}

		public override int GetChildrenCount (int groupPosition)
		{
			return items [groupPosition].Count;
		}

		public override Android.Views.View GetChildView (int groupPosition, int childPosition, bool isLastChild, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			if (convertView == null) {
				convertView = context.LayoutInflater.Inflate (Resource.Layout.ChildFilterGroupView, null);
			}
			return convertView;
		}

		public override Java.Lang.Object GetGroup (int groupPosition)
		{
			return null;// items [groupPosition];
		}

		public override long GetGroupId (int groupPosition)
		{
			return groupPosition;
		}

		public override Android.Views.View GetGroupView (int groupPosition, bool isExpanded, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			if (convertView == null) {
				convertView = context.LayoutInflater.Inflate (Resource.Layout.FilterGroupView, null);
			}
			return convertView;
		}

		public override bool IsChildSelectable (int groupPosition, int childPosition)
		{
			return true;
		}

		public override int GroupCount {
			get {
				return items.Count;
			}
		}

		public override bool HasStableIds {
			get {
				return true;
			}
		}

		#endregion
	}
}

