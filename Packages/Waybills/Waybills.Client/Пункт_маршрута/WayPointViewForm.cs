
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;

using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы WayPointViewForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Пункт_маршрута.WayPointViewForm.zml")]
	public class WayPointViewForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public WayPointViewForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
