using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Role
    {
        [ScaffoldColumn(false)]
        public int RoleID { get; set; }
        [Required, StringLength(15), Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}