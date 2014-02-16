using System;
using System.Reflection;

using Parus.Net.Server;


namespace Acme.Business.Waybills.HazardousCargoWaybills
{
/// <summary>
/// Перечисление, которое описывает тип домена HazardousType.
/// </summary>
public enum HazardousTypeEnum
{
	
		///<summary>
		/// Безопасный
		/// Безопасный	
		///</summary>
		NonHazard,
	
		///<summary>
		/// Малоопасный
		/// Малоопасный	
		///</summary>
		LowHazard,
	
		///<summary>
		/// Среднеопасный
		/// Среднеопасный	
		///</summary>
		MediumHazard,
	
		///<summary>
		/// Сильноопасный
		/// Сильноопасный	
		///</summary>
		HighHazard,
	
}


/// <summary>
/// Домен Acme.Business.Waybills.HazardousCargoWaybills.HazardousType - автоматически созданный класс.
/// </summary>
[Serializable]
[Metadata("Acme.Business.Waybills.HazardousCargoWaybills.Домены.HazardousType.metadata")]
public partial class HazardousType :
	Parus.Net.Server.Domains.EnumDomain<HazardousTypeEnum>
{
	/// <summary>
	/// Инициализирует экземпляр значением по умолчанию.
	/// </summary>
	public HazardousType()
	{
	}
	
	/// <summary>
	/// Инициализирует экземпляр переданным нетипизированным значением.
	/// </summary>
	public HazardousType(object value) : base(value)
	{
	}

	/// <summary>
	/// Инициализирует экземпляр переданным значением.
	/// </summary>
	public HazardousType(Acme.Business.Waybills.HazardousCargoWaybills.HazardousTypeEnum value) :
		base(value)
	{
	}

	/// <summary>
	/// Проверить данные на валидность.
	/// </summary>
	protected override bool CheckValue(Acme.Business.Waybills.HazardousCargoWaybills.HazardousTypeEnum value)
	{
		return true;
	}

			
	/// <summary>
	/// Инициализирует экземпляр строковым представлением значения домена.
	/// </summary>
	public HazardousType(string value) : base(value)
	{
	}
	

	
	#region Operators
	
	/// <summary>
	/// Оператор неявного приведения Acme.Business.Waybills.HazardousCargoWaybills.HazardousTypeEnum к
	/// HazardousType.
	/// </summary>
	public static implicit operator HazardousType(
		Acme.Business.Waybills.HazardousCargoWaybills.HazardousTypeEnum v)
	{
		
		return new HazardousType(v);
	}
	
	#endregion
}
}