﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using N2.Security;

namespace N2.Plugin
{
	public static class PluginExtensions
	{
		public static bool IsAuthorized(this IPlugin plugin, IPrincipal user, ISecurityManager security)
		{
			var securable = plugin as ISecurable;
			if (securable != null && securable.AuthorizedRoles != null && !PermissionMap.IsInRoles(user, securable.AuthorizedRoles))
				return false;

			var permittable = plugin as IPermittable;
			if (permittable != null && permittable.RequiredPermission > Permission.Read && !security.IsAuthorized(user, permittable.RequiredPermission))
				return false;

			return true;
		}
	}
}