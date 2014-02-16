
using Parus.SmartClient.Model;
using Parus.SmartClient.Tornado;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Раздел
	/// </summary>
	[UnitResourceMetadata("Acme.Business.Waybills.Акт_передачи.ConveyanceDeed.unit")]
	public partial class ConveyanceDeedUnit : UnitBase
	{
		/// <summary>
		/// Инициализирует экземпляр
		/// </summary>
		/// <param name="unitMetadata">корневой элемент метаданных раздела</param>
		public ConveyanceDeedUnit(IUnitMetadata unitMetadata) : base(unitMetadata)
		{
		}

		/// <summary>
		/// Слот для хранения связи
		/// </summary>
		public const string LinkSlotName = "D6A7DBFB-DE6B-4261-99EE-ADCE90753DCF";
		private const string DocSlotName = "6F92CECB-4EE4-44E8-8466-196322467B3E";

		private void Init_TransitedEventHandler(IUnitExecutionContext context)
		{
			var objectManager = context.GetService<IObjectManager>();
			var srv = (IConveyanceDeedSevice) objectManager.NewObject(typeof (IConveyanceDeedSevice));
			var doc = (IWaybill) objectManager.GetObject(context.GetCurrentSelection().FocusedId);
			var link = srv.GetLink(doc);
			context[LinkSlotName] = link;
			context[DocSlotName] = doc;
			context.SetCurrentObject(link != null
				? link.Target
				: objectManager.NewObject(typeof (IConveyanceDeed)));
		}

		private void Commit_TransitingEventHandler(IUnitExecutionContext context)
		{
			var link = context[LinkSlotName];
			if (link == null)
			{
				var objectManager = context.GetService<IObjectManager>();
				var srv = (IConveyanceDeedSevice) objectManager.NewObject(typeof (IConveyanceDeedSevice));
				srv.Link((IWaybill) context[DocSlotName], (IConveyanceDeed) context.GetCurrentObject());
			}
		}

		private void Delete_TransitedEventHandler(IUnitExecutionContext context)
		{
			var objectManager = context.GetService<IObjectManager>();
			var srv = (IConveyanceDeedSevice)objectManager.NewObject(typeof(IConveyanceDeedSevice));
			var doc = objectManager.GetObject(context.GetCurrentSelection().FocusedId);
			srv.Unlink(doc);
		}
	}
}
