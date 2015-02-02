using System;
using Android.Widget;
using System.Threading.Tasks;
using Android.Graphics;
using System.Net;
using System.Threading;
using Java.Util;
using System.Collections.Generic;

namespace ImageViewExtention
{
	public static class ImageViewExtention
	{
		public static Bitmap DownloadBitmap(string url)
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
//		static List<CancellationTokenSource> tokenSources = new List<CancellationTokenSource> ();
//		static HashMap tasks = new HashMap();
		static Dictionary<ImageView, string> tasks = new Dictionary<ImageView, string>();
		public async static void SetSourceWebUrl(ImageView imageView, string url)
		{
			imageView.Visibility = Android.Views.ViewStates.Invisible;//чтобы не показывать старую чужую обложку
			CancellationTokenSource tokenSource = new CancellationTokenSource ();

			tasks.Remove (imageView);
			tasks.Add (imageView, url);


			Bitmap downloadedBitmap = await Task.Factory.StartNew (() => {
				string tryString = null;
				tasks.TryGetValue(imageView, out tryString);

				Bitmap currentBitmap = null;
				if (tryString != null && tryString == url)
					currentBitmap = DownloadBitmap(url);
				return currentBitmap;
			});

			string tryString1 = null;
			tasks.TryGetValue(imageView, out tryString1);
			if (tryString1 != null && tryString1 == url)
			if (downloadedBitmap != null)
				imageView.SetImageBitmap (downloadedBitmap);
			imageView.Visibility = Android.Views.ViewStates.Visible;
			
		}
		class TaskWrapper: Java.Lang.Object
		{
			public TaskWrapper(Task task)
			{
				this.Task = task;
			}
			public Task Task { get; set; }
		}
		class CancellationTokenSourceJavaWrapper: Java.Lang.Object
		{
			public CancellationTokenSourceJavaWrapper(CancellationTokenSource tokenSource)
			{
				this.TokenSource = tokenSource;
			}
			public CancellationTokenSource TokenSource { get; set; }
		}
	}
}

