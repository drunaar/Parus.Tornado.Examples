using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.WayPointNumber - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.WayPointNumber.metadata")]
public partial class WayPointNumber :
	Parus.Net.Server.Domains.DecimalDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public WayPointNumber()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public WayPointNumber(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public WayPointNumber(decimal value) :
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
	public WayPointNumber(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения decimal к
	/// WayPointNumber.
	/// </summary>
	public static implicit operator WayPointNumber(
		decimal v)
	{
		
		return new WayPointNumber(v);
	}
	
	/// <summary>
	/// Бинарный оператор +.
	/// </summary>
	public static WayPointNumber operator +(
		WayPointNumber p1, WayPointNumber p2)
	{
		return new WayPointNumber(p1.Value + p2.Value);
	}
	
	/// <summary>
	/// Унарный оператор декремента.
	/// </summary>
	public static WayPointNumber operator --(
		WayPointNumber p)
	{
		return new WayPointNumber(p.Value - 1);
	}
	
	/// <summary>
	/// Бинарный оператор /.
	/// </summary>
	public static WayPointNumber operator /(
		WayPointNumber p1, WayPointNumber p2)
	{
		return new WayPointNumber(p1.Value / p2.Value);
	}
	
	/// <summary>
	/// Унарный оператор инкремента.
	/// </summary>
	public static WayPointNumber operator ++(
		WayPointNumber p)
	{
		return new WayPointNumber(p.Value + 1);
	}
	
	/// <summary>
	/// Бинарный оператор %.
	/// </summary>
	public static WayPointNumber operator %(
		WayPointNumber p1, WayPointNumber p2)
	{
		return new WayPointNumber(p1.Value % p2.Value);
	}
	
	/// <summary>
	/// Бинарный оператор *.
	/// </summary>
	public static WayPointNumber operator *(
		WayPointNumber p1, WayPointNumber p2)
	{
		return new WayPointNumber(p1.Value * p2.Value);
	}
	
	/// <summary>
	/// Бинарный оператор -.
	/// </summary>
	public static WayPointNumber operator -(
		WayPointNumber p1, WayPointNumber p2)
	{
		return new WayPointNumber(p1.Value - p2.Value);
	}
	
	/// <summary>
	/// Оператор явного приведения byte к
	/// WayPointNumber.
	/// </summary>
	public static explicit operator WayPointNumber(byte v)
	{
		
		return new WayPointNumber((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения int к
	/// WayPointNumber.
	/// </summary>
	public static explicit operator WayPointNumber(int v)
	{
		
		return new WayPointNumber((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения long к
	/// WayPointNumber.
	/// </summary>
	public static explicit operator WayPointNumber(long v)
	{
		
		return new WayPointNumber((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения float к
	/// WayPointNumber.
	/// </summary>
	public static explicit operator WayPointNumber(float v)
	{
		
		return new WayPointNumber((decimal)v);
	}
	
	/// <summary>
	/// Оператор явного приведения double к
	/// WayPointNumber.
	/// </summary>
	public static explicit operator WayPointNumber(double v)
	{
		
		return new WayPointNumber((decimal)v);
	}
	
	#endregion
}
}