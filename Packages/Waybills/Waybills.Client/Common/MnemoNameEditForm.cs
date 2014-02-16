using Parus.SmartClient.Common.CodeBehind;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы MnemoNameEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Common.MnemoNameEditForm.zml")]
	public class MnemoNameEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public MnemoNameEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}
	}
}
