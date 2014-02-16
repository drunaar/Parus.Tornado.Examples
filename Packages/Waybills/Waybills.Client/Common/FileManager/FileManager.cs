using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.Common.FileManager.FileManager.unit")]
	public partial class FileManagerUnit : UnitBase
	{
		private const string MonitorSlot = "Slot.UploadMonitor";

		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public FileManagerUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}

		private void InitUploadEventHandler(IUnitExecutionContext context)
		{
			context[MonitorSlot] = context.GetCurrentObject();
		}

		private void Upload_TransitedEventHandler(IUnitExecutionContext context)
		{
			// Данное событие вызывается в асинхронном режиме (особенности ModificationFormTemplate).
			// Мы не можем послать сигнал тупо тому, кто запустил этот раздел, т.к. он
			// об асинхронности ничего не подозревает.
			// Чтобы послать сигнал в том же потоке, в котором вызывался данный раздел,
			// Подпишемся на событие closed у формы выбора файла. Это событие будет вызвано
			// не асинхронно.
			context.GetCurrentWindowHost().Top.Form.Closed += (x, y) =>
				{
					var monitor = context[MonitorSlot] as UploadMonitor;
					if (monitor != null)
					{
						// Сигнализируем о том, что файл выбран.
						monitor.PulseAll(context.GetCurrentObject() as string);
					}
				};
		}
	}
}
