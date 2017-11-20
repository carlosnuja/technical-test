using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebAPI.DAL;

namespace WebAPI.Security
{
	public class WebApiIdentity : IIdentity
	{
		public User User { get; }

		public WebApiIdentity(User user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));
			this.User = user;
		}

		public string Name => this.User.UserName;
		public string AuthenticationType => "Basic";
		public bool IsAuthenticated => true;

		public bool IsInRole(string role)
		{
			return this.User.Role.Count(r => r.RoleName.Equals(role)) > 0;
		}
	}
}