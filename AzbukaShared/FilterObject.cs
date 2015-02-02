using System;

namespace AzbukaShared
{
	public abstract class FilterObject: IFilterObject
	{
		/// <summary>
		/// Поле-признак для сравнения с полем фильтруемого объекта
		/// </summary>
		/// <value>The relevant string.</value>
		public abstract string RelevantString {
			get ;
		}

		public event IncludedChangedEventHandler OnIncludedChanged;

		bool included = true;//чтобы по умолчанию все объекты фильтра были включены

		public bool Included {
			get { 
				return included;
			}
			set {
				included = value;
				if (OnIncludedChanged != null)
					OnIncludedChanged (included);
			}
		}
	}
}

