using System;

using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using AzbukaShared;
using System.Collections.Generic;
using Java.Interop;
using Android.Content;

namespace Test_azbuka
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity, Android.Widget.SearchView.IOnQueryTextListener
	{
		ListView bookListView;
		ProgressBar loadingIndicator;

		List<PubHouse> pubHouses;
		List<Category> categories;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			bookListView = FindViewById (Resource.Id.bookListView) as ListView;

			SetEventToListView ();

			loadingIndicator = FindViewById (Resource.Id.loadingIndicator) as ProgressBar;
			LoadDataAsync ();
		}

		SearchView searchView;
		IMenuItem refreshButton;
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.Main, menu);
			searchView = (SearchView) menu.FindItem(Resource.Id.searchView).ActionView;
			searchView.SetOnQueryTextListener (this);

			refreshButton = menu.FindItem(Resource.Id.refreshButton);
			return true;
		}

		/// <param name="item">The menu item that was selected.</param>
		/// <summary>
		/// Обработка кнопки "Обновить"
		/// </summary>
		/// <returns>To be added.</returns>
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Resource.Id.refreshButton:
				LoadDataAsync ();
				return true;
			default:
				return base.OnOptionsItemSelected (item);
			}
		}

		bool SearchView.IOnQueryTextListener.OnQueryTextChange (String newText)
		{
			(bookListView.Adapter as IFilterable).Filter.InvokeFilter (newText);
			return true;
		}
		bool SearchView.IOnQueryTextListener.OnQueryTextSubmit (String query)
		{
			return true;
		}

		void SetEventToListView()
		{
			bookListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var adapter = bookListView.Adapter;
				var bookId = (adapter.GetItem(e.Position) as JavaObjectWrapper<Book>).SharpObject.Id;
				ShowDetails(bookId);
			}; 
		}
		void ShowDetails(string id)
		{
			Intent intent = new Intent (this, typeof(DetailBookViewActivity));
			intent.PutExtra ("bookId", id);
			StartActivity (intent);
		}

		[Export("filterByCategoryClick")]
		public void FilterByCategoryClick(View v)
		{
			showFilter<Category> (categories, Resource.String.filterByCategory);
		}
		[Export("filterByPubHouseClick")]
		public void FilterByPubHouseClick(View v)
		{
			showFilter<PubHouse> (pubHouses, Resource.String.filterByPubHouse);
		}

		/// <summary>
		/// Показывает алерт с содержащимся в нем фильтром.
		/// </summary>
		/// <param name="filterObjects">Пункты фильтра</param>
		/// <param name="title">Заголовок окна</param>
		/// <typeparam name="T">Тип категории фильтра, ограничен интерфейсом IFilterObject</typeparam>
		void showFilter<T>(List<T> filterObjects, int title) where T: IFilterObject
		{
			if (filterObjects == null || filterObjects.Count == 0) {
				Toast.MakeText (this, "Данные фильтра не загружены", ToastLength.Short).Show();
				return;
			}
			var builder = new AlertDialog.Builder (this);
			builder.SetTitle (title);

			builder.SetView (LayoutInflater.Inflate (Resource.Layout.FilterListView, null));
			var dialog = builder.Create ();
			dialog.Show ();
			var filterListView = dialog.FindViewById (Resource.Id.listView1) as ListView;
			filterListView.Adapter = new FilterListViewAdapter<T> (filterObjects, LayoutInflater);
		}

		async void LoadDataAsync()
		{
			if (refreshButton != null)
				refreshButton.SetEnabled(false);
			loadingIndicator.Visibility = ViewStates.Visible;
			List<Book> books = await new PartialCatalogDownloader ().DownloadAsync ("http://api.e-azbuka.ru/1.0/catalog/user.json");
			pubHouses = await new DictionaryDownloader ().DownloadAsync<PubHouse> ("http://api.e-azbuka.ru/1.0/catalog/user/pubhouses.json");
			categories = await new DictionaryDownloader ().DownloadAsync<Category> ("http://api.e-azbuka.ru/1.0/catalog/user/categories.json");

			if (books != null) {
				loadingIndicator.Visibility = ViewStates.Gone;
				bookListView.Adapter = new BookListViewAdapter (this, books, categories, pubHouses);
			}
			refreshButton.SetEnabled(true);
		}
	}
}


