using PizzaPlanet.App.App_Code.CoreModels;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.App.App_Code.BOL
{
    public class User
    {
        private CoreUser _user;

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }


        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }

        public User()
        {

        }

        public User(CoreUser user)
        {
            _user = user;

            if (_user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (_user.UserId > 0)
            {
                UserId = _user.UserId;
            }

            FirstName = _user.FirstName;
            LastName = _user.LastName;
            Email = _user.Email;
            Password = _user.Password;
            PhoneNumber = _user.PhoneNumber;
            IsAdmin = _user.IsAdmin;
        }
    }
}
