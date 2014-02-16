
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;

using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы WaybillHeaderEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Путевой_лист.WaybillHeaderEditForm.zml")]
	public class WaybillHeaderEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public WaybillHeaderEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
