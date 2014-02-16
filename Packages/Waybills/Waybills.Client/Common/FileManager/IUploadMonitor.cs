namespace Acme.Business.Waybills
{
	/// <summary>
	/// Делегат события выбора файла.
	/// </summary>
	/// <param name="sender">Монитор загрузки.</param>
	/// <param name="fileName">Имя выбранного файла.</param>
	public delegate void UploadEventHandler(IUploadMonitor sender, string fileName);

	/// <summary>
	/// Интерфейс монитора выбора файла.
	/// </summary>
	public interface IUploadMonitor
	{
		/// <summary>
		/// Событие выбора файла.
		/// </summary>
		event UploadEventHandler Upload;
	}
}
