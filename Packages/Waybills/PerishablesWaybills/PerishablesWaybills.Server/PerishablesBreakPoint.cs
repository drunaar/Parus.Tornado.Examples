using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Реализация класса <see href="IPerishablesBreakPoint"/>.
	/// </summary>
	[BizClass(typeof(IPerishablesBreakPoint))]
	public abstract class PerishablesBreakPoint : Acme.Business.Waybills.BreakPoint, IPerishablesBreakPoint
	{
		#region Physical Attributes
		/// <summary>
		/// Процент износа
		/// </summary>
		[Transactional]
		public abstract WearPercent Wear
		{
			get;
			set;
		}
		///<summary>
		/// Master 
		///</summary>
		IPerishablesWaybill IPerishablesBreakPoint.Master
		{
			get
			{
				return (IPerishablesWaybill)((IBreakPoint)this).Master;
			}
		}
		#endregion
		#region Triggers
		/// <summary>
		/// Триггер на создание.
		/// </summary>
		[Trigger(TriggerType.Create)]
		protected virtual void CreateTrigger(IPerishablesBreakPoint oldState)
		{
			base.CreateTrigger(oldState);
			Wear = 0;
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IPerishablesBreakPointCreateArgs
		{
			///<summary>
			///Default create method
			///</summary>
			Acme.Business.Waybills.PerishablesWaybills.IPerishablesWaybill master
			{
				get;
			}
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IPerishablesBreakPointCreateArgs MyCreateArgs
		{
			get
			{
				return (IPerishablesBreakPointCreateArgs)this.CreateArgs;
			}
		}
	}
}
