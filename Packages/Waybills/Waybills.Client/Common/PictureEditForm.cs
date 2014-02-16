using System.Collections.Generic;
using System.IO;
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Tornado;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы PictureEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Common.PictureEditForm.zml")]
	public class PictureEditForm : ControllerBase
	{
		/// <summary>
		/// Делегат события изменения картинки.
		/// </summary>
		/// <param name="stream"></param>
		public delegate void StreamChangedDelegate(Stream stream);

		/// <summary>
		/// Делегат получения имени файла при сохранения картинки.
		/// </summary>
		/// <returns></returns>
		public delegate string StreamFileNameGetterDelegate();

		private Stream m_PictureStream;
		private IButton m_Save = null;
		private IPicture m_Picture = null;

		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public PictureEditForm(IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
		}

		/// <summary>
		/// Событие изменения картинки.
		/// </summary>
		public StreamChangedDelegate StreamChanged
		{ get; set; }

		/// <summary>
		/// Событие получения имени файла при сохранения картинки.
		/// </summary>
		public StreamFileNameGetterDelegate StreamFileNameGetter
		{ get; set; }

		/// <summary>
		/// Картинка.
		/// </summary>
		public Stream Picture
		{
			set
			{
				if (value == null || value.Length == 0)
				{
					m_PictureStream = null;
					m_Picture.Image = null;
					m_Save.Enabled = false;
				}
				else
				{
					m_PictureStream = value.CreateTemporaryCopy();
					m_Picture.Image = System.Drawing.Image.FromStream(m_PictureStream);
					m_Save.Enabled = true;
				}
			}
		}

		private void Open_ClickEventHandler(object sender, System.EventArgs e)
		{
			Context.RunUnitInChildHost(typeof(FileManagerUnit), FileManagerUnit.Points.Upload,
				new Dictionary<string, object>()
					{
						{
							WellKnownNames.Context.CurrentObject,
							new UploadMonitor((monitor, fileName) =>
								{
									if (StreamChanged != null)
									{
										using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
										{
											StreamChanged(stream);
										}
									}

								})
							}
					}
				);
		}

		private void Save_ClickEventHandler(object sender, System.EventArgs e)
		{
			var fmt = m_Picture.Image.RawFormat;
			System.Drawing.Imaging.ImageCodecInfo codecInfo = null;
			foreach (var ci in System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders())
			{
				if (ci.FormatID == fmt.Guid)
				{
					codecInfo = ci;
					break;
				}
			}
			if (codecInfo == null) throw new System.NotSupportedException();
			var ext = codecInfo.FilenameExtension.Split(';')[0];
			var name = StreamFileNameGetter == null
				? null
				: StreamFileNameGetter();
			Context.RunUnitInChildHost(typeof (FileManagerUnit), FileManagerUnit.Points.Download,
				new Dictionary<string, object>()
					{
						{
							WellKnownNames.Context.CurrentObject,
							new[]
								{
									new DownloadFileInfo(
										ext.Replace("*", string.IsNullOrEmpty(name) ? "Безымянный" : name),
										m_PictureStream.Length,
										() => m_PictureStream.CreateTemporaryCopy())
								}
							}
					}
				);
		}

		private void Clear_ClickEventHandler(object sender, System.EventArgs e)
		{
			if (StreamChanged != null) StreamChanged(null);
		}
	}
}
