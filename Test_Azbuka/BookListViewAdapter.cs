using System;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;
using AzbukaShared;
using System.Net.Http;
using Android.App;
using Android.Text;
using System.Linq;

namespace Test_azbuka
{
	public class BookListViewAdapter: BaseAdapter, IFilterable
	{
		Activity activity;
		List<Book> books;

		List<Book> bookListToDisplay;
		List<Category> categories;
		List<PubHouse> pubHouses;
		List<Book> filteredBooks;

		public BookListViewAdapter (Activity activity, List<Book> books, List<Category> categories,	List<PubHouse> pubHouses)
		{
			this.activity = activity;
			this.books = filteredBooks = bookListToDisplay = books;
			this.categories = categories;
			this.pubHouses = pubHouses;
			categories.ForEach(category => category.OnIncludedChanged += OnFilterObjectChanged);
			pubHouses.ForEach(pubHouse => pubHouse.OnIncludedChanged += OnFilterObjectChanged);
		}
		void OnFilterObjectChanged(bool result)
		{
			NotifyDataSetChanged ();
		}		
		#region implemented abstract members of BaseAdapter

		public override Java.Lang.Object GetItem (int position)
		{
			return new JavaObjectWrapper<Book>(bookListToDisplay [position]);
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		string GetOldCoverUrl(ImageView img)
		{
			return img.Tag != null ? (string)img.Tag : null;
		}
		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			if (convertView == null)
				convertView = activity.LayoutInflater.Inflate (Resource.Layout.BookPreviewLayout, null);
			try {


				var formattedText = Html.FromHtml (string.Format ("<b>Название</b>: {0}<br /><br /><b>Авторы:</b> {1}", bookListToDisplay [position].Name, bookListToDisplay [position].AuthorsShortStr));
				((TextView)convertView.FindViewById (Resource.Id.bookInfoText)).TextFormatted = formattedText;

				var coverImage = convertView.FindViewById (Resource.Id.cover) as ImageView;

				string oldCoverUrl = GetOldCoverUrl(coverImage);
				if (string.IsNullOrEmpty(oldCoverUrl) || oldCoverUrl != bookListToDisplay[position].CoverUrl)
					BitmapWorkerTask.LoadBitmap (bookListToDisplay [position].CoverUrl, coverImage, activity.Resources);
				coverImage.Tag = bookListToDisplay[position].CoverUrl;

			} catch (System.NullReferenceException) {
				return null;//Не был назначен адаптер или другие причины
			}
			return convertView;
		}

		public override int Count {
			get {
				return bookListToDisplay.Count;
			}
		}

		#endregion


		BookFilter filter;

		public Filter Filter {
			get {
				if (filter == null) {
					filter = new BookFilter (books);
					filter.OnPublish += OnPublish;
				}
				return filter;
			}
		}

		void OnPublish (List<Book> results)
		{
			this.filteredBooks = results;
			NotifyDataSetChanged ();
		}

		public override void NotifyDataSetChanged ()
		{
			IntersetFilters ();
			base.NotifyDataSetChanged ();
		}

		/// <summary>
		/// Самая ответственная задача - пересечь три фильтра: поиск, издательства и категории.
		/// </summary>
		void IntersetFilters()
		{
			var includedPubHouses = pubHouses.Where (pubHouse => pubHouse.Included).Select(pubhouse => pubhouse.Name);
			var filteredBooksIntersectsPubHouses = filteredBooks.Where (book => includedPubHouses.Contains (book.PublishingHouse));

			var includedCategories = categories.Where (category => category.Included).Select (category => category.Name);
			bookListToDisplay = filteredBooksIntersectsPubHouses.Where (book => includedCategories.Contains (book.Category)).ToList();
		}
	}
}

