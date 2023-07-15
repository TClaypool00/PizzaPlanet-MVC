using PizzaPlanet.App.App_Code.BOL;
using PizzaPlanet.App.App_Code.ViewModels;

namespace PizzaPlanet.App.App_Code.CoreModels
{
    public class CoreUser
    {
        private RegisterViewModel _registerViewModel;

        public CoreUser()
        {

        }

        public CoreUser(RegisterViewModel registerViewModel)
        {
            _registerViewModel = registerViewModel;

            FirstName = registerViewModel.FirstName;
            LastName = registerViewModel.LastName;
            Email = registerViewModel.Email;
            Password = registerViewModel.Password;
            PhoneNumber = registerViewModel.PhoneNumber;
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }
    }
}
