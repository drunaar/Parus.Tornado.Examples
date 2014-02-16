// GENERATED FILE DO NOT MODIFY

using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	public partial class WayPointUnit : UnitBase
	{
		/// <summary>
		/// Все точки раздела <seealso cref="WayPointUnit"/>
		/// </summary>
		public static class Points
		{
			/// <summary>
			/// Выбор режима проссмотра
			/// </summary>
			public const string EditView = "EditView";
			/// <summary>
			/// Пункт маршрута (только проссмотр)
			/// Диалог проссмотра
			/// </summary>
			public const string View = "View";
			/// <summary>
			/// Пункт маршрута
			/// Диалог редактирования
			/// </summary>
			public const string Edit = "Edit";
			/// <summary>
			/// Пункты маршрута
			/// Брауз форма
			/// </summary>
			public const string Browse = "Browse";
			/// <summary>
			/// Пункты маршрута
			/// Стартовая точка раздела
			/// </summary>
			public const string Start = "Start";
			/// <summary>
			/// Данные
			/// </summary>
			public const string Data = "Data";
		}
		
		/// <summary>
		/// Все переходы <seealso cref="WayPointUnit"/>
		/// </summary>
		public static class Transitions
		{
			/// <summary>
			/// Закрытие формы
			/// </summary>
			public const string Close = "Close";
			/// <summary>
			/// Проссмотр…
			/// Проссмотр
			/// </summary>
			public const string View_EditView = "View@EditView";
			/// <summary>
			/// Изменить…
			/// Изменить
			/// </summary>
			public const string Edit_EditView = "Edit@EditView";
			/// <summary>
			/// Изменить…
			/// Изменить/проссмотр
			/// </summary>
			public const string EditView_Browse = "EditView@Browse";
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
			/// Удалить
			/// </summary>
			public const string Delete_Browse = "Delete@Browse";
			/// <summary>
			/// Размножить…
			/// Размножить
			/// </summary>
			public const string Clone_Browse = "Clone@Browse";
			/// <summary>
			/// Добавить…
			/// Добавить
			/// </summary>
			public const string Add_Browse = "Add@Browse";
			/// <summary>
			/// Инициализация
			/// </summary>
			public const string Initialize_Start = "Initialize@Start";
		}
	}
}
