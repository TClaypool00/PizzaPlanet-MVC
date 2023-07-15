using PizzaPlanet.App.App_Code.CoreModels;

namespace PizzaPlanet.App.App_Code.BLL
{
    public interface IUserService
    {
        public Task<bool> CreateUserAsync(CoreUser user);

        public Task<bool> EamilExists(string email, int? id = null);

        public Task<bool> PhoneNumberExists(string phoneNumber, int? id = null);
    }
}
