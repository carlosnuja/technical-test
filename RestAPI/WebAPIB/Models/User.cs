using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        [Required, StringLength(50), Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, StringLength(32), Display(Name = "Password")]
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}