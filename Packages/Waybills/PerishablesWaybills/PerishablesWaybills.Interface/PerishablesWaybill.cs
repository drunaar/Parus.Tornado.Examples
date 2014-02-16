using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Путевой лист для скоропортящихся грузов
	/// </summary>
	[Metadata("Acme.Business.Waybills.PerishablesWaybills.PerishablesWaybill.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IPerishablesWaybill : Acme.Business.Waybills.IWaybill
	{
		#region Details Collections
		/// <summary>
		/// Маршрут скоропортящихся грузов
		/// </summary>
		[DetailCollection(typeof(IPerishablesBreakPoint))]
		IPerishablesBreakPointDetailCollection PerishablesRoute
		{
			get;
		}
		#endregion
		#region Physical Attributes
		/// <summary>
		/// Срок годности
		/// </summary>
		[Transactional]
		Acme.Business.Waybills.TimeInterval ServiceableLife
		{
			get;
			set;
		}
		#endregion
		#region Calc Attributes
		/// <summary>
		/// Общий процент износа
		/// </summary>
		WearPercent TotalWear
		{
			get;
		}
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.PerishablesWaybills.IPerishablesWaybill))]
	public interface IPerishablesWaybillFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IPerishablesWaybill Default();
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.PerishablesWaybills.PerishablesWaybill.
	/// </summary>
	[CollectionAttribute(typeof(IPerishablesWaybill))]
	public interface IPerishablesWaybillCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IPerishablesWaybill this[int index]
		{
			get;
			set;
		}
		/// <summary>
		/// Сортирует коллекцию основываясь на критерии сравнения
		/// </summary>
		/// <param name="comparer">Критерии сравнения объектов</param>
		void Sort(IComparer comparer);
		/// <summary>
		/// Критерий сортировки объектов - может быть null в этом случае коллекция
		/// будет не отсортированной.
		///	</summary>
		/// <remarks>В первоначально созданной коллекции отсутствует критерий сортировки
		/// </remarks>
		IComparer Comparer
		{
			get;
			set;
		}
		/// <summary>
		/// Добавляет объект в коллекцию
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <returns>Индекс объекта в коллекции</returns>
		int Add(IPerishablesWaybill obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IPerishablesWaybill item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IPerishablesWaybill item);
	}
	/// <summary>
	/// Коллекция экземпляров класса детэйлов Acme.Business.Waybills.PerishablesWaybills.PerishablesBreakPoint.
	/// </summary>
	public interface IPerishablesBreakPointDetailCollection : IPerishablesBreakPointCollection
	{
		/// <summary>
		/// Владелец коллекции.
		/// </summary>
		IPerishablesWaybill Master
		{
			get;
		}
		/// <summary>
		/// Добавить элемент в коллекцию.
		/// </summary>
		int AddNew();
		/// <summary>
		/// Удалить элемент из коллекции.
		/// </summary>
		int Remove(IPerishablesBreakPoint item);
	}
}
