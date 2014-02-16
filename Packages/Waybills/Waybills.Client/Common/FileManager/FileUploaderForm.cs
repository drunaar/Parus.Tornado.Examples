using System;
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Tornado;
using IServiceProvider=Rsdn.SmartApp.IServiceProvider;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы FileUploaderForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Common.FileManager.FileUploaderForm.zml")]
	public class FileUploaderForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public FileUploaderForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}

		private void ValueChangedEventHandler(object sender, EventArgs e)
		{
			Context.SetCurrentObject(((IFileUploader) sender).Value);
		}
	}
}
