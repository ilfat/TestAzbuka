using System;
using Android.Widget;
using System.Collections.Generic;
using AzbukaShared;
using System.Linq;

namespace Test_azbuka
{
	public class BookFilter: Filter
	{
		List<Book> books;
		public BookFilter (List<Book> books)
		{
			this.books = books;
		}

		#region implemented abstract members of Filter
		/// <param name="constraint">the constraint used to filter the data</param>
		/// <summary>
		/// Фильтрует лист по имени книги, записывает в результат с помощью враппера.
		/// Сравнение идет case insensitive.
		/// </summary>
		/// <returns>To be added.</returns>
		protected override FilterResults PerformFiltering (Java.Lang.ICharSequence constraint)
		{
			FilterResults results = new FilterResults ();
			string inputString = constraint.ToString ();
			var resultList = new JavaObjectWrapper<List<Book>> (books.Where ((book, result) => book.Name.ToLower().Contains(inputString.ToLower())).ToList ());
				results.Values = resultList;
				results.Count = resultList.SharpObject.Count;
			return results;
		}

		/// <summary>
		/// Событие создается для того, чтобы никто, кроме подписчиков(например адаптера) не смог менять отфильтрованный список
		/// </summary>
		public delegate void PublishResultEventHandler(List<Book> IAsyncResult);
		public event PublishResultEventHandler OnPublish;
		protected override void PublishResults (Java.Lang.ICharSequence constraint, FilterResults results)
		{
			if (OnPublish != null)
				OnPublish ((results.Values as JavaObjectWrapper<List<Book>>).SharpObject);
		}

		#endregion
	}
}

