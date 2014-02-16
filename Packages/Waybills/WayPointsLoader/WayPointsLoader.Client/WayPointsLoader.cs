
using System;
using System.Data;
using Parus.SmartClient.Model;
using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills.WayPointsLoader
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.WayPointsLoader.WayPointsLoader.unit")]
	public partial class WayPointsLoaderUnit : UnitBase
	{
		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public WayPointsLoaderUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}

		private void SaveWayPointsEventHandler(IUnitExecutionContext context)
		{
			var dataTable = (DataTable) context.GetCurrentObject();
			var objectManager = context.GetService<IObjectManager>();
			var tx = context.BeginTransaction();
			try
			{
				foreach(DataRow row in dataTable.Rows)
				{
					if ((bool)row["UseFlag"])
					{
						var wayPoint = (IWayPoint) objectManager.NewObject(typeof (IWayPoint));
						wayPoint.Mnemo = (string) row["Name"];
						wayPoint.Name = (string) row["FullName"];
						wayPoint.ExtId = new GUID((string) row["Id"]);
					}
				}
				tx.Commit();
				tx= null;
			}
			finally
			{
				if (tx != null)
					tx.Rollback();
			}
		}

		private void CheckDataEventHandle(IUnitExecutionContext context)
		{
			ProcessData(context, false);
		}

		private void SaveDataEventHandle(IUnitExecutionContext context)
		{
			ProcessData(context, true);
		}

		private void ProcessData(IUnitExecutionContext context, bool Save)
		{
			var inputData = context.GetCurrentObject() as DataTable;
			if (inputData == null) return;

			var objectManager = context.GetService<IObjectManager>();
			var loader = (IWayPointsLoader) objectManager.NewObject(typeof (IWayPointsLoader));

			var selectedData = new DataTable();
			//selectedData.Columns.Add(WayPointsFields.Mnemo, typeof(Mnemo));
			//selectedData.Columns.Add(WayPointsFields.Name, typeof(Name));
			//selectedData.Columns.Add(WayPointsFields.ExtId, typeof(GUID));
			selectedData.Columns.Add(WayPointsFields.Mnemo);
			selectedData.Columns.Add(WayPointsFields.Name);
			selectedData.Columns.Add(WayPointsFields.ExtId);

			foreach (DataRow row in inputData.Rows)
			{
				if ((bool) row[WayPointsFields.UseFlag])
				{
					var newRow = selectedData.NewRow();
					selectedData.Rows.Add(newRow);
					//newRow[WayPointsFields.Mnemo] = new Mnemo((string)row[WayPointsFields.Mnemo]);
					//newRow[WayPointsFields.Name] = new Name((string)row[WayPointsFields.Name]);
					//newRow[WayPointsFields.ExtId] = new GUID((string)row[WayPointsFields.ExtId]);
					foreach (DataColumn clm in selectedData.Columns)
					{
						newRow[clm] = row[clm.ToString()];
					}
				}
			}

			var resultData = WayPointsLoaderHelper.CreateWayPoinsExtIdIndex(
				Save ? loader.SaveData(selectedData) : loader.CheckData(selectedData));
			foreach (DataRow row in inputData.Rows)
			{
				DataRow resultRow;
				resultData.TryGetValue(new GUID(row[WayPointsFields.ExtId].ToString()), out resultRow);
				if ((bool) row[WayPointsFields.UseFlag])
				{
					row[WayPointsFields.Status] = resultRow == null
						? "Ошибка: операция не выполнена"
						: resultRow[WayPointsFields.Status];
				}
				else
				{
					row[WayPointsFields.Status] = resultRow == null
						? string.Empty
						: "Ошибка: Лишняя операция - " + resultRow[WayPointsFields.Status];
				}
			}
		}
	}
}
