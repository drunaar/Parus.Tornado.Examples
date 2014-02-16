// GENERATED FILE DO NOT MODIFY

using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills.HazardousCargoWaybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	public partial class HazardousCargoWaybillUnit : UnitBase
	{
		/// <summary>
		/// Все точки раздела <seealso cref="HazardousCargoWaybillUnit"/>
		/// </summary>
		public static class Points
		{
			/// <summary>
			/// Удалить
			/// Конечная точка
			/// </summary>
			public const string EditWaybill_DeleteBreakPoint_End = "EditWaybill.DeleteBreakPoint.End";
			/// <summary>
			/// Конечная точка
			/// </summary>
			public const string EditBreakPoint_Cancel_End = "EditBreakPoint.Cancel.End";
			/// <summary>
			/// Конечная точка
			/// </summary>
			public const string EditBreakPoint_Ok_End = "EditBreakPoint.Ok.End";
			/// <summary>
			/// Удалить
			/// Конечная точка
			/// </summary>
			public const string Browse_DeleteBreakPoint_End = "Browse.DeleteBreakPoint.End";
			/// <summary>
			/// Точка маршрута для опасных грузов
			/// Диалог изменения точки остановки
			/// </summary>
			public const string EditBreakPoint = "EditBreakPoint";
			/// <summary>
			/// Конечная точка
			/// </summary>
			public const string EditWaybill_Cancel_End = "EditWaybill.Cancel.End";
			/// <summary>
			/// Конечная точка
			/// </summary>
			public const string EditWaybill_Ok_End = "EditWaybill.Ok.End";
			/// <summary>
			/// Удалить
			/// Конечная точка
			/// </summary>
			public const string Browse_DeleteWaybill_End = "Browse.DeleteWaybill.End";
			/// <summary>
			/// Путевой лист для опасных грузов
			/// Диалог изменения путевого листа
			/// </summary>
			public const string EditWaybill = "EditWaybill";
			/// <summary>
			/// Путевые листы для опасных грузов
			/// Обозреватель
			/// </summary>
			public const string Browse = "Browse";
			/// <summary>
			/// Путевые листы для опасных грузов
			/// Стартовая точка раздела
			/// </summary>
			public const string Start = "Start";
			/// <summary>
			/// Данные точек остановок
			/// </summary>
			public const string BreakPoint_Data = "BreakPoint_Data";
			/// <summary>
			/// Данные путевых листов
			/// </summary>
			public const string Waybill_Data = "Waybill_Data";
		}
		
		/// <summary>
		/// Все переходы <seealso cref="HazardousCargoWaybillUnit"/>
		/// </summary>
		public static class Transitions
		{
			/// <summary>
			/// Отмена изменений точки остановки
			/// </summary>
			public const string Cancel_EditBreakPoint = "Cancel@EditBreakPoint";
			/// <summary>
			/// Подтверждение изменений точки остановки
			/// </summary>
			public const string Ok_EditBreakPoint = "Ok@EditBreakPoint";
			/// <summary>
			/// Размножить…
			/// Размножить точку остановки
			/// </summary>
			public const string CloneBreakPoint_EditWaybill = "CloneBreakPoint@EditWaybill";
			/// <summary>
			/// Изменить…
			/// Изменить точку остановки
			/// </summary>
			public const string EditBreakPoint_EditWaybill = "EditBreakPoint@EditWaybill";
			/// <summary>
			/// Добавить…
			/// Добавить точку остановки
			/// </summary>
			public const string AddBreakPoint_EditWaybill = "AddBreakPoint@EditWaybill";
			/// <summary>
			/// Удалить
			/// Удалить точку остановки
			/// </summary>
			public const string DeleteBreakPoint_EditWaybill = "DeleteBreakPoint@EditWaybill";
			/// <summary>
			/// Отмена изменений путевого листа
			/// </summary>
			public const string Cancel_EditWaybill = "Cancel@EditWaybill";
			/// <summary>
			/// Подтверждение изменений путевого листа
			/// </summary>
			public const string Ok_EditWaybill = "Ok@EditWaybill";
			/// <summary>
			/// Удалить
			/// Удалить точку остановки
			/// </summary>
			public const string DeleteBreakPoint_Browse = "DeleteBreakPoint@Browse";
			/// <summary>
			/// Размножить…
			/// Размножить точку остановки
			/// </summary>
			public const string CloneBreakPoint_Browse = "CloneBreakPoint@Browse";
			/// <summary>
			/// Изменить…
			/// Изменить точку остановки
			/// </summary>
			public const string EditBreakPoint_Browse = "EditBreakPoint@Browse";
			/// <summary>
			/// Добавить…
			/// Добавить точку остановки
			/// </summary>
			public const string AddBreakPoint_Browse = "AddBreakPoint@Browse";
			/// <summary>
			/// Удалить
			/// Удалить путевой лист
			/// </summary>
			public const string DeleteWaybill_Browse = "DeleteWaybill@Browse";
			/// <summary>
			/// Размножить…
			/// Размножить путевой лист
			/// </summary>
			public const string CloneWaybill_Browse = "CloneWaybill@Browse";
			/// <summary>
			/// Изменить…
			/// Изменить путевой лист
			/// </summary>
			public const string EditWaybill_Browse = "EditWaybill@Browse";
			/// <summary>
			/// Добавить…
			/// Добавить путевой лист
			/// </summary>
			public const string AddWaybill_Browse = "AddWaybill@Browse";
			/// <summary>
			/// Инициализация
			/// </summary>
			public const string Initialize_Start = "Initialize@Start";
		}
	}
}
