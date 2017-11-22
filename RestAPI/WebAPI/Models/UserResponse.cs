using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<RoleResponse> Roles { get; set; }
    }
}