using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.Mnemo - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.Mnemo.metadata")]
public partial class Mnemo :
	Parus.Net.Server.Domains.StringDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public Mnemo()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public Mnemo(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public Mnemo(string value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(string value)
	{
		return value.Length <= 50;
				
	}

			
	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения string к
	/// Mnemo.
	/// </summary>
	public static implicit operator Mnemo(
		string v)
	{
		
		if (v == null)
			return null;
		
		return new Mnemo(v);
	}
	
	/// <summary>
	/// Бинарный оператор +.
	/// </summary>
	public static Mnemo operator +(
		Mnemo p1, Mnemo p2)
	{
		return new Mnemo(p1.Value + p2.Value);
	}
	
	#endregion
}
}