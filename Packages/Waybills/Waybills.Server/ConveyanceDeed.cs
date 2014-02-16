using System;
using System.Collections;
using Parus.Net.Server;
using Parus.ObjectManager;
using Parus.ObjectManager.LinkManager;
namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="IConveyanceDeed"/>.
	/// </summary>
	[BizClass(typeof(IConveyanceDeed))]
	public abstract class ConveyanceDeed : PersistedObjectBase, IConveyanceDeed
	{
		#region Physical Attributes
		/// <summary>
		/// Груз сдал
		/// </summary>
		[Transactional]
		public abstract Name SourceName
		{
			get;
			set;
		}
		/// <summary>
		/// Груз принял
		/// </summary>
		[Transactional]
		public abstract Name TargetName
		{
			get;
			set;
		}
		/// <summary>
		/// Дата передачи
		/// </summary>
		[Transactional]
		public abstract Date Date
		{
			get;
			set;
		}
		/*/// <summary>
		/// Перехват установки значения свойства SourceName.
		/// </summary>
		[PropertyChangingInterceptor("SourceName")]
		protected virtual Name OnSourceNameChanging(Name newValue)
		{
		  return newValue;
		}*//*/// <summary>
		/// Перехват установки значения свойства TargetName.
		/// </summary>
		[PropertyChangingInterceptor("TargetName")]
		protected virtual Name OnTargetNameChanging(Name newValue)
		{
		  return newValue;
		}*//*/// <summary>
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
	protected virtual void CreateTrigger(IConveyanceDeed oldState)
	{
	}*//*/// <summary>
		/// Триггер на загрузку.
		/// </summary>
		[Trigger(TriggerType.LoadExisting)]
		protected virtual void LoadExistingTrigger(IConveyanceDeed oldState)
		{
		}*//// <summary>
		/// Триггер на коммит вставки.
		/// </summary>
		[Trigger(TriggerType.CommitInsert)]
		protected virtual void CommitInsertTrigger(IConveyanceDeed oldState)
		{
			var lm = Manager.GetService<ILinkManager>();
			var links = lm.IsLinksToTarget(this, ConveyanceDeedRole.Guid);
			if (links == null || links.Length != 1 || links[0].Role != ConveyanceDeedRole.Guid)
			{
				throw new System.ApplicationException("Не установлена или неправильно установлена связь с источником.");
			}
			((IConveyanceDeedLinkData)links[0].Data).Date = System.DateTime.Now;
		}
		/*/// <summary>
		/// Триггер на коммит изменения.
		/// </summary>
		[Trigger(TriggerType.CommitUpdate)]
		protected virtual void CommitUpdateTrigger(IConveyanceDeed oldState)
		{
		}*//// <summary>
		/// Триггер на коммит удаления.
		/// </summary>
		[Trigger(TriggerType.CommitDelete)]
		protected virtual void CommitDeleteTrigger(IConveyanceDeed oldState)
		{
			var srv = Manager.CreateNew<IConveyanceDeedSevice>();
			srv.Unlink(this);
		}
		#endregion
		///<summary>
		/// Возможные параметры создания объекта
		///</summary>
		public interface IConveyanceDeedCreateArgs
		{
		}
		///<summary>
		/// Параметры создания объекта
		///</summary>
		private IConveyanceDeedCreateArgs MyCreateArgs
		{
			get
			{
				return (IConveyanceDeedCreateArgs)this.CreateArgs;
			}
		}
		///<summary>
		/// Параметры создания базового объекта
		///</summary>
		protected abstract IConveyanceDeedCreateArgs CreateArgs
		{
			get;
		}
	}
}
