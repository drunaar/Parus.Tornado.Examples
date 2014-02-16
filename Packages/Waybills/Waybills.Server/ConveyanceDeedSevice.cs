using Parus.Net.Server;
using Parus.ObjectManager;
using Parus.ObjectManager.LinkManager;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="IConveyanceDeedSevice"/>.
	/// </summary>
	[BizClass(typeof(IConveyanceDeedSevice))]
	public abstract class ConveyanceDeedSevice : PersistedObjectBase, IConveyanceDeedSevice
	{
		#region Class Methods
		/// <summary>
		/// Метод GetLink.
		/// </summary>
		[Transactional]
		public virtual IObjectLink GetLink(object obj)
		{
			var lm = Manager.GetService<ILinkManager>();
			var links = obj is IWaybill ? lm.IsLinksFromSource((IPersistedObject)obj, ConveyanceDeedRole.Guid) : lm.IsLinksToTarget((IPersistedObject)obj, ConveyanceDeedRole.Guid);
			if (links == null || links.Length == 0)
				return null;
			if (links.Length != 1 || links[0].Role != ConveyanceDeedRole.Guid)
			{
				throw new System.ApplicationException("Не неправильно установлена связь с источником.");
			}
			return links[0];
		}
		/// <summary>
		/// Метод Link.
		/// </summary>
		[Transactional]
		public virtual void Link(IWaybill source, IConveyanceDeed target)
		{
			Unlink((IPersistedObject)source);
			var data = Manager.CreateNew<IConveyanceDeedLinkData>();
			data.Date = System.DateTime.Now;
			var lm = Manager.GetService<ILinkManager>();
			lm.Link((IPersistedObject)source, (IPersistedObject)target, ConveyanceDeedRole.Guid, (IPersistedObject)data);
		}
		/// <summary>
		/// Метод Unlink.
		/// </summary>
		[Transactional]
		public virtual void Unlink(object obj)
		{
			var link = GetLink(obj);
			if (link != null)
			{
				var lm = Manager.GetService<ILinkManager>();
				lm.UnLink((IPersistedObject)link.Source, (IPersistedObject)link.Target, ConveyanceDeedRole.Guid);
				Manager.DeleteObject((IPersistedObject)link.Target);
				Manager.DeleteObject((IPersistedObject)link.Data);
			}
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IConveyanceDeedSeviceCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IConveyanceDeedSeviceCreateArgs MyCreateArgs
		{
			get
			{
				return (IConveyanceDeedSeviceCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract IConveyanceDeedSeviceCreateArgs CreateArgs
		{
			get;
		}
	}
}
