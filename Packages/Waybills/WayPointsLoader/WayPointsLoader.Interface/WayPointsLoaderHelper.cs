using System.Collections.Generic;
using System.Data;

namespace Acme.Business.Waybills.WayPointsLoader
{
	/// <summary>
	/// Названия колонок в таблице пунктов маршрута
	/// </summary>
	public static class WayPointsFields
	{
		/// <summary>
		/// Мнемокод
		/// </summary>
		public const string Mnemo = "Mnemo";

		/// <summary>
		/// Наименование
		/// </summary>
		public const string Name = "Name";

		/// <summary>
		/// Идентификатор по классификатору
		/// </summary>
		public const string ExtId = "ExtId";

		/// <summary>
		/// Статус операции импорта/проверки
		/// </summary>
		public const string Status = "Status";

		/// <summary>
		/// Флаг использования записи для импорта
		/// </summary>
		public const string UseFlag = "UseFlag";
	}

	/// <summary>
	/// Названия колонок в xml-файла классификатора пунктов маршрута
	/// </summary>
	public static class WayPointsXmlFields
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public const string Id = "Id";

		/// <summary>
		/// Наименование
		/// </summary>
		public const string Name = "Name";

		/// <summary>
		/// Полное наименование
		/// </summary>
		public const string FullName = "FullName";
	}

	/// <summary>
	/// Помошник для работы с классификаторм пунктов маршрута
	/// </summary>
	public static class WayPointsLoaderHelper
	{

		/// <summary>
		/// Загрузить классификатор в таблицу данных.
		/// </summary>
		/// <param name="fileName">Имя xml-файла.</param>
		/// <returns>Таблица данных.</returns>
		public static DataTable LoadWayPoints(string fileName)
		{
			var dataSet = new DataSet();
			dataSet.ReadXml(fileName);

			var inputData = dataSet.Tables["WayPoint"];
			var outputData = new DataTable();
			outputData.Columns.Add(WayPointsFields.Mnemo);
			outputData.Columns.Add(WayPointsFields.Name);
			outputData.Columns.Add(WayPointsFields.ExtId);

			foreach (DataRow inputRow in inputData.Rows)
			{
				var outputRow = outputData.NewRow();
				outputData.Rows.Add(outputRow);
				outputRow[WayPointsFields.Mnemo] = inputRow[WayPointsXmlFields.Name].ToString().Trim();
				outputRow[WayPointsFields.Name] = inputRow[WayPointsXmlFields.FullName].ToString().Trim();
				outputRow[WayPointsFields.ExtId] = inputRow[WayPointsXmlFields.Id].ToString().Trim();
			}
			return outputData;
		}

        /// <summary>
		/// Проиндексировать таблицу пунктов маршрута.
		/// На выходе получается словарь (Dictionary), где
		/// ключом является идентификатор по классификатору (<see cref="WayPointsFields.ExtId"/>),
		/// а значением является строка таблицы (System.Data.DataRow).
		/// </summary>
		/// <param name="dataTable">Таблица пунктов маршрута.</param>
		/// <returns>Словарь.</returns>
		public static IDictionary<GUID, DataRow> CreateWayPoinsExtIdIndex(DataTable dataTable)
		{
			var dict = new Dictionary<GUID, DataRow>();
			foreach(DataRow row in dataTable.Rows)
			{
				dict.Add( new GUID(row[WayPointsFields.ExtId].ToString()), row);
			}
			return dict;
		}
	}
}
