using System.ComponentModel;
using System.IO;
using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.Транспортное_средство.Transport.unit")]
	public partial class TransportUnit : UnitBase
	{
		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public TransportUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}
	}
}
