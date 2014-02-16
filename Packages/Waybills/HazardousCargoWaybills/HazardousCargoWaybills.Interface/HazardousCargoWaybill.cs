using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills.HazardousCargoWaybills
{
	/// <summary>
	/// Путевой лист для опасных грузов
	/// </summary>
	[Metadata("Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoWaybill.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IHazardousCargoWaybill : Acme.Business.Waybills.IWaybill
	{
		#region Details Collections
		/// <summary>
		/// Маршрут опасных грузов
		/// </summary>
		[DetailCollection(typeof(IHazardousCargoBreakPoint))]
		IHazardousCargoBreakPointDetailCollection HazardousCargoRoute
		{
			get;
		}
		#endregion
		#region Physical Attributes
		/// <summary>
		/// Опасность груза
		/// </summary>
		[Transactional]
		HazardousType Hazardous
		{
			get;
			set;
		}
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.HazardousCargoWaybills.IHazardousCargoWaybill))]
	public interface IHazardousCargoWaybillFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IHazardousCargoWaybill Default();
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoWaybill.
	/// </summary>
	[CollectionAttribute(typeof(IHazardousCargoWaybill))]
	public interface IHazardousCargoWaybillCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IHazardousCargoWaybill this[int index]
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
		int Add(IHazardousCargoWaybill obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IHazardousCargoWaybill item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IHazardousCargoWaybill item);
	}
	/// <summary>
	/// Коллекция экземпляров класса детэйлов Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoBreakPoint.
	/// </summary>
	public interface IHazardousCargoBreakPointDetailCollection : IHazardousCargoBreakPointCollection
	{
		/// <summary>
		/// Владелец коллекции.
		/// </summary>
		IHazardousCargoWaybill Master
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
		int Remove(IHazardousCargoBreakPoint item);
	}
}
