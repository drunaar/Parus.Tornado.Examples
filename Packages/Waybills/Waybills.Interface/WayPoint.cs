using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Пункт маршрута
	/// </summary>
	[Metadata("Acme.Business.Waybills.WayPoint.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IWayPoint
	{
		#region Physical Attributes
		/// <summary>
		/// Мнемокод пункта маршрута
		/// </summary>
		[Transactional]
		Mnemo Mnemo
		{
			get;
			set;
		}
		/// <summary>
		/// Наименование пункта маршрута
		/// </summary>
		[Transactional]
		Name Name
		{
			get;
			set;
		}
		/// <summary>
		/// Примечание
		/// </summary>
		[Transactional]
		Note Note
		{
			get;
			set;
		}
		/// <summary>
		/// Идентификатор по классификатору
		/// </summary>
		[Transactional]
		GUID ExtId
		{
			get;
			set;
		}
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.IWayPoint))]
	public interface IWayPointFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IWayPoint Default();
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.WayPoint.
	/// </summary>
	[CollectionAttribute(typeof(IWayPoint))]
	public interface IWayPointCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IWayPoint this[int index]
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
		int Add(IWayPoint obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IWayPoint item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IWayPoint item);
	}
}
