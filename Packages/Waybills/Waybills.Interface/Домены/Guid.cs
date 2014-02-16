using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.GUID - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.Guid.metadata")]
public partial class GUID :
	Parus.Net.Server.Domains.GuidDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public GUID()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public GUID(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public GUID(System.Guid value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(System.Guid value)
	{
		return true;
	}

			
	/// <summary>
	/// Инициализирует экземпляр строковым представлением значения домена.
	/// </summary>
	public GUID(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения System.Guid к
	/// GUID.
	/// </summary>
	public static implicit operator GUID(
		System.Guid v)
	{
		
		return new GUID(v);
	}
	
	#endregion
}
}