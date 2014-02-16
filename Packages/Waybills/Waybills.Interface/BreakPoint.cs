using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Точка остановки
	/// </summary>
	[Metadata("Acme.Business.Waybills.BreakPoint.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IBreakPoint
	{
		#region Physical Attributes
		/// <summary>
		/// Порядковый номер точки остановки
		/// </summary>
		[Transactional]
		WayPointNumber Number
		{
			get;
			set;
		}
		/// <summary>
		/// Дата прибытия
		/// </summary>
		[Transactional]
		Date ArrivalDate
		{
			get;
			set;
		}
		/// <summary>
		/// Дата убытия
		/// </summary>
		[Transactional]
		Date DepartureDate
		{
			get;
			set;
		}
		#endregion
		#region Ref Attributes
		/// <summary>
		/// Пункт маршрута
		/// </summary>
		[Transactional]
		IWayPoint Point
		{
			get;
			set;
		}
		#endregion
		///<summary>
		/// Master 
		///</summary>
		[MasterReference]
		Acme.Business.Waybills.IWaybill Master
		{
			get;
		}
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.IBreakPoint))]
	public interface IBreakPointFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IBreakPoint Default(Acme.Business.Waybills.IWaybill master);
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.BreakPoint.
	/// </summary>
	[CollectionAttribute(typeof(IBreakPoint))]
	public interface IBreakPointCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IBreakPoint this[int index]
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
		int Add(IBreakPoint obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IBreakPoint item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IBreakPoint item);
	}
}
