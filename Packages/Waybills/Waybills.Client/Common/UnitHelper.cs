using System.Collections.Generic;
using Parus.SmartClient.Model;
using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Помошник для работы с разделами.
	/// </summary>
	public static class UnitHelper
	{
		/// <summary>
		/// Выполнить раздел в "модальном" дочернем окне.
		/// </summary>
		/// <param name="context">Контекст раздела.</param>
		/// <param name="unitType">Тип раздела.</param>
		/// <param name="startPoint">Стартовая точка.</param>
		/// <param name="additionalParameters">Дополнительные параметры.</param>
		/// <returns>Контекст нового раздела.</returns>
		public static IUnitExecutionContext RunUnitInChildHost(
			this IClientContext context,
			System.Type unitType,
			string startPoint,
			IDictionary<string, object> additionalParameters
			)
		{
			var unitManager = context.GetService<IUnitManager>();
			var newContext = unitManager.StartUnit(
				context,
				unitType,
				startPoint,
				additionalParameters);
			var host = context.GetCurrentWindowHost();
			var newHost = host.CreateChildHost();
			host.Top.Form.Enabled = false;
			newHost.Closed += (snd, ea) => { host.Top.Form.Enabled = true; };
			newContext.SetCurrentWindowHost(newHost);
			return unitManager.DoTransition(
				newContext,
				newContext.GetStartPoint().Transitions[0].Name,
				null);
		}
	}
}
