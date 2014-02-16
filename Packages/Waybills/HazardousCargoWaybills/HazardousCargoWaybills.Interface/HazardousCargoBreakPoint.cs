using System.Collections;
using System.Collections.Generic;
using System.Data;

using Parus.Net.Server;

namespace Acme.Business.Waybills.HazardousCargoWaybills
{
/// <summary>
/// Остановка для опасных грузов
/// </summary>
[Metadata("Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoBreakPoint.metadata")]
[LifeTimeAttribute(LifeTime.Transaction)]
public partial interface IHazardousCargoBreakPoint : Acme.Business.Waybills.IBreakPoint
{

	#region Master support
		/// <summary>
		/// Мастер .
		/// </summary>
		[MasterReferenceAttribute]
		new IHazardousCargoWaybill Master
		{get;}
	#endregion
		
	#region Physical Attributes
	/// <summary>
	/// Проверяющий
	/// </summary>
	[Transactional]
	Acme.Business.Waybills.Name Inspector
	{get; set;}

	#endregion


}

		/// <summary>
		/// Интерфейс фабрики классов Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoBreakPoint.
		/// </summary>
		[ServerFactoryInterfaceAttribute(typeof(IHazardousCargoBreakPoint))]
		public interface IHazardousCargoBreakPointFactory
		{
			/// <summary>
	/// Default create method
	/// </summary>
[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
	IHazardousCargoBreakPoint Default(Acme.Business.Waybills.HazardousCargoWaybills.IHazardousCargoWaybill master);

		}

		#region generated code
/// <summary>
/// Интерфейс коллекции классов Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoBreakPoint.
/// </summary>
[CollectionAttribute(typeof(IHazardousCargoBreakPoint))]		
public interface IHazardousCargoBreakPointCollection : ICollection
{
	/// <summary>
	/// Индексер.
	/// </summary>
	IHazardousCargoBreakPoint this[int index] {get; set;}

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
	{get;set;}

	/// <summary>
	/// Добавляет объект в коллекцию
	/// </summary>
	/// <param name="obj">Объект</param>
	/// <returns>Индекс объекта в коллекции</returns>
	int Add(IHazardousCargoBreakPoint obj);

	/// <summary>
	/// Удаляет объект из коллекции
	/// </summary>
	/// <param name="index">Индекс объекта</param>
	/// <returns>Размер коллекции</returns>
	int RemoveAt(int index);

	/// <summary>
	/// Проверяет - содержит ли указанный класс.
	/// </summary>
	bool Contains(IHazardousCargoBreakPoint item);
		
	/// <summary>
	/// Получает индекс переданного класса.
	/// </summary>
	int IndexOf(IHazardousCargoBreakPoint item);
	}
 
 #endregion
}
