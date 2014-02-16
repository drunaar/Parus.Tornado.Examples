
using Parus.SmartClient.Model;
using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.Пункт_маршрута.WayPoint.unit")]
	public partial class WayPointUnit : UnitBase
	{
		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public WayPointUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}

		private string EditView_SelectTransitionEventHandler(IUnitExecutionContext context)
		{
			var currentObject = (IWayPoint) context.GetCurrentObject();
			return currentObject.ExtId == null
				? Transitions.Edit_EditView
				: Transitions.View_EditView;
		}
	}
}
