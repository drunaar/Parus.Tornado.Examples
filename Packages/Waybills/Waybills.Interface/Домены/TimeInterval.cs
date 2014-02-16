using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.TimeInterval - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.TimeInterval.metadata")]
public partial class TimeInterval :
	Parus.Net.Server.Domains.TimeSpanDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public TimeInterval()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public TimeInterval(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public TimeInterval(System.TimeSpan value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(System.TimeSpan value)
	{
		return true;
	}

			
	/// <summary>
	/// Инициализирует экземпляр строковым представлением значения домена.
	/// </summary>
	public TimeInterval(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения System.TimeSpan к
	/// TimeInterval.
	/// </summary>
	public static implicit operator TimeInterval(
		System.TimeSpan v)
	{
		
		return new TimeInterval(v);
	}
	
	/// <summary>
	/// Бинарный оператор +.
	/// </summary>
	public static TimeInterval operator +(
		TimeInterval p1, TimeInterval p2)
	{
		return new TimeInterval(p1.Value + p2.Value);
	}
	
	/// <summary>
	/// Бинарный оператор -.
	/// </summary>
	public static TimeInterval operator -(
		TimeInterval p1, TimeInterval p2)
	{
		return new TimeInterval(p1.Value - p2.Value);
	}
	
	#endregion
}
}