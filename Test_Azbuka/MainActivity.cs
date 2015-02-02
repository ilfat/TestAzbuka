using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AzbukaShared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Java.Interop;

namespace Test_azbuka
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, Android.Widget.SearchView.IOnQueryTextListener
	{
		ListView bookListView;
		ProgressBar loadingIndicator;

		Button filterByCategoryButton;
		Button filterByPubHouseButton;
		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			bookListView = FindViewById (Resource.Id.bookListView) as ListView;
			loadingIndicator = FindViewById (Resource.Id.loadingIndicator) as ProgressBar;

			List<Book> books = await new PartialCatalogDownloader ().DownloadAsync ("http://api.e-azbuka.ru/1.0/catalog/user.json");
			List<PubHouse> pubhouses = await new DictionaryDownloader ().DownloadAsync<PubHouse> ("http://api.e-azbuka.ru/1.0/catalog/user/pubhouses.json");
			List<Category> tematics = await new DictionaryDownloader ().DownloadAsync<Category> ("http://api.e-azbuka.ru/1.0/catalog/user/categories.json");

			loadingIndicator.Visibility = ViewStates.Gone;

//			filterByCategoryButton = FindViewById (Resource.Id.filterByCategoryButton) as Button;
//			filterByCategoryButton.Click += (sender, e) => ;
//
//			filterByPubHouseButton = FindViewById (Resource.Id.filterByPubHouseButton) as Button;


			bookListView.Adapter = new BookListViewAdapter (this, books);
		}

		SearchView searchView;
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.Main, menu);
			searchView = (SearchView) menu.FindItem(Resource.Id.searchView).ActionView;
			searchView.SetOnQueryTextListener (this);
			return true;
		}

		bool SearchView.IOnQueryTextListener.OnQueryTextChange (String newText)
		{

		}


		bool SearchView.IOnQueryTextListener.OnQueryTextSubmit (String query)
		{

		}

		[Export("filterByCategoryClick")]
		public void FilterByCategoryClick(View v)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder (this);
			builder.SetTitle (Resource.String.filterByCategory);


		}
		[Export("filterByPubHouseClick")]
		public void FilterByPubHouseClick(View v)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder (this);
			builder.SetTitle (Resource.String.filterByPubHouse);
		}
	}
}


