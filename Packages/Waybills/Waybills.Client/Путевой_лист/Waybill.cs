
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Parus.Net.Server;
using Parus.SmartClient.Model;
using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.Путевой_лист.Waybill.unit")]
	public partial class WaybillUnit : UnitBase
	{
		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public WaybillUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}

		private void ModifyWaybill_TransitedEventHandler(IUnitExecutionContext context)
		{
			// Подключаем механику автонумерации
			context.AttachAutoNumber<IBreakPoint>(
				(IBindingList)((IWaybill)context.GetCurrentObject()).Route,
				x => x.Number, (x, v) => x.Number = v, "Number");
		}

		private void ModifyBreakPoint_TransitedEventHandler(IUnitExecutionContext context)
		{
			// Подключаем механику автонумерации
			context.AttachAutoNumber<IBreakPoint>(
				(IBindingList)((IBreakPoint)context.GetCurrentObject()).Master.Route,
				x => x.Number, (x, v) => x.Number = v, "Number");
		}
	}
}
