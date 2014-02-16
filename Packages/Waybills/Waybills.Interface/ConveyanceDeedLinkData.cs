using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Данные для связи путевого листа и акта передачи груза
	/// </summary>
	[Metadata("Acme.Business.Waybills.ConveyanceDeedLinkData.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IConveyanceDeedLinkData
	{
		#region Physical Attributes
		/// <summary>
		/// Дата+время установленной связи
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
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.IConveyanceDeedLinkData))]
	public interface IConveyanceDeedLinkDataFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IConveyanceDeedLinkData Default();
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.ConveyanceDeedLinkData.
	/// </summary>
	[CollectionAttribute(typeof(IConveyanceDeedLinkData))]
	public interface IConveyanceDeedLinkDataCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		IConveyanceDeedLinkData this[int index]
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
		int Add(IConveyanceDeedLinkData obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(IConveyanceDeedLinkData item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(IConveyanceDeedLinkData item);
	}
}
