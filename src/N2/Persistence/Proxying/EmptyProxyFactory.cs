﻿using System;
using System.Collections.Generic;
using N2.Engine;

namespace N2.Persistence.Proxying
{
	/// <summary>
	/// Doesn't intercept at all.
	/// </summary>
	[Service(typeof(IProxyFactory), Configuration = ContainerConfigurer.ConfigurationKeys.MediumTrust)]
	public class EmptyProxyFactory : IProxyFactory
	{
		#region IInterceptionFactory Members

		public virtual void Initialize(IEnumerable<Type> interceptedTypes)
		{
		}

		public virtual object Create(string discriminator)
		{
			return null;
		}

		public virtual bool OnLoaded(object instance)
		{
			return false;
		}

		public virtual bool OnSaving(object instance)
		{
			return false;
		}

		public virtual string GetTypeName(object entity)
		{
			var instance = entity as IInterceptedType;
			if (instance == null)
				return null;
			return instance.GetTypeName();
		}

		#endregion
	}
}
