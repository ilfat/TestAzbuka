using System;

namespace AzbukaShared
{
	/// <summary>
	/// Интерфейс, который показывает, что объект является 
	/// справочником(технически json объект содержится в объекте "list") в api Азбуки.
	/// Я мог бы так же абстрагировать "list" в свойство класса, но это уже будет overkills
	/// </summary>
	public interface IDictionary
	{
	}
}

