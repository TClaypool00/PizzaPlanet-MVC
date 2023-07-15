using PizzaPlanet.App.App_Code.CoreModels;

namespace PizzaPlanet.App.App_Code.BLL
{
    public interface IUserService
    {
        public Task<bool> CreateUserAsync(CoreUser user);

        public Task<bool> EmailExistsAsync(string email, int? id = null);

        public Task<bool> PhoneNumberExistsAsync(string phoneNumber, int? id = null);

        public Task<CoreUser> GetUserByEmailAsync(string email);
    }
}
