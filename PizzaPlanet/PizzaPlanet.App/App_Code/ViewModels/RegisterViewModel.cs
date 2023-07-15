using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.App.App_Code.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(255, ErrorMessage = "First name has a max lengh of 255")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(255, ErrorMessage = "Last name has a max lengh of 255")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(14, ErrorMessage = "Phone has a max length of 14")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a valid phone number format")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not maatch")]
        public string ConfirmPassword { get; set; }
    }
}
