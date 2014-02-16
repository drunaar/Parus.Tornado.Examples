// GENERATED FILE DO NOT MODIFY

using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	public partial class FileManagerUnit : UnitBase
	{
		/// <summary>
		/// Все точки раздела <seealso cref="FileManagerUnit"/>
		/// </summary>
		public static class Points
		{
			/// <summary>
			/// Выгрузка файла
			/// Диалог выгрузки файлов
			/// </summary>
			public const string DownloadForm = "DownloadForm";
			/// <summary>
			/// Выгрузка файлов
			/// Стартовая точка выгрузки файлов.
			/// </summary>
			public const string Download = "Download";
			/// <summary>
			/// Загрузка файла
			/// Диалог выбора файла для загрузки
			/// </summary>
			public const string UploadForm = "UploadForm";
			/// <summary>
			/// Загрузка файла
			/// Стартовая точка загрузки файла.
			/// </summary>
			public const string Upload = "Upload";
		}
		
		/// <summary>
		/// Все переходы <seealso cref="FileManagerUnit"/>
		/// </summary>
		public static class Transitions
		{
			/// <summary>
			/// Закрытие формы
			/// </summary>
			public const string Close = "Close";
			/// <summary>
			/// Инициализация загрузки файла
			/// </summary>
			public const string Init_Upload = "Init@Upload";
			/// <summary>
			/// Инициализация выгрузки файлов
			/// </summary>
			public const string Init_Download = "Init@Download";
			/// <summary>
			/// Unit Transition 2
			/// Отмена выбора файла
			/// </summary>
			public const string Cancel_UploadForm = "Cancel@UploadForm";
			/// <summary>
			/// Unit Transition 1
			/// Файл выбран
			/// </summary>
			public const string Ok_UploadForm = "Ok@UploadForm";
		}
	}
}
