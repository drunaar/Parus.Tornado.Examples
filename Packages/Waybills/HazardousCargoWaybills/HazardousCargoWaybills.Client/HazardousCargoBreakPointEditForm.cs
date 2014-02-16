using Parus.SmartClient.Common.CodeBehind;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills.HazardousCargoWaybills
{
	/// <summary>
	/// Контроллер формы HazardousCargoBreakPointEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoBreakPointEditForm.zml")]
	public class HazardousCargoBreakPointEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public HazardousCargoBreakPointEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
