using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Реализация класса <see href="IPerishablesWaybill"/>.
	/// </summary>
	[BizClass(typeof(IPerishablesWaybill))]
	public abstract class PerishablesWaybill : Acme.Business.Waybills.Waybill, IPerishablesWaybill
	{
		#region Details collections
		/// <summary>
		/// Маршрут скоропортящихся грузов
		/// </summary>
		[DetailCollection(typeof(IPerishablesBreakPoint))]
		public abstract IPerishablesBreakPointDetailCollection PerishablesRoute
		{
			get;
		}
		#endregion
		#region Physical Attributes
		/// <summary>
		/// Срок годности
		/// </summary>
		[Transactional]
		public abstract Acme.Business.Waybills.TimeInterval ServiceableLife
		{
			get;
			set;
		}
		#endregion
		#region Evaluated Attributes
		/// <summary>
		/// Общий процент износа
		/// </summary>
		public abstract WearPercent TotalWear
		{
			get;
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IPerishablesWaybillCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IPerishablesWaybillCreateArgs MyCreateArgs
		{
			get
			{
				return (IPerishablesWaybillCreateArgs)this.CreateArgs;
			}
		}
	}
}
