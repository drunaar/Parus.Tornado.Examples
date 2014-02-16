using System;
using Parus.Net.Server;
using Parus.ObjectManager;
using Parus.ObjectManager.LinkManager;

namespace Acme.Business.Waybills
{
	/// <summary>
	/// Реализация класса <see href="IConveyanceDeedLinkRestrictor"/>.
	/// </summary>
	public class ConveyanceDeedLinkRestrictor : ILinkObjectRestrictsProvider
	{
		/// <summary>
		/// Получить перечень свойств приемника
		/// </summary>
		/// <returns></returns>
		public string[] GetTargetRestrictedProperties(IObjectManager manager, IObjectIdentity sourceId, IObjectIdentity targetId,
	                                                  IObjectIdentity dataId, Guid linkRole)
		{
			//return new string[] {};
			return new[] {
				"Date",
				"SourceName",
				"TargetName"
			};
		}

		/// <summary>
		/// Получить перечень свойств источника
		/// </summary>
		/// <returns></returns>
		public string[] GetSourceRestrictedProperties(IObjectManager manager, IObjectIdentity sourceId, IObjectIdentity targetId,
	                                                  IObjectIdentity dataId, Guid linkRole)
		{
			return new[] {
				"Route",
				"Number",
				"Date",
				"Transport"
			};
		}


        /// <summary>
        /// Получить перечень свойств приемника
        /// </summary>
        /// <returns></returns>
        public RestrictedPropertyInfo[] GetTargetRestrictedCollections(IObjectManager manager, IObjectIdentity sourceId,
                                                                       IObjectIdentity targetId, IObjectIdentity dataId, Guid linkRole)
        {
            return new RestrictedPropertyInfo[0];
        }

        /// <summary>
        /// Получить перечень свойств источника
        /// </summary>
        /// <returns></returns>
        public RestrictedPropertyInfo[] GetSourceRestrictedCollections(IObjectManager manager, IObjectIdentity sourceId,
                                                                       IObjectIdentity targetId, IObjectIdentity dataId, Guid linkRole)
        {
            return new RestrictedPropertyInfo[0];
        }
	}
}
