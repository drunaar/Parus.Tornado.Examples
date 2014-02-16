using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills.HazardousCargoWaybills
{
	/// <summary>
	/// Реализация класса <see href="IHazardousCargoBreakPoint"/>.
	/// </summary>
	[BizClass(typeof(IHazardousCargoBreakPoint))]
	public abstract class HazardousCargoBreakPoint : Acme.Business.Waybills.BreakPoint, IHazardousCargoBreakPoint
	{
		#region Physical Attributes
		/// <summary>
		/// Проверяющий
		/// </summary>
		[Transactional]
		public abstract Acme.Business.Waybills.Name Inspector
		{
			get;
			set;
		}
		///<summary>
		/// Master 
		///</summary>
		IHazardousCargoWaybill IHazardousCargoBreakPoint.Master
		{
			get
			{
				return (IHazardousCargoWaybill)((IBreakPoint)this).Master;
			}
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IHazardousCargoBreakPointCreateArgs
		{
			///<summary>
			///Default create method
			///</summary>
			Acme.Business.Waybills.HazardousCargoWaybills.IHazardousCargoWaybill master
			{
				get;
			}
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IHazardousCargoBreakPointCreateArgs MyCreateArgs
		{
			get
			{
				return (IHazardousCargoBreakPointCreateArgs)this.CreateArgs;
			}
		}
	}
}
