using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.App.App_Code.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(255, ErrorMessage = "Email address has a max lengh of 255")]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(255, ErrorMessage = "Password has max length of 255")]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
    }
}
