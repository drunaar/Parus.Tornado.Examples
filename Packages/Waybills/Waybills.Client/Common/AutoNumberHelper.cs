using System.ComponentModel;
using Acme.Business.Waybills;
using Parus.SmartClient.Tornado;

/// <summary>
/// Хелпер для работы с автонумерацией строк спецификации
/// </summary>
public static class AutoNumberHelper
{
	private class AutoNumberClientEngine<T>
	{
		private readonly IBindingList m_Collection;
		private readonly OrderedCollectionHelper.NumberGetter<T> m_Getter;
		private readonly OrderedCollectionHelper.NumberSetter<T> m_Setter;
		private readonly string m_AttrNumber;
		private bool m_IsInternal;
		//private ITransaction m_Transaction;
		//private IUnitExecutionContext m_Context;

		public AutoNumberClientEngine(
			IBindingList collection,
			OrderedCollectionHelper.NumberGetter<T> getter,
			OrderedCollectionHelper.NumberSetter<T> setter,
			string attrNumber//,
			//IUnitExecutionContext context
			)
		{
			m_Collection = collection;
			m_Getter = getter;
			m_Setter = setter;
			m_AttrNumber = attrNumber;
			//m_Context = context;
			foreach (INotifyPropertyChanged item in m_Collection)
			{
				item.PropertyChanged += PropertyChangedEventHandler;
			}
			m_Collection.ListChanged += DetailListChanged;
			//m_Transaction = context.GetCurrentTransaction();
			//context.TransitionEnded += TransitionEndedEventHandler;
		}
		/*
		private void TransitionEndedEventHandler(object sender, TransitionEndedEventArgs e)
		{
			if (m_Transaction != m_Context.GetCurrentTransaction())
			{
				foreach (INotifyPropertyChanged item in m_Collection)
				{
					item.PropertyChanged -= PropertyChangedEventHandler;
				}
				e.Context.TransitionEnded -= TransitionEndedEventHandler;
				m_Collection.ListChanged -= DetailListChanged;
			}
		}
		*/
		private void DetailListChanged(object sender, ListChangedEventArgs e)
		{
			if (e.ListChangedType == ListChangedType.Reset)
			{
				foreach (INotifyPropertyChanged item in m_Collection)
				{
					item.PropertyChanged -= PropertyChangedEventHandler;
					item.PropertyChanged += PropertyChangedEventHandler;
				}
				Reorder();
			}
			else if (e.ListChangedType == ListChangedType.ItemAdded)
			{
				((INotifyPropertyChanged)m_Collection[e.NewIndex]).PropertyChanged += PropertyChangedEventHandler;
				Reorder();
			}
			else if (e.ListChangedType == ListChangedType.ItemDeleted)
			{
				Reorder();
			}
		}

		private void Reorder()
		{
			var old = m_IsInternal;
			m_IsInternal = true;
			m_Collection.ReorderByNumber(m_Getter, m_Setter);
			m_IsInternal = old;
		}

		private void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			if (m_Collection.IndexOf(sender) == -1)
			{
				((INotifyPropertyChanged) sender).PropertyChanged -= PropertyChangedEventHandler;
			}
			else if (!m_IsInternal)
			{
				m_IsInternal = true;
				if (e.PropertyName == m_AttrNumber)
				{
					m_Collection.FixItemOrder(m_Getter, m_Setter, (T)sender);
				}
				m_IsInternal = false;
			}
		}
	}

	/// <summary>
	/// Подключить спецификацию для автоматического отслеживания нумерации
	/// </summary>
	/// <typeparam name="T">Тип спецификации.</typeparam>
	/// <param name="context">Контекст раздела.</param>
	/// <param name="collection">Коллекция элементов спецификации.</param>
	/// <param name="getter">Извлекатель номера из элемента спецификации.</param>
	/// <param name="setter">Установщик номера в элементе спецификации.</param>
	/// <param name="attrNumber">Имя аттрибута с номером (числовой домен).</param>
	public static void AttachAutoNumber<T>(
		this IUnitExecutionContext context,
		IBindingList collection,
		OrderedCollectionHelper.NumberGetter<T> getter,
		OrderedCollectionHelper.NumberSetter<T> setter,
		string attrNumber
		)
	{
		new AutoNumberClientEngine<T>(collection, getter, setter, attrNumber /*, context*/);
	}
}
