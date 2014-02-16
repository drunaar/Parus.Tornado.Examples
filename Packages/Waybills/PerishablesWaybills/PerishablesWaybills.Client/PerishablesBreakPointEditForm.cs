using Parus.SmartClient.Common.CodeBehind;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Контроллер формы PerishablesBreakPointEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.PerishablesWaybills.PerishablesBreakPointEditForm.zml")]
	public class PerishablesBreakPointEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public PerishablesBreakPointEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
