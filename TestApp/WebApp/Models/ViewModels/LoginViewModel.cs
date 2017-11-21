using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = "Please provide an username", AllowEmptyStrings = false)]
        [Display(Name = "Username")]
        public string Username { get; set;}
        [Required(ErrorMessage = "Please provide a password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}