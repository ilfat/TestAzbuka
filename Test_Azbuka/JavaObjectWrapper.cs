using System;

namespace Test_azbuka
{
	/// <summary>
	/// Некоторые объекты принимают только Java.Lang.Object. Чтобы передать им шарповский класс, сделана такая обертка.
	/// </summary>
	public class JavaObjectWrapper <T> : Java.Lang.Object
	{
		public T SharpObject{ get; private set;}
		public JavaObjectWrapper (T sharpObject)
		{
			this.SharpObject = sharpObject;
		}
	}
}

