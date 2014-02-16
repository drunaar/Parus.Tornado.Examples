// GENERATED FILE DO NOT MODIFY

using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills.WayPointsLoader
{
	/// <summary>
	/// Раздел
	/// </summary>
	public partial class WayPointsLoaderUnit : UnitBase
	{
		/// <summary>
		/// Все точки раздела <seealso cref="WayPointsLoaderUnit"/>
		/// </summary>
		public static class Points
		{
			/// <summary>
			/// Загрузчик пунктов маршрута
			/// Диалог загрузки пунктов маршрута
			/// </summary>
			public const string Loader = "Loader";
			/// <summary>
			/// Загрузчик пунктов маршрута
			/// Стартовая точка
			/// </summary>
			public const string Start = "Start";
		}
		
		/// <summary>
		/// Все переходы <seealso cref="WayPointsLoaderUnit"/>
		/// </summary>
		public static class Transitions
		{
			/// <summary>
			/// Закрытие формы
			/// </summary>
			public const string Close = "Close";
			/// <summary>
			/// Сохранение
			/// </summary>
			public const string SaveData = "SaveData";
			/// <summary>
			/// Проверка
			/// </summary>
			public const string CheckData = "CheckData";
			/// <summary>
			/// Переход
			/// </summary>
			public const string UnitTransition = "UnitTransition";
		}
	}
}
