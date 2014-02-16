using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="IWaybill"/>.
	/// </summary>
	[BizClass(typeof(IWaybill))]
	public abstract class Waybill : PersistedObjectBase, IWaybill
	{
		#region Details collections
		/// <summary>
		/// Маршрут (коллекция точек остановок)
		/// </summary>
		[DetailCollection(typeof(IBreakPoint))]
		public abstract IBreakPointDetailCollection Route
		{
			get;
		}
		#endregion
		#region Physical Attributes
		/// <summary>
		/// Номер документа
		/// </summary>
		[Transactional]
		public abstract DocNumber Number
		{
			get;
			set;
		}
		/// <summary>
		/// Дата документа
		/// </summary>
		[Transactional]
		public abstract Date Date
		{
			get;
			set;
		}
		#endregion
		#region Reference Attributes
		/// <summary>
		/// Транспортное средство
		/// </summary>
		[Transactional]
		public abstract ITransport Transport
		{
			get;
			set;
		}
		#endregion
		#region Triggers
		/// <summary>
		/// Триггер на коммит вставки.
		/// </summary>
		[Trigger(TriggerType.CommitInsert)]
		protected virtual void CommitInsertTrigger(IWaybill oldState)
		{
			ReorderBreakPoints();
		}
		/// <summary>
		/// Триггер на коммит изменения.
		/// </summary>
		[Trigger(TriggerType.CommitUpdate)]
		protected virtual void CommitUpdateTrigger(IWaybill oldState)
		{
			Manager.Lock(Id);
			ReorderBreakPoints();
		}
		/// <summary>
		/// Триггер на коммит удаления.
		/// </summary>
		[Trigger(TriggerType.CommitDelete)]
		protected virtual void CommitDeleteTrigger(IWaybill oldState)
		{
			var srv = Manager.CreateNew<IConveyanceDeedSevice>();
			srv.Unlink(this);
		}
		#endregion
		private void ReorderBreakPoints()
		{
			Route.ReorderByNumber<IBreakPoint>(x => x.Number, (x, v) => x.Number = v);
		}
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IWaybillCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IWaybillCreateArgs MyCreateArgs
		{
			get
			{
				return (IWaybillCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract IWaybillCreateArgs CreateArgs
		{
			get;
		}
	}
}
