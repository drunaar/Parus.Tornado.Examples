using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Путевой лист
	/// </summary>
	[Metadata("Acme.Business.Waybills.Waybill.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IWaybill
	{
		#region Details Collections
		/// <summary>
		/// Маршрут (коллекция точек остановок)
		/// </summary>
		[DetailCollection(typeof(IBreakPoint))]
		IBreakPointDetailCollection Route
		{
			get;
		}
		#endregion
		#region Physical Attributes
		/// <summary>
		/// Номер документа
		/// </summary>
		[Transactional]
		DocNumber Number
		{
			get;
			set;
		}
		/// <summary>
		/// Дата документа
		/// </summary>
		[Transactional]
		Date Date
		{
			get;
			set;
		}
		#endregion
		#region Ref Attributes
		/// <summary>
		/// Транспортное средство
		/// </summary>
		[Transactional]
		ITransport Transport
		{
			get;
			set;
		}
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.IWaybill))]
	public interface IWaybillFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IWaybill Default();
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.Waybill.
	/// </summary>
	[CollectionAttribute(typeof(IWaybill))]
	public interface IWaybillCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IWaybill this[int index]
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
		int Add(IWaybill obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IWaybill item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IWaybill item);
	}
	/// <summary>
	/// Коллекция экземпляров класса детэйлов Acme.Business.Waybills.BreakPoint.
	/// </summary>
	public interface IBreakPointDetailCollection : IBreakPointCollection
	{
		/// <summary>
		/// Владелец коллекции.
		/// </summary>
		IWaybill Master
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
		int Remove(IBreakPoint item);
	}
}
