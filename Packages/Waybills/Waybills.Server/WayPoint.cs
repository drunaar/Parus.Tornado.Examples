using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="IWayPoint"/>.
	/// </summary>
	[BizClass(typeof(IWayPoint))]
	public abstract class WayPoint : PersistedObjectBase, IWayPoint
	{
		#region Physical Attributes
		/// <summary>
		/// Мнемокод пункта маршрута
		/// </summary>
		[Transactional]
		public abstract Mnemo Mnemo
		{
			get;
			set;
		}
		/// <summary>
		/// Наименование пункта маршрута
		/// </summary>
		[Transactional]
		public abstract Name Name
		{
			get;
			set;
		}
		/// <summary>
		/// Примечание
		/// </summary>
		[Transactional]
		public abstract Note Note
		{
			get;
			set;
		}
		/// <summary>
		/// Идентификатор по классификатору
		/// </summary>
		[Transactional]
		public abstract GUID ExtId
		{
			get;
			set;
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IWayPointCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IWayPointCreateArgs MyCreateArgs
		{
			get
			{
				return (IWayPointCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract IWayPointCreateArgs CreateArgs
		{
			get;
		}
	}
}
