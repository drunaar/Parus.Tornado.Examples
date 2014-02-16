// GENERATED FILE DO NOT MODIFY

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	public partial class ConveyanceDeedUnit
	{
		/// <summary>
		/// Все точки раздела <seealso cref="ConveyanceDeedUnit"/>
		/// </summary>
		public static class Points
		{
			/// <summary>
			/// Удалить акт передачи
			/// Удалить акт передачи
			/// </summary>
			public const string StartDelete = "StartDelete";
			/// <summary>
			/// Акт передачи груза
			/// Форма редактирования
			/// </summary>
			public const string Edit = "Edit";
			/// <summary>
			/// Создать/Изменить акт передачи груза
			/// Создать/Изменить акт передачи груза
			/// </summary>
			public const string StartEdit = "StartEdit";
		}
		
		/// <summary>
		/// Все переходы <seealso cref="ConveyanceDeedUnit"/>
		/// </summary>
		public static class Transitions
		{
			/// <summary>
			/// Удаление
			/// </summary>
			public const string Delete_StartDelete = "Delete@StartDelete";
			/// <summary>
			/// Отмена изменений
			/// </summary>
			public const string Cancel_Edit = "Cancel@Edit";
			/// <summary>
			/// Подтверждение изменений
			/// </summary>
			public const string Ok_Edit = "Ok@Edit";
			/// <summary>
			/// Изменение
			/// </summary>
			public const string Edit_StartEdit = "Edit@StartEdit";
		}
	}
}
