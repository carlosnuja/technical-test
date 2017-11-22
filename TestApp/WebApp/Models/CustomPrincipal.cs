using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApp.Models
{
    public class CustomPrincipal : IPrincipal
    {
        public User User { get; }

        public IIdentity Identity { get; private set; }

        public CustomPrincipal(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            this.User = user;
            this.Identity = new GenericIdentity(user.UserName);
        }


        public bool IsInRole(string role)
        {
			bool b = this.User.Roles.Count(r => role.Contains(r.RoleName.Trim(' '))) > 0;
	        return b;
		}
    }
}