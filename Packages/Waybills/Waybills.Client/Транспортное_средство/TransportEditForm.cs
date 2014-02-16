
using System.IO;
using Parus.Common;
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Model;
using Parus.SmartClient.Tornado;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы TransportEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Транспортное_средство.TransportEditForm.zml")]
	public class TransportEditForm : ControllerBase
	{
		private ITransport m_CurrentObject;
		
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public TransportEditForm(IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
			m_CurrentObject = (ITransport) Context.GetCurrentObject();
		}

		private IFormSocket m_Avatar = null;
		private IFormSocket m_Photo = null;

		private PictureEditForm AvatarForm
		{
			get
			{
				return (PictureEditForm)m_Avatar.Form.Controller;
			}
		}

		private PictureEditForm PhotoForm
		{
			get
			{
				return (PictureEditForm)m_Photo.Form.Controller;
			}
		}

		private void Form_LoadedEventHandler(object sender, System.EventArgs e)
		{
			AvatarForm.StreamChanged = AvatarStreamChangedEventHandler;
			AvatarForm.StreamFileNameGetter = () => m_CurrentObject.Mnemo;
			PhotoForm.StreamChanged = PhotoStreamChangedEventHandler;
			PhotoForm.StreamFileNameGetter = () => m_CurrentObject.Name;

			AvatarForm.Picture = m_CurrentObject.Avatar != null
				? new System.IO.MemoryStream(m_CurrentObject.Avatar)
				: null;
			TabControl_SelectedChangedEventHandler(m_TabControl, null);
		}

		private void AvatarStreamChangedEventHandler(Stream stream)
		{
			if (stream != null)
			{
				m_CurrentObject.Avatar = stream.GetStreamBytes();
				AvatarForm.Picture = new System.IO.MemoryStream(m_CurrentObject.Avatar);
			}
			else
			{
				m_CurrentObject.Avatar = null;
				AvatarForm.Picture = null;
			}
		}

		private void PhotoStreamChangedEventHandler(Stream streamIn)
		{
			var length = streamIn == null ? 0 : streamIn.Length;
			if (length == 0) streamIn = null;

			var objectManager = GetService<IObjectManager>();
			if (m_CurrentObject.Photo == null)
			{
				m_CurrentObject.Photo = objectManager.CreateTempStream();
			}

			if (streamIn != null)
			{
                objectManager.SetRemoteStream(m_CurrentObject.Photo, streamIn);
			}
			PhotoForm.Picture = streamIn;
		}

		private ITabPage m_PhotoPage = null;
		private ITabControl m_TabControl = null;

		private void TabControl_SelectedChangedEventHandler(object sender, System.EventArgs e)
		{
			var tab = (ITabControl) sender;
			if (tab.SelectedPage == m_PhotoPage)
			{
				var objectManager = GetService<IObjectManager>();
				if (m_CurrentObject.Photo != null)
				{
					using (var stream = objectManager.GetRemoteStreamReadonly(m_CurrentObject.Photo))
					{
						PhotoForm.Picture = stream.Length > 0 ? stream : null;
					}
				}
				m_PhotoPage = null;
			}
		}
	}
}
