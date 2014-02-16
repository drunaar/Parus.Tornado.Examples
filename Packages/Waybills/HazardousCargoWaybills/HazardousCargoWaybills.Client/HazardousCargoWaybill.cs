using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills.HazardousCargoWaybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoWaybill.unit")]
	public partial class HazardousCargoWaybillUnit : UnitBase
	{
		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public HazardousCargoWaybillUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}
	}
}
