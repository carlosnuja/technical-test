using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = "Please provide an username", AllowEmptyStrings = false)]
        public string Username { get; set;}
        [Required(ErrorMessage = "Please provide a password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}