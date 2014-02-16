using System;
using System.ComponentModel;
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Tornado;
using IServiceProvider=Rsdn.SmartApp.IServiceProvider;

namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Контроллер формы PerishablesWaybillEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.PerishablesWaybills.PerishablesWaybillEditForm.zml")]
	public class PerishablesWaybillEditForm : ControllerBase
	{
		private IPerishablesWaybill m_CurrentObject;
		private IDateTimeEdit m_ServiceableLife = null;

		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public PerishablesWaybillEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}

		private void ServiceableLife_ValueChangedEventHandler(object sender, System.EventArgs e)
		{
			var serviceableLife = m_CurrentObject.Date == null
				? new System.TimeSpan()
				: m_ServiceableLife.Value - m_CurrentObject.Date;
			if (m_CurrentObject.ServiceableLife != serviceableLife)
			{
				m_CurrentObject.ServiceableLife = serviceableLife;
			}
		}

		private void Form_LoadedEventHandler(object sender, System.EventArgs e)
		{
			m_CurrentObject = (IPerishablesWaybill)Context.GetCurrentObject();
			((INotifyPropertyChanged)m_CurrentObject).PropertyChanged += Waybill_PropertyChangedEventHandler;
			Form.Closed += (s, a) =>
				{
					((INotifyPropertyChanged) m_CurrentObject).PropertyChanged -=
						Waybill_PropertyChangedEventHandler;
				};
			UpdateServiceableLifeControl();
		}

		private void UpdateServiceableLifeControl()
		{
			var date = m_CurrentObject.Date == null
				? null
				: m_CurrentObject.Date + m_CurrentObject.ServiceableLife;
			if (m_ServiceableLife.Value != date)
			{
				m_ServiceableLife.Value = date;
			}
		}

		private void Waybill_PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case "Date":
					UpdateServiceableLifeControl();
					break;
				case "ServiceableLife":
					UpdateServiceableLifeControl();
					break;
			}
		}
	}
}
