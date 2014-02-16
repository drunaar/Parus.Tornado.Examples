
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;

using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы ConveyanceDeedEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Акт_передачи.ConveyanceDeedEditForm.zml")]
	public partial class ConveyanceDeedEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public ConveyanceDeedEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
