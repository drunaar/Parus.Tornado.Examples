using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills.HazardousCargoWaybills
{
	/// <summary>
	/// Реализация класса <see href="IHazardousCargoWaybill"/>.
	/// </summary>
	[BizClass(typeof(IHazardousCargoWaybill))]
	public abstract class HazardousCargoWaybill : Acme.Business.Waybills.Waybill, IHazardousCargoWaybill
	{
		#region Details collections
		/// <summary>
		/// Маршрут опасных грузов
		/// </summary>
		[DetailCollection(typeof(IHazardousCargoBreakPoint))]
		public abstract IHazardousCargoBreakPointDetailCollection HazardousCargoRoute
		{
			get;
		}
		#endregion
		#region Physical Attributes
		/// <summary>
		/// Опасность груза
		/// </summary>
		[Transactional]
		public abstract HazardousType Hazardous
		{
			get;
			set;
		}
		#endregion
		#region Triggers
		/// <summary>
		/// Триггер на создание.
		/// </summary>
		[Trigger(TriggerType.Create)]
		protected virtual void CreateTrigger(IHazardousCargoWaybill oldState)
		{
			Hazardous = HazardousTypeEnum.NonHazard;
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IHazardousCargoWaybillCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IHazardousCargoWaybillCreateArgs MyCreateArgs
		{
			get
			{
				return (IHazardousCargoWaybillCreateArgs)this.CreateArgs;
			}
		}
	}
}
