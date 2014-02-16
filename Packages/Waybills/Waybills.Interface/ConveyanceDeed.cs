using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Акт передачи груза
	/// </summary>
	[Metadata("Acme.Business.Waybills.ConveyanceDeed.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IConveyanceDeed
	{
		#region Physical Attributes
		/// <summary>
		/// Груз сдал
		/// </summary>
		[Transactional]
		Name SourceName
		{
			get;
			set;
		}
		/// <summary>
		/// Груз принял
		/// </summary>
		[Transactional]
		Name TargetName
		{
			get;
			set;
		}
		/// <summary>
		/// Дата передачи
		/// </summary>
		[Transactional]
		Date Date
		{
			get;
			set;
		}
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.IConveyanceDeed))]
	public interface IConveyanceDeedFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IConveyanceDeed Default();
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.ConveyanceDeed.
	/// </summary>
	[CollectionAttribute(typeof(IConveyanceDeed))]
	public interface IConveyanceDeedCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IConveyanceDeed this[int index]
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
		int Add(IConveyanceDeed obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IConveyanceDeed item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IConveyanceDeed item);
	}
}
