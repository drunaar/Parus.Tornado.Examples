using System;
using System.Reflection;
using System.Runtime.Serialization;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.Date - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.Date.metadata")]
public partial class Date :
	Parus.Net.Server.Domains.DateTimeDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public Date()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public Date(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public Date(System.DateTime value) :
		base(value)
	{
	}

	/// <summary>
	/// Конструктор десериализации.
	/// </summary>
	protected Date(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(System.DateTime value)
	{
		return true;
	}

			
	/// <summary>
	/// Инициализирует экземпляр строковым представлением значения домена.
	/// </summary>
	public Date(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения System.DateTime к
	/// Date.
	/// </summary>
	public static implicit operator Date(
		System.DateTime v)
	{
		
		return new Date(v);
	}
	
	/// <summary>
	/// Оператор сложения даты и промежутка времени.
	/// </summary>
	public static Date operator +(
		Date d, TimeSpan t)
	{
		return new Date(d.Value + t);
	}
	
	/// <summary>
	/// Оператор вычитания из даты промежутка времени.
	/// </summary>
	public static Date operator -(
		Date d, TimeSpan t)
	{
		return new Date(d.Value - t);
	}
		
	#endregion
}
}