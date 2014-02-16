using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.Name - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.Name.metadata")]
public partial class Name :
	Parus.Net.Server.Domains.StringDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public Name()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public Name(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public Name(string value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(string value)
	{
		return value.Length <= 255;
				
	}

			
	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения string к
	/// Name.
	/// </summary>
	public static implicit operator Name(
		string v)
	{
		
		if (v == null)
			return null;
		
		return new Name(v);
	}
	
	/// <summary>
	/// Бинарный оператор +.
	/// </summary>
	public static Name operator +(
		Name p1, Name p2)
	{
		return new Name(p1.Value + p2.Value);
	}
	
	#endregion
}
}