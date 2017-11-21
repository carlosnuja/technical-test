using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebAPI.DAL;

namespace WebAPI.Security
{
	public class WebApiPrincipal : IPrincipal
	{
		public User User { get; }

        public IIdentity Identity { get; private set; }

        public WebApiPrincipal(User user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));
			this.User = user;
            this.Identity = new GenericIdentity(user.UserName);
        }
       

        public bool IsInRole(string role)
		{
			return this.User.Role.Count(r => r.RoleName.Equals(role)) > 0;
		}
	}
}