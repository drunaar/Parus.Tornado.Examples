namespace Acme.Business.Waybills
{
	/// <summary>
	/// Монитор выбора файла.
	/// </summary>
	public class UploadMonitor : IUploadMonitor
	{
		/// <summary>
		/// Событие выбора файла.
		/// </summary>
		public event UploadEventHandler Upload;

		/// <summary>
		/// Конструткор.
		/// </summary>
		public UploadMonitor()
		{}

		/// <summary>
		/// Конструктор с инициализацией события.
		/// </summary>
		/// <param name="handler">Обработчик события выбора файла.</param>
		public UploadMonitor(UploadEventHandler handler)
			: this()
		{
			Upload += handler;
		}

		/// <summary>
		/// Послать всем подписавшимся сигнал о том, что файл выбран.
		/// </summary>
		/// <param name="fileName">Имя выбранного файла.</param>
		public void PulseAll(string fileName)
		{
			UploadEventHandler handler = Upload;
			if (handler != null) handler(this, fileName);
		}
	}
}
