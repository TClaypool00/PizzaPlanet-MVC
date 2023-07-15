using PizzaPlanet.App.App_Code.BOL;
using PizzaPlanet.App.App_Code.ViewModels;

namespace PizzaPlanet.App.App_Code.CoreModels
{
    public class CoreUser
    {
        private RegisterViewModel _registerViewModel;
        private User _user;

        public CoreUser()
        {

        }

        public CoreUser(RegisterViewModel registerViewModel)
        {
            if (registerViewModel is null)
            {
                throw new ArgumentNullException(nameof(registerViewModel));
            }

            _registerViewModel = registerViewModel;            

            FirstName = registerViewModel.FirstName;
            LastName = registerViewModel.LastName;
            Email = registerViewModel.Email;
            Password = registerViewModel.Password;
            PhoneNumber = registerViewModel.PhoneNumber;
        }

        public CoreUser(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _user = user;

            FirstName = _user.FirstName;
            LastName = _user.LastName;
            Email = _user.Email;
            PhoneNumber = _user.PhoneNumber;
            Email = _user.Email;
            Password = _user.Password;
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
