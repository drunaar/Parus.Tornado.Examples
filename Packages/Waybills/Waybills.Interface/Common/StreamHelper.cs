using System.IO;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Расширения для работы с потоками.
	/// </summary>
	public static class StreamHelper
	{
		/// <summary>
		/// Размер по умолчанию промежуточного буфера при копировании потоков.
		/// </summary>
		public const int TemporaryBufferSize = 16384;

		/// <summary>
		/// Копирует байты из источника в приемник,
		/// используя промежуточный буфер указанного размера.
		/// </summary>
		/// <param name="inputStream">Источник.</param>
		/// <param name="outputStream">Приемник.</param>
		/// <param name="size">Количество копируемых байт.</param>
		/// <param name="bufferSize">Размер промежуточного буфера для копирования.</param>
		/// <returns>Количество скопированных байт.</returns>
		public static long Copy(this Stream inputStream, Stream outputStream, long size, int bufferSize)
		{
			var buffer = new byte[bufferSize];
			var left = size;
			while (left > 0)
			{
				var stepSize = left > bufferSize ? bufferSize : (int)left;
				var bytesRead = inputStream.Read(buffer, 0, stepSize);
				if (bytesRead == 0) break;
				outputStream.Write(buffer, 0, bytesRead);
				left -= bytesRead;
			}
			return size - left;
		}

		/// <summary>
		/// Копирует байты из источника в приемник.
		/// Константа <see cref="StreamHelper.TemporaryBufferSize"/> определяет размер промежуточного буфера при копировании.
		/// </summary>
		/// <param name="inputStream">Источник.</param>
		/// <param name="outputStream">Приемник.</param>
		/// <param name="size">Количество копируемых байт.</param>
		/// <returns>Количество скопированных байт.</returns>
		public static long Copy(this Stream inputStream, Stream outputStream, long size)
		{
			return inputStream.Copy(outputStream, size, TemporaryBufferSize);
		}

		/// <summary>
		/// Максимальный размер временного потока  
		/// </summary>
		public const int MaxMemoryTemporaryStream = 65536;

		/// <summary>
		/// Создает временный поток копируя в него часть текущего потока указанного размера
		/// начиная с определенной позиции.
		/// Временный поток создается либо в памяти (MemoryStream), либо в файле (FileStream).
		/// В памяти поток создается, если размер временного потока (количество копируемых байт)
		/// не превышает значение константы <see cref="StreamHelper.MaxMemoryTemporaryStream"/>.
		/// Если поток создается в файле, то при закрытии потока файл автоматически удаляется.
		/// </summary>
		/// <param name="inputStream">Источник.</param>
		/// <param name="offset">Смещение от начала потока.</param>
		/// <param name="size">Количество копируемых байт.</param>
		/// <returns>Временный поток.</returns>
		public static Stream CreateTemporaryCopy(this Stream inputStream, long offset, long size)
		{
			Stream outputStream = size < MaxMemoryTemporaryStream
				? (Stream)new MemoryStream((int)size)
				: new FileStream(Path.GetTempFileName(), FileMode.Open, FileAccess.ReadWrite, FileShare.Delete);
			var oldposition = inputStream.Position;
			inputStream.Position = offset;
			inputStream.Copy(outputStream, size);
			inputStream.Position = oldposition;
			outputStream.Position = 0;
			return outputStream;
		}

		/// <summary>
		/// Создает временный поток с точной копией текущего потока.
		/// Временный поток создается либо в памяти (MemoryStream), либо в файле (FileStream).
		/// В памяти поток создается, если размер потока
		/// не превышает значение константы <see cref="StreamHelper.MaxMemoryTemporaryStream"/>.
		/// Если поток создается в файле, то при закрытии потока файл автоматически удаляется.
		/// </summary>
		/// <param name="inputStream">Источник.</param>
		/// <returns>Временный поток.</returns>
		public static Stream CreateTemporaryCopy(this Stream inputStream)
		{
			return inputStream.CreateTemporaryCopy(0, inputStream.Length);
		}
	}
}
