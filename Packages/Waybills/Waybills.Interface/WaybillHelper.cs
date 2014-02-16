using System.Collections.Generic;
using Parus.Common;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Помошник для работы с точками остановок.
	/// </summary>
	public static class OrderedCollectionHelper
	{
		/// <summary>
		/// Извлекатель номера из объекта.
		/// </summary>
		/// <typeparam name="T">Тип объекта.</typeparam>
		/// <param name="obj">Объект.</param>
		/// <returns>Номер.</returns>
		public delegate decimal NumberGetter<T>(T obj);
		
		/// <summary>
		/// Установщик номера в объекте.
		/// </summary>
		/// <typeparam name="T">Тип объекта.</typeparam>
		/// <param name="obj">Объект.</param>
		/// <param name="value">Номер.</param>
		public delegate void NumberSetter<T>(T obj, decimal value);


		/// <summary>
		/// Получить отсортированный список по номерам.
		/// </summary>
		/// <typeparam name="T">Тип элементов коллекции.</typeparam>
		/// <param name="collection">Коллекция объектов.</param>
		/// <param name="getter">Извлекатель номера.</param>
		/// <returns>Отсортированная коллекция.</returns>
		public static ICollection<T> SortByNumber<T>(
			this System.Collections.ICollection collection,
			NumberGetter<T> getter
			)
		{
			var list = new List<T>();
			foreach (T item in collection) list.Add(item);
			Algorithms.SortInPlace(list, (x, y) => getter(x) < getter(y) ? -1 : getter(x) > getter(y) ? 1 : 0);
			return list;
		}

		/// <summary>
		/// Перенумеровать список в возрастающем порядке начиная с единицы.
		/// </summary>
		/// <typeparam name="T">Тип элементов коллекции.</typeparam>
		/// <param name="collection">Коллекция объектов.</param>
		/// <param name="getter">Извлекатель номера.</param>
		/// <param name="setter">Установщик номера.</param>
		/// <returns>Колличество измененных объектов.</returns>
		public static int ReorderByNumber<T>(
			this System.Collections.ICollection collection,
			NumberGetter<T> getter,
			NumberSetter<T> setter
			)
		{
			if (collection.Count == 0) return 0;
			var list = collection.SortByNumber(getter);
			decimal index = 0;
			var count = 0;
			Algorithms.ForEach(list, x =>
				{
					++index;
					if (getter(x) != index)
					{
						setter(x, index);
						count++;
					}
				});
			return count;
		}

		/// <summary>
		/// Проверить правильность нумерации объектов в коллекции.
		/// </summary>
		/// <typeparam name="T">Тип элементов коллекции.</typeparam>
		/// <param name="collection">Коллекция объектов.</param>
		/// <param name="getter">Извлекатель номера.</param>
		/// <returns>true - правильно, false - не правильно</returns>
		public static bool IsOrderedByNumber<T>(
			this System.Collections.ICollection collection,
			NumberGetter<T> getter
			)
		{
			if (collection.Count == 0) return true;
			var list = collection.SortByNumber(getter);
			decimal index = 0;
			return Algorithms.FindWhere(list, x => getter(x) != ++index) == null;
		}

		/// <summary>
		/// Изменить порядок элемента в коллекции
		/// </summary>
		/// <typeparam name="T">Тип элементов коллекции.</typeparam>
		/// <param name="collection">Коллекция объектов.</param>
		/// <param name="getter">Извлекатель номера.</param>
		/// <param name="setter">Установщик номера.</param>
		/// <param name="itemInCollection">Изменяемый элемент.</param>
		/// <param name="position">Новый номер позиции в коллекции.</param>
		public static void ChangeItemOrder<T>(
			this System.Collections.ICollection collection,
			NumberGetter<T> getter,
			NumberSetter<T> setter,
			T itemInCollection,
			decimal position
			)
		{
			var oldPosition = getter(itemInCollection);
			if (position < 1) position = 1;
			else if (position > collection.Count) position = collection.Count;
			if (oldPosition != position)
			{
				if (oldPosition < position)
				{
					foreach (T item in collection)
					{
						var p = getter(item);
						if (p > oldPosition && p <= position)
							setter(item, p - 1);
					}
				}
				else
				{
					foreach (T item in collection)
					{
						var p = getter(item);
						if (p >= position && p < oldPosition)
							setter(item, p + 1);
					}
				}
				setter(itemInCollection, position);
			}
		}

		/// <summary>
		/// Перенумеровать список в возрастающем порядке начиная с единицы.
		/// </summary>
		/// <typeparam name="T">Тип элементов коллекции.</typeparam>
		/// <param name="collection">Коллекция объектов.</param>
		/// <param name="getter">Извлекатель номера.</param>
		/// <param name="setter">Установщик номера.</param>
		/// <param name="itemInCollection"></param>
		/// <returns>Колличество измененных объектов.</returns>
		public static int FixItemOrder<T>(
			this System.Collections.ICollection collection,
			NumberGetter<T> getter,
			NumberSetter<T> setter,
			T itemInCollection
			)
		{
			if (collection.Count == 0) return 0;
			var count = 0;
			var position = getter(itemInCollection);
			if (position < 1) position = 1;
			else if (position > collection.Count) position = collection.Count;
			if (getter(itemInCollection) != position)
			{
				setter(itemInCollection, position);
				count++;
			}
			var list = collection.SortByNumber(getter);
			decimal index = 1;
			Algorithms.ForEach(list, x =>
				{
					if (index == position) ++index;
					if (!ReferenceEquals(x, itemInCollection))
					{
						if (getter(x) != index)
						{
							setter(x, index);
							count++;
						}
						++index;
					}
				});
			return count;
		}
	}
}
