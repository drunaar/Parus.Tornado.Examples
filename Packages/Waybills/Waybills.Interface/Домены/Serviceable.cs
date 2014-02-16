using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.Serviceable - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.Serviceable.metadata")]
public partial class Serviceable :
	Parus.Net.Server.Domains.BooleanDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public Serviceable()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public Serviceable(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public Serviceable(bool value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(bool value)
	{
		return true;
	}

			
	/// <summary>
	/// Инициализирует экземпляр строковым представлением значения домена.
	/// </summary>
	public Serviceable(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения bool к
	/// Serviceable.
	/// </summary>
	public static implicit operator Serviceable(
		bool v)
	{
		
		return new Serviceable(v);
	}
	
	#endregion
}
}