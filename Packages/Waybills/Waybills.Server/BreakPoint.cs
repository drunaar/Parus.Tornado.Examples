using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="IBreakPoint"/>.
	/// </summary>
	[BizClass(typeof(IBreakPoint))]
	public abstract class BreakPoint : PersistedObjectBase, IBreakPoint
	{
		#region Physical Attributes
		/// <summary>
		/// Порядковый номер точки остановки
		/// </summary>
		[Transactional]
		public abstract WayPointNumber Number
		{
			get;
			set;
		}
		/// <summary>
		/// Дата прибытия
		/// </summary>
		[Transactional]
		public abstract Date ArrivalDate
		{
			get;
			set;
		}
		/// <summary>
		/// Дата убытия
		/// </summary>
		[Transactional]
		public abstract Date DepartureDate
		{
			get;
			set;
		}
		#endregion
		#region Reference Attributes
		/// <summary>
		/// Пункт маршрута
		/// </summary>
		[Transactional]
		public abstract IWayPoint Point
		{
			get;
			set;
		}
		///<summary>
		/// Master 
		///</summary>
		public abstract IWaybill Master
		{
			get;
		}
		#endregion
		#region Triggers
		/// <summary>
		/// Триггер на создание.
		/// </summary>
		[Trigger(TriggerType.Create)]
		protected virtual void CreateTrigger(IBreakPoint oldState)
		{
			Number = ((IWaybill)Master).Route.Count + 1;
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IBreakPointCreateArgs
		{
			///<summary>
			///Default create method
			///</summary>
			Acme.Business.Waybills.IWaybill master
			{
				get;
			}
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IBreakPointCreateArgs MyCreateArgs
		{
			get
			{
				return (IBreakPointCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract IBreakPointCreateArgs CreateArgs
		{
			get;
		}
	}
}
