using PizzaPlanet.App.App_Code.BLL;
using System.Text.RegularExpressions;

namespace PizzaPlanet.App.App_Code.DAL
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool PasswordMeetsRequirements(string password)
        {
            return Regex.IsMatch(password, @"^(.{8,20}|[^0-9]*|[^A-Z])$");
        }

        public bool ValidatePassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
