using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Остановка для скоропортящихся грузов
	/// </summary>
	[Metadata("Acme.Business.Waybills.PerishablesWaybills.PerishablesBreakPoint.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IPerishablesBreakPoint : Acme.Business.Waybills.IBreakPoint
	{
		#region Physical Attributes
		/// <summary>
		/// Процент износа
		/// </summary>
		[Transactional]
		WearPercent Wear
		{
			get;
			set;
		}
		#endregion
		///<summary>
		/// Master 
		///</summary>
		[MasterReference]
		Acme.Business.Waybills.PerishablesWaybills.IPerishablesWaybill Master
		{
			get;
		}
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.PerishablesWaybills.IPerishablesBreakPoint))]
	public interface IPerishablesBreakPointFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IPerishablesBreakPoint Default(Acme.Business.Waybills.PerishablesWaybills.IPerishablesWaybill master);
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.PerishablesWaybills.PerishablesBreakPoint.
	/// </summary>
	[CollectionAttribute(typeof(IPerishablesBreakPoint))]
	public interface IPerishablesBreakPointCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IPerishablesBreakPoint this[int index]
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
		int Add(IPerishablesBreakPoint obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IPerishablesBreakPoint item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IPerishablesBreakPoint item);
	}
}
