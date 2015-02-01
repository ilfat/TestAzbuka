using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Test_azbuka
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		ExpandableListView filterListView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			filterListView = FindViewById (Resource.Id.filterListView) as ExpandableListView;
			JavaDictionary<string, JavaDictionary> dic = new JavaDictionary<string, JavaDictionary> ();

//			var dic1 = new JavaDictionary<string, string> ();
//			dic1.Add ("Дрофа");
//			dic1.Add ("Просвещение");
//			dic1.Add ("Ещечото");
//
//			var dic2 = new JavaDictionary<string, string> ();
//			dic2.Add ("Билология");
//			dic2.Add ("Матятматаи");
//			dic2.Add ("орускийязык");
//
//			dic.Add (dic1);
//			dic.Add (dic2);


			//dic.
			//var simpleListAdapter = new SimpleExpandableListAdapter(this, dic, 
		}
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.Main, menu);
			return true;
		}
	}
}


