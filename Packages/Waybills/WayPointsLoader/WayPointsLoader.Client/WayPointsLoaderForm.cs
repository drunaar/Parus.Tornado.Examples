
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Parus.Common;
using Parus.Net.Server;
using Parus.SmartClient.Common;
using Parus.SmartClient.Common.CodeBehind;
using Parus.SmartClient.Controls;
using Parus.SmartClient.Model;
using Parus.SmartClient.Tornado;
using IServiceProvider=Rsdn.SmartApp.IServiceProvider;

namespace Acme.Business.Waybills.WayPointsLoader
{
	/// <summary>
	/// Контроллер формы WayPointsLoaderForm
	/// </summary>
	[FormMetadata("Acme.Business.Waybills.WayPointsLoader.WayPointsLoaderForm.zml")]
	public class WayPointsLoaderForm : ControllerBase
	{
		private IGrid m_Grid = null;
		/// <summary>
		/// Инициализирует экземпляр.
		/// </summary>
		/// <param name="serviceProvider">Провайдер сервисов</param>
		public WayPointsLoaderForm(IServiceProvider serviceProvider) : base(serviceProvider)
		{}

		private void Open_ClickEventHandler(object sender, System.EventArgs e)
		{
			Context.RunUnitInChildHost(typeof (FileManagerUnit), "Upload",
				new Dictionary<string, object>()
					{
						{
							WellKnownNames.Context.CurrentObject,
							new UploadMonitor((monitor, fileName) =>
								{
									var dataTable = WayPointsLoaderHelper.LoadWayPoints(fileName);
									var clmUseFlag = dataTable.Columns.Add(WayPointsFields.UseFlag, typeof (bool));
									dataTable.Columns.Add(WayPointsFields.Status);
									foreach (DataRow row in dataTable.Rows)
									{
										row[clmUseFlag] = true;
									}
									m_Grid.DataSource = dataTable;
									Context.SetCurrentObject(dataTable);
								})
							}
					}
				);
		}

		private IUnitLinker m_UnitLinker = null;
		private IUnitLinkerTransition m_CheckDataTransition = null;
		private IUnitLinkerTransition m_SaveDataTransition = null;

		private void ProcessData(bool Save)
		{
			Context.SetCurrentObject(m_Grid.DataSource as DataTable);
			Parus.SmartClient.Common.ClientAsyncHelper.ExecuteAsync(op =>
				{
					op.Post(state => { m_Grid.DataSource = null; }, null);
					try
					{
						m_UnitLinker.DoTransition(Save ? m_SaveDataTransition : m_CheckDataTransition, null);
					}
					catch (Exception err)
					{
						op.Post(state =>
							{
								var messageService = Context.GetService<IMessageService>();
								messageService.ShowException(err);
							}, null);
					}
					finally
					{
						op.Post(state => { m_Grid.DataSource = Context.GetCurrentObject(); }, null);
					}
				});
		}

		private void Check_ClickEventHandler(object sender, EventArgs e)
		{
			ProcessData(false);
		}

		private void Save_ClickEventHandler(object sender, EventArgs e)
		{
			ProcessData(true);
		}
	}
}
