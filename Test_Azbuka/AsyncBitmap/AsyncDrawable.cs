using System;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Graphics;

namespace Test_azbuka
{
	/// <summary>
	/// Класс портирован из java кода http://developer.android.com/training/displaying-bitmaps/process-bitmap.html
	/// </summary>
	public class AsyncDrawable : BitmapDrawable
	{
		WeakReference<BitmapWorkerTask> bitmapWorkerTaskReference;

		public AsyncDrawable (Resources res, Bitmap bitmap, BitmapWorkerTask bitmapWorkerTask) : base (res, bitmap)
		{
			bitmapWorkerTaskReference =
				new WeakReference<BitmapWorkerTask>(bitmapWorkerTask);
		}

		public BitmapWorkerTask GetBitmapWorkerTask() {
			BitmapWorkerTask task = null;
			bitmapWorkerTaskReference.TryGetTarget (out task);
			return task;
		}
	}
}

