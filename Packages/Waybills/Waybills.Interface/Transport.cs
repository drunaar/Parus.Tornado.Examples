using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Транспортное средство
	/// </summary>
	[Metadata("Acme.Business.Waybills.Transport.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface ITransport
	{
		#region Physical Attributes
		/// <summary>
		/// Мнемокод транспортного средства
		/// </summary>
		[Transactional]
		Mnemo Mnemo
		{
			get;
			set;
		}
		/// <summary>
		/// Наименование транспортного средства
		/// </summary>
		[Transactional]
		Name Name
		{
			get;
			set;
		}
		/// <summary>
		/// Аватар транспортного средства
		/// </summary>
		[Transactional]
		SmallPicture Avatar
		{
			get;
			set;
		}
		/// <summary>
		/// Фотография транспортного средства
		/// </summary>
		[Transactional]
		BigPicture Photo
		{
			get;
			set;
		}
		/// <summary>
		/// Годность транспортного средства к эксплуатации
		/// </summary>
		[Transactional]
		Serviceable Serviceable
		{
			get;
			set;
		}
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.ITransport))]
	public interface ITransportFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		ITransport Default();
	}
	/// <summary>
	/// Интерфейс коллекции классов Acme.Business.Waybills.Transport.
	/// </summary>
	[CollectionAttribute(typeof(ITransport))]
	public interface ITransportCollection : ICollection
	{
		/// <summary>
		/// Индексер.
		/// </summary>
		ITransport this[int index]
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
		int Add(ITransport obj);
		/// <summary>
		/// Удаляет объект из коллекции
		/// </summary>
		/// <param name="index">Индекс объекта</param>
		/// <returns>Размер коллекции</returns>
		int RemoveAt(int index);
		/// <summary>
		/// Проверяет - содержит ли указанный класс.
		/// </summary>
		bool Contains(ITransport item);
		/// <summary>
		/// Получает индекс переданного класса.
		/// </summary>
		int IndexOf(ITransport item);
	}
}
