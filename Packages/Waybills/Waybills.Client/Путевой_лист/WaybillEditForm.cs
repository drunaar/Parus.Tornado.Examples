
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Tornado;
using Rsdn.SmartApp;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Контроллер формы WaybillEditForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.Путевой_лист.WaybillEditForm.zml")]
	public class WaybillEditForm : ControllerBase
	{
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public WaybillEditForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}

		private IGrid m_Grid = null;
		
		private void ChangeNumber(int delta)
		{
			var doc = (IWaybill) Context.GetCurrentObject();
			var i = m_Grid.FocusedRow;
			if (i >= 0 && i < doc.Route.Count)
			{
				m_Grid.BeginUpdate();
				doc.Route[i].Number += delta;
				m_Grid.EndUpdate();
			}
		}
		
		private void IncreaseNumber_ClickEventHandler(object sender, System.EventArgs e)
		{
			ChangeNumber(1);
		}
		
		private void DecreaseNumber_ClickEventHandler(object sender, System.EventArgs e)
		{
			ChangeNumber(-1);
		}
	}
}
