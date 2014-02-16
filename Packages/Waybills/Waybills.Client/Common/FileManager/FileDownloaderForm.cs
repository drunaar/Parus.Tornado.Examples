using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Tornado;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы FileDownloaderForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Common.FileManager.FileDownloaderForm.zml")]
	public class FileDownloaderForm : ControllerBase
	{
		private IFileDownloader m_FileDownloader = null;

		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public FileDownloaderForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}

		private void Form_LoadedEventHandler(object sender, System.EventArgs e)
		{
			var streams = (DownloadFileInfo[]) Context.GetCurrentObject();
			foreach (var stream in streams)
			{
				m_FileDownloader.AddFile(stream, true);
			}
		}
	}
}
