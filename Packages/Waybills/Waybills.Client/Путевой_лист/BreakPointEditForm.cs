
using Parus.Net.Server;
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Tornado;

using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы BreakPointEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Путевой_лист.BreakPointEditForm.zml")]
	public class BreakPointEditForm : ControllerBase
	{
		private ISpinEdit m_Number = null;
		private IWaybill m_Waybill;
		private IBreakPoint m_BreakPoint;
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public BreakPointEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{
			m_BreakPoint = (IBreakPoint)Context.GetCurrentObject();
			m_Waybill = m_BreakPoint.Master;
		}

		private void Number_ValueChangedEventHandler(object sender, System.EventArgs e)
		{
			if (m_Number.Value != m_BreakPoint.Number)
			{
				//m_Waybill.SetBreakPointPosition(m_BreakPoint, m_Number.Value);
				m_Number.Value = m_BreakPoint.Number;
			}
		}

		private void Form_LoadedEventHandler(object sender, System.EventArgs e)
		{
			m_Number.MaxValue = m_Waybill.Route.Count;
			m_Number.MinValue = 1;
			//m_Number.Value = m_BreakPoint.Number;
			//m_Number.ValueChanged += Number_ValueChangedEventHandler;
		}
	}
}
