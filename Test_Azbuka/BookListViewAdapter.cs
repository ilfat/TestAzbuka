using System;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;
using AzbukaShared;
using ImageViewExtention;
using System.Net.Http;
using Android.App;
using Android.Text;

namespace Test_azbuka
{
	public class BookListViewAdapter: BaseAdapter
	{
		Activity activity;
		List<Book> books;
		public BookListViewAdapter(Activity activity, List<Book> books)
		{
			this.activity = activity;
			this.books = books;
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
		public override View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			if (convertView == null)
				convertView = activity.LayoutInflater.Inflate (Resource.Layout.BookPreviewLayout, null);

			var formattedText = Html.FromHtml(string.Format("<b>Название</b>: {0}<br /><b>Авторы:</b> {1}",books[position].name, books[position].authors_short_str));
			((TextView)convertView.FindViewById (Resource.Id.bookInfoText)).TextFormatted = formattedText;

			var coverImage = convertView.FindViewById (Resource.Id.cover) as ImageView;

			BitmapWorkerTask.loadBitmap (books [position].cover_url, coverImage, activity.Resources);return convertView;
		}
		public override int Count {
			get {
				return books.Count;
			}
		}
		#endregion
	}
}

