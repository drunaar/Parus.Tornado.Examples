using System;
using System.Collections;
using Parus.Net.Server;
using Parus.ObjectManager;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="IConveyanceDeedLinkData"/>.
	/// </summary>
	[BizClass(typeof(IConveyanceDeedLinkData))]
	public abstract class ConveyanceDeedLinkData : PersistedObjectBase, IConveyanceDeedLinkData
	{
		#region Physical Attributes
		/// <summary>
		/// Дата+время установленной связи
		/// </summary>
		[Transactional]
		public abstract Date Date
		{
			get;
			set;
		}
		/*/// <summary>
		/// Перехват установки значения свойства Date.
		/// </summary>
		[PropertyChangingInterceptor("Date")]
		protected virtual Date OnDateChanging(Date newValue)
		{
		  return newValue;
		}*/
		#endregion
		#region Triggers
		/*/// <summary>
	/// Триггер на создание.
	/// </summary>
	[Trigger(TriggerType.Create)]
	protected virtual void CreateTrigger(IConveyanceDeedLinkData oldState)
	{
	}*//*/// <summary>
		/// Триггер на загрузку.
		/// </summary>
		[Trigger(TriggerType.LoadExisting)]
		protected virtual void LoadExistingTrigger(IConveyanceDeedLinkData oldState)
		{
		}*//*/// <summary>
		/// Триггер на коммит вставки.
		/// </summary>
		[Trigger(TriggerType.CommitInsert)]
		protected virtual void CommitInsertTrigger(IConveyanceDeedLinkData oldState)
		{
		}*//*/// <summary>
		/// Триггер на коммит изменения.
		/// </summary>
		[Trigger(TriggerType.CommitUpdate)]
		protected virtual void CommitUpdateTrigger(IConveyanceDeedLinkData oldState)
		{
		}*//*/// <summary>
		/// Триггер на коммит удаления.
		/// </summary>
		[Trigger(TriggerType.CommitDelete)]
		protected virtual void CommitDeleteTrigger(IConveyanceDeedLinkData oldState)
		{
		}*/
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IConveyanceDeedLinkDataCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IConveyanceDeedLinkDataCreateArgs MyCreateArgs
		{
			get
			{
				return (IConveyanceDeedLinkDataCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract IConveyanceDeedLinkDataCreateArgs CreateArgs
		{
			get;
		}
	}
}
