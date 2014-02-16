
using Parus.Net.Server.AssemblyMarkup;

namespace Acme.Business.Waybills.PerishablesWaybills
{
	/// <summary>
	/// Расширения класса PerishablesWaybill
	/// </summary>
	public static class PerishablesWaybillExt
	{
		[Parus.Net.Server.AssemblyMarkup.CalculatedPropertyAttribute("Acme.Business.Waybills.PerishablesWaybills.PerishablesWaybill", "TotalWear")]
		public static WearPercent CalculateTotalWear(IPerishablesWaybill obj)
		{
			decimal total = 1;
			foreach(IPerishablesBreakPoint item in obj.PerishablesRoute)
			{
				total *= 1 - item.Wear/100;
			}
			return (1 - total)*100;
		}
	}
}
