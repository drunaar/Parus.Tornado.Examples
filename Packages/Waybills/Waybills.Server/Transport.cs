using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="ITransport"/>.
	/// </summary>
	[BizClass(typeof(ITransport))]
	public abstract class Transport : PersistedObjectBase, ITransport
	{
		#region Physical Attributes
		/// <summary>
		/// Мнемокод транспортного средства
		/// </summary>
		[Transactional]
		public abstract Mnemo Mnemo
		{
			get;
			set;
		}
		/// <summary>
		/// Наименование транспортного средства
		/// </summary>
		[Transactional]
		public abstract Name Name
		{
			get;
			set;
		}
		/// <summary>
		/// Аватар транспортного средства
		/// </summary>
		[Transactional]
		public abstract SmallPicture Avatar
		{
			get;
			set;
		}
		/// <summary>
		/// Физический атрибут Photo.
		/// </summary>
		[Transactional]
		public abstract BigPicture Photo
		{
			get;
			set;
		}
		/// <summary>
		/// Фотография транспортного средства
		/// </summary>
		[Transactional]
		public abstract Serviceable Serviceable
		{
			get;
			set;
		}
		#endregion
		#region Triggers
		/// <summary>
		/// Триггер на создание.
		/// </summary>
		[Trigger(TriggerType.Create)]
		protected virtual void CreateTrigger(ITransport oldState)
		{
			Serviceable = false;
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface ITransportCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private ITransportCreateArgs MyCreateArgs
		{
			get
			{
				return (ITransportCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract ITransportCreateArgs CreateArgs
		{
			get;
		}
	}
}
