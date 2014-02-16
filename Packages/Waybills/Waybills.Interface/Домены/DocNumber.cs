using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.DocNumber - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.DocNumber.metadata")]
public partial class DocNumber :
	Parus.Net.Server.Domains.StringDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public DocNumber()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public DocNumber(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public DocNumber(string value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(string value)
	{
		return value.Length <= 20;
				
	}

			
	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения string к
	/// DocNumber.
	/// </summary>
	public static implicit operator DocNumber(
		string v)
	{
		
		if (v == null)
			return null;
		
		return new DocNumber(v);
	}
	
	/// <summary>
	/// Бинарный оператор +.
	/// </summary>
	public static DocNumber operator +(
		DocNumber p1, DocNumber p2)
	{
		return new DocNumber(p1.Value + p2.Value);
	}
	
	#endregion
}
}