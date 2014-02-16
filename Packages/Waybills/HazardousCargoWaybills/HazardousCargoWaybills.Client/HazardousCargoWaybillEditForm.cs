using Parus.SmartClient.Common.CodeBehind;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills.HazardousCargoWaybills
{
	/// <summary>
	/// Контроллер формы HazardousCargoWaybillEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.HazardousCargoWaybills.HazardousCargoWaybillEditForm.zml")]
	public class HazardousCargoWaybillEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public HazardousCargoWaybillEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
