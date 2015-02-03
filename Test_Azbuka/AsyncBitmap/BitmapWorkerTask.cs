using System;
using Android.OS;
using Java.Lang;
using Android.Graphics;
using Android.Widget;
using Android.Content.Res;
using Android.Graphics.Drawables;
using System.Net;

namespace Test_azbuka
{
	/// <summary>
	/// Класс портирован из java кода http://developer.android.com/training/displaying-bitmaps/process-bitmap.html 
	/// При подгрузке изображений динамически в listView столкнулся с проблемой - надо было отменять конкурирующие потоки, 
	/// ту работу, которую уже можно пропустить. Этот класс с сайта андроида отлично с этим справляется.
	/// </summary>
	public class BitmapWorkerTask : AsyncTask<string, Java.Lang.Void, Bitmap> {
		private WeakReference<ImageView> imageViewReference;
		private string url = "";
		Resources resources;

		public static void StartNew(ImageView imageView, string url, Resources resources)
		{
			if (CancelPotentialWork (url, imageView)) {
				BitmapWorkerTask task = new BitmapWorkerTask (imageView, resources);
				AsyncDrawable asyncDrawable =
					new AsyncDrawable (resources, null, task);
				imageView.SetImageDrawable (asyncDrawable);
				task.Execute (url);
			}
		}

		private BitmapWorkerTask(ImageView imageView, Resources resources) {
			imageViewReference = new WeakReference<ImageView> (imageView);
			this.resources = resources;
		}

		protected override Bitmap RunInBackground (params string[] native_parms)
		{
			url = native_parms [0];
			return DownloadBitmap (url);
		}
			
		protected override void OnPostExecute (Bitmap bitmap)
		{
			if (IsCancelled) {
				bitmap = null;
			}

			if (imageViewReference != null && bitmap != null) {

				ImageView imageView = null;
				imageViewReference.TryGetTarget (out imageView);
				BitmapWorkerTask bitmapWorkerTask =
					getBitmapWorkerTask(imageView);
				if (this == bitmapWorkerTask && imageView != null) {
					imageView.SetImageDrawable(new BitmapDrawable(bitmap));
				}
			}
		}

		static Bitmap DownloadBitmap(string url)
		{
			Bitmap imageBitmap = null;
			try {
				using (var webClient = new WebClient ()) {
					var imageBytes = webClient.DownloadData (url);
					if (imageBytes != null && imageBytes.Length > 0) {
						imageBitmap = BitmapFactory.DecodeByteArray (imageBytes, 0, imageBytes.Length);
					}
				}

				return imageBitmap;
			} catch {
				return null;
			}
		}

		static bool CancelPotentialWork(string url, ImageView imageView) {
			BitmapWorkerTask bitmapWorkerTask = getBitmapWorkerTask(imageView);

			if (bitmapWorkerTask != null) {
				string bitmapUrl = bitmapWorkerTask.url;
				if (bitmapUrl == "" || bitmapUrl != url) {
					bitmapWorkerTask.Cancel(true);
				} else {
					return false;
				}
			}
			return true;
		}
		static BitmapWorkerTask getBitmapWorkerTask(ImageView imageView) {
			if (imageView != null) {
				Drawable drawable = imageView.Drawable;
				if (drawable is AsyncDrawable) {
					AsyncDrawable asyncDrawable = (AsyncDrawable) drawable;
					return asyncDrawable.GetBitmapWorkerTask();
				}
			}
			return null;
		}
	

	}
}

