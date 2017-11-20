﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}