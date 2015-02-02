
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AzbukaShared;
using Android.Text;

namespace Test_azbuka
{
	[Activity (Label = "@string/detailView", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]			
	public class DetailBookViewActivity : Activity
	{
		protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.DetailViewLayout);

			string bookId = Intent.GetStringExtra ("bookId");
			var book = await new BookDownloader().DownloadAsync ("http://api.e-azbuka.ru/1.0/catalog/user/"+bookId+".json");

			var coverView = FindViewById (Resource.Id.cover) as ImageView;
			var bookInfo = FindViewById (Resource.Id.bookInfoText) as TextView;
			var detailBookInfo = FindViewById (Resource.Id.detailBookInfoText) as TextView;

			BitmapWorkerTask.LoadBitmap (book.CoverUrl, coverView, Resources);

			bookInfo.TextFormatted = Html.FromHtml (string.Format ("<b>Название</b>: {0}<br /><br /><b>Авторы:</b> {1}<br /><br /> <b>Издательство:</b> {2}", 
				book.Name, book.AuthorsShortStr, book.PublishingHouse));

			detailBookInfo.TextFormatted = Html.FromHtml (string.Format ("<b>Описание</b>: {0}<br />", 
				book.Classificators.Single(classificator => classificator.HumanReadableName == "Описание").Value));

		}
	}
}

