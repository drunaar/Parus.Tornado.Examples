using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.PerishablesWaybills.PerishablesWaybill.unit")]
	public partial class PerishablesWaybillUnit : UnitBase
	{
		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public PerishablesWaybillUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}
	}
}
