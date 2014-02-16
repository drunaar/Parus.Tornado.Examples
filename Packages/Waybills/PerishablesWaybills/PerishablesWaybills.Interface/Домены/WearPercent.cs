using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills.PerishablesWaybills
{

/// <summary>
/// Домен Acme.Business.Waybills.PerishablesWaybills.WearPercent - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.PerishablesWaybills.Домены.WearPercent.metadata")]
public partial class WearPercent :
	Parus.Net.Server.Domains.DecimalDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public WearPercent()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public WearPercent(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public WearPercent(decimal value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(decimal value)
	{
		return true;
	}

			
	/// <summary>
	/// Инициализирует экземпляр строковым представлением значения домена.
	/// </summary>
	public WearPercent(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения decimal к
	/// WearPercent.
	/// </summary>
	public static implicit operator WearPercent(
		decimal v)
	{
		
		return new WearPercent(v);
	}
	
	/// <summary>
	/// Бинарный оператор +.
	/// </summary>
	public static WearPercent operator +(
		WearPercent p1, WearPercent p2)
	{
		return new WearPercent(p1.Value + p2.Value);
	}
	
	/// <summary>
	/// Унарный оператор декремента.
	/// </summary>
	public static WearPercent operator --(
		WearPercent p)
	{
		return new WearPercent(p.Value - 1);
	}
	
	/// <summary>
	/// Бинарный оператор /.
	/// </summary>
	public static WearPercent operator /(
		WearPercent p1, WearPercent p2)
	{
		return new WearPercent(p1.Value / p2.Value);
	}
	
	/// <summary>
	/// Унарный оператор инкремента.
	/// </summary>
	public static WearPercent operator ++(
		WearPercent p)
	{
		return new WearPercent(p.Value + 1);
	}
	
	/// <summary>
	/// Бинарный оператор %.
	/// </summary>
	public static WearPercent operator %(
		WearPercent p1, WearPercent p2)
	{
		return new WearPercent(p1.Value % p2.Value);
	}
	
	/// <summary>
	/// Бинарный оператор *.
	/// </summary>
	public static WearPercent operator *(
		WearPercent p1, WearPercent p2)
	{
		return new WearPercent(p1.Value * p2.Value);
	}
	
	/// <summary>
	/// Бинарный оператор -.
	/// </summary>
	public static WearPercent operator -(
		WearPercent p1, WearPercent p2)
	{
		return new WearPercent(p1.Value - p2.Value);
	}
	
	/// <summary>
	/// Оператор явного приведения byte к
	/// WearPercent.
	/// </summary>
	public static explicit operator WearPercent(byte v)
	{
		
		return new WearPercent((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения int к
	/// WearPercent.
	/// </summary>
	public static explicit operator WearPercent(int v)
	{
		
		return new WearPercent((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения long к
	/// WearPercent.
	/// </summary>
	public static explicit operator WearPercent(long v)
	{
		
		return new WearPercent((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения float к
	/// WearPercent.
	/// </summary>
	public static explicit operator WearPercent(float v)
	{
		
		return new WearPercent((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения double к
	/// WearPercent.
	/// </summary>
	public static explicit operator WearPercent(double v)
	{
		
		return new WearPercent((decimal)v);
	}
	
	#endregion
}
}