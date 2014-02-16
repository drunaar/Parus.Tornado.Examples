// GENERATED FILE DO NOT MODIFY

using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	public partial class TransportUnit : UnitBase
	{
		/// <summary>
		/// Все точки раздела <seealso cref="TransportUnit"/>
		/// </summary>
		public static class Points
		{
			/// <summary>
			/// Конечная точка
			/// </summary>
			public const string Edit_Cancel_End = "Edit.Cancel.End";
			/// <summary>
			/// Конечная точка
			/// </summary>
			public const string Edit_Ok_End = "Edit.Ok.End";
			/// <summary>
			/// Удалить
			/// Конечная точка
			/// </summary>
			public const string Browse_Delete_End = "Browse.Delete.End";
			/// <summary>
			/// Транспортное средство
			/// Диалог изменения
			/// </summary>
			public const string Edit = "Edit";
			/// <summary>
			/// Транспортные средства
			/// Обозреватель
			/// </summary>
			public const string Browse = "Browse";
			/// <summary>
			/// Транспортные средства
			/// Стартовая точка раздела
			/// </summary>
			public const string Start = "Start";
			/// <summary>
			/// Данные
			/// </summary>
			public const string Data = "Data";
		}
		
		/// <summary>
		/// Все переходы <seealso cref="TransportUnit"/>
		/// </summary>
		public static class Transitions
		{
			/// <summary>
			/// Отмена изменений
			/// </summary>
			public const string Cancel_Edit = "Cancel@Edit";
			/// <summary>
			/// Подтверждение изменений
			/// </summary>
			public const string Ok_Edit = "Ok@Edit";
			/// <summary>
			/// Удалить
			/// Удалить ТС
			/// </summary>
			public const string Delete_Browse = "Delete@Browse";
			/// <summary>
			/// Размножить…
			/// Размножить ТС
			/// </summary>
			public const string Clone_Browse = "Clone@Browse";
			/// <summary>
			/// Изменить…
			/// Изменить ТС
			/// </summary>
			public const string Edit_Browse = "Edit@Browse";
			/// <summary>
			/// Добавить…
			/// Добавить ТС
			/// </summary>
			public const string Add_Browse = "Add@Browse";
			/// <summary>
			/// Инициализация
			/// </summary>
			public const string Initialize_Start = "Initialize@Start";
		}
	}
}
