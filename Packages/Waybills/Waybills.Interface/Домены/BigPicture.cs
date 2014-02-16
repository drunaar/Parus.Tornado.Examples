using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills
{

/// <summary>
/// Домен Acme.Business.Waybills.BigPicture - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.Домены.BigPicture.metadata")]
public partial class BigPicture :
	Parus.Net.Server.Domains.StreamDomain
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public BigPicture()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public BigPicture(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public BigPicture(Parus.Net.Server.Domains.StreamDescriptor value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(Parus.Net.Server.Domains.StreamDescriptor value)
	{
		return true;
	}

			
	/// <summary>
	/// Инициализирует экземпляр строковым представлением значения домена.
	/// </summary>
	public BigPicture(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения Parus.Net.Server.Domains.StreamDescriptor к
	/// BigPicture.
	/// </summary>
	public static implicit operator BigPicture(
		Parus.Net.Server.Domains.StreamDescriptor v)
	{
		
		return new BigPicture(v);
	}
	
	#endregion
}
}