using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Клиентский интерфейс класса Acme.Business.Waybills.ConveyanceDeedSevice.
	/// </summary>
	[Metadata("Acme.Business.Waybills.ConveyanceDeedSevice.metadata")]
	[LifeTimeAttribute(LifeTime.Transaction)]
	public partial interface IConveyanceDeedSevice
	{
		#region Methods
		/// <summary>
		/// Метод GetLink.
		/// </summary>
		[Transactional]
		Parus.Net.Server.IObjectLink GetLink(object obj);
		/// <summary>
		/// Метод Link.
		/// </summary>
		[Transactional]
		void Link(Acme.Business.Waybills.IWaybill source, Acme.Business.Waybills.IConveyanceDeed target);
		/// <summary>
		/// Метод Unlink.
		/// </summary>
		[Transactional]
		void Unlink(object obj);
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.IConveyanceDeedSevice))]
	public interface IConveyanceDeedSeviceFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IConveyanceDeedSevice Default();
	}
}
