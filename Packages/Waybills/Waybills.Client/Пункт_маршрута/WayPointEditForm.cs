
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;

using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы WayPointEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Пункт_маршрута.WayPointEditForm.zml")]
	public class WayPointEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public WayPointEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
