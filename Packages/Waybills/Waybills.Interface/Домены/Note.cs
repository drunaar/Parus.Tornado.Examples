using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.Note - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.Note.metadata")]
public partial class Note :
	Parus.Net.Server.Domains.StringDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public Note()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public Note(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public Note(string value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(string value)
	{
		return true;
	}

			
	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения string к
	/// Note.
	/// </summary>
	public static implicit operator Note(
		string v)
	{
		
		if (v == null)
			return null;
		
		return new Note(v);
	}
	
	/// <summary>
	/// Бинарный оператор +.
	/// </summary>
	public static Note operator +(
		Note p1, Note p2)
	{
		return new Note(p1.Value + p2.Value);
	}
	
	#endregion
}
}