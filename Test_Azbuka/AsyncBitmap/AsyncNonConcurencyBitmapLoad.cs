using System;
using Test_azbuka;
using Android.Widget;
using Android.Content.Res;

namespace AsyncNonConcurencyBitmapLoad
{
	public static class AsyncNonConcurencyBitmapLoad
	{
		public static void FromUrlNonConcurency(this ImageView imageView, string url, Resources resources) {
			BitmapWorkerTask.StartNew (imageView, url, resources);
		}
	}
}

