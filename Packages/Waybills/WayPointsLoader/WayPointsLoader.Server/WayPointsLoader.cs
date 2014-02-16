using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Parus.Common;
using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills.WayPointsLoader
{
	/// <summary>
	/// Реализация класса <see href="IWayPointsLoader"/>.
	/// </summary>
	[BizClass(typeof(IWayPointsLoader))]
	public abstract class WayPointsLoader : PersistedObjectBase, IWayPointsLoader
	{
		#region Class Methods
		/// <summary>
		/// Сохранить данные
		/// </summary>
		[Transactional]
		public virtual System.Data.DataTable SaveData(System.Data.DataTable data)
		{
			return ProcessData(data, (row, wayPoint) => string.Empty, (row, wayPoint) => 
			{
				wayPoint = (IWayPoint)Manager.Get(((IIdentifiableObject)wayPoint).Id);
				wayPoint.Mnemo = row[WayPointsFields.Mnemo].ToString();
				wayPoint.Name = row[WayPointsFields.Name].ToString();
				return "Изменен";
			}, (row, wayPointNull) => 
			{
				var wayPoint = Manager.CreateNew<IWayPoint>();
				wayPoint.Mnemo = row[WayPointsFields.Mnemo].ToString();
				wayPoint.Name = row[WayPointsFields.Name].ToString();
				wayPoint.ExtId = new System.Guid(row[WayPointsFields.ExtId].ToString());
				return "Добавлен";
			});
		}
		/// <summary>
		/// Проверить данные
		/// </summary>
		[Transactional]
		public virtual System.Data.DataTable CheckData(System.Data.DataTable data)
		{
			return ProcessData(data, (row, wayPoint) => string.Empty, (row, wayPoint) => "Изменен", (row, wayPoint) => "Отсутствует");
		}
		#endregion
		#region Приватное
		private IDictionary<GUID, IWayPoint> FindWayPoints(ICollection<GUID> extIds)
		{
			var dict = new Dictionary<GUID, IWayPoint>();
			if (extIds.Count == 0)
				return dict;
			var sql = new StringBuilder();
			var sqlDecalare = new StringBuilder();
			var sqlSelect = new StringBuilder();
			var sqlWhere = new StringBuilder();
			var paramtersNames = new string[extIds.Count];
			for (var i = 0; i < extIds.Count; i++)
			{
				paramtersNames[i] = string.Format("P{0}", i);
			}
			sql.Append("DECLARE @");
			sql.Append(string.Join(string.Format(" AS [{0}];{1}DECLARE @", typeof(GUID).FullName, Environment.NewLine), paramtersNames));
			sql.AppendFormat(" AS [{0}];", typeof(GUID).FullName);
			sql.AppendLine();
			sql.AppendFormat("SELECT Identity FROM [{0}]", Manager.Model.GetClass(typeof(IWayPoint)).Name);
			sql.AppendLine();
			sql.Append("WHERE ExtId IN (@");
			sql.Append(string.Join(", @", paramtersNames));
			sql.Append(");");
			var query = Manager.CompileQuery(sql.ToString());
			int n = 0;
			foreach (var extId in extIds)
			{
				query.Parameters[paramtersNames[n++]].Value = extId;
			}
			var selList = query.Execute();
			foreach (IIdentifiableObject item in selList)
			{
				var wayPoint = (IWayPoint)item;
				if (dict.ContainsKey(wayPoint.ExtId))
				{
					var message = new StringBuilder();
					var mnemo1 = dict[wayPoint.ExtId].Mnemo;
					var mnemo2 = wayPoint.Mnemo;
					var extId = wayPoint.ExtId;
					message.AppendLine("Ошибка целостности данных. Найдено две записи в справочнике 'Пункты маршрута', ссылающиеся на один и тот же объект в классификаторе пунктов маршрута.");
					message.AppendFormat("Первая запись: Мнемокод = {0}", mnemo1 == null ? "<null>" : mnemo1.ToString());
					message.AppendLine();
					message.AppendFormat("Вторая запись: Мнемокод = {0}", mnemo2 == null ? "<null>" : mnemo2.ToString());
					message.AppendLine();
					message.AppendFormat("Идентификатор по классификатору = {0}", extId == null ? "<null>" : extId.ToString());
					throw new System.Data.ConstraintException(message.ToString());
				}
				dict.Add(wayPoint.ExtId, wayPoint);
			}
			return dict;
		}
		private IDictionary<GUID, IWayPoint> FindWayPoints(IEnumerable<GUID> extIds, int stepCount)
		{
			var dict = new Dictionary<GUID, IWayPoint>();
			var buffer = new List<GUID>();
			foreach (var extId in extIds)
			{
				buffer.Add(extId);
				if (buffer.Count >= stepCount)
				{
					Algorithms.ForEach(FindWayPoints(buffer), x => dict.Add(x.Key, x.Value));
					buffer.Clear();
				}
			}
			if (buffer.Count > 0)
			{
				Algorithms.ForEach(FindWayPoints(buffer), x => dict.Add(x.Key, x.Value));
			}
			return dict;
		}
		private delegate string ProcessDataDelegate(DataRow row, IWayPoint wayPoint);
		private System.Data.DataTable ProcessData(System.Data.DataTable data, ProcessDataDelegate whenEquals, ProcessDataDelegate whenDiff, ProcessDataDelegate whenAbsent)
		{
			var inputData = WayPointsLoaderHelper.CreateWayPoinsExtIdIndex(data);
			var wayPoints = FindWayPoints(inputData.Keys, 16);
			var outputData = new DataTable();
			outputData.Columns.Add(WayPointsFields.ExtId);
			outputData.Columns.Add(WayPointsFields.Status);
			foreach (var row in inputData.Values)
			{
				var outputRow = outputData.NewRow();
				outputData.Rows.Add(outputRow);
				outputRow[WayPointsFields.ExtId] = row[WayPointsFields.ExtId];
				IWayPoint wayPoint;
				if (wayPoints.TryGetValue(new GUID(row[WayPointsFields.ExtId].ToString()), out wayPoint))
				{
					if (row[WayPointsFields.Mnemo].ToString() == wayPoint.Mnemo && row[WayPointsFields.Name].ToString() == wayPoint.Name)
					{
						outputRow[WayPointsFields.Status] = whenEquals(row, wayPoint);
					}
					else
					{
						outputRow[WayPointsFields.Status] = whenDiff(row, wayPoint);
					}
				}
				else
				{
					outputRow[WayPointsFields.Status] = whenAbsent(row, wayPoint);
				}
			}
			return outputData;
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IWayPointsLoaderCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IWayPointsLoaderCreateArgs MyCreateArgs
		{
			get
			{
				return (IWayPointsLoaderCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract IWayPointsLoaderCreateArgs CreateArgs
		{
			get;
		}
	}
}
