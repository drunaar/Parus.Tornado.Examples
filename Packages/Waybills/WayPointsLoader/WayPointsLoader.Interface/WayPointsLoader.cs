using System.Collections;
using Parus.Net.Server;
namespace Acme.Business.Waybills.WayPointsLoader
{
	/// <summary>
	/// Сервис загрузки классификатора пунктов маршрута
	/// </summary>
	[Metadata("Acme.Business.Waybills.WayPointsLoader.WayPointsLoader.metadata")]
	[LifeTimeAttribute(LifeTime.SingleCall)]
	public partial interface IWayPointsLoader
	{
		#region Methods
		/// <summary>
		/// Сохранить данные
		/// </summary>
		[Transactional]
		System.Data.DataTable SaveData(System.Data.DataTable data);
		/// <summary>
		/// Проверить данные
		/// </summary>
		[Transactional]
		System.Data.DataTable CheckData(System.Data.DataTable data);
		#endregion
	}
	///<summary>
	///Factory interface 
	///</summary>
	[Parus.Net.Server.ServerFactoryInterfaceAttribute(typeof(Acme.Business.Waybills.WayPointsLoader.IWayPointsLoader))]
	public interface IWayPointsLoaderFactory
	{
		///<summary>
		///Factory method
		///</summary>
		[Parus.Net.Server.FactoryMethodAttribute("00000000-0000-0000-0000-000000000000")]
		IWayPointsLoader Default();
	}
}
