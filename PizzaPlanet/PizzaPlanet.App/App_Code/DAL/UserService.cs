using Microsoft.EntityFrameworkCore;
using PizzaPlanet.App.App_Code.BLL;
using PizzaPlanet.App.App_Code.BOL;
using PizzaPlanet.App.App_Code.CoreModels;

namespace PizzaPlanet.App.App_Code.DAL
{
    public class UserService : IUserService
    {
        private readonly PizzaPlanetDbContext _context;

        public UserService(PizzaPlanetDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(CoreUser user)
        {
            try
            {
                var dataUser = new User(user);

                await _context.Users.AddAsync(dataUser);

                await SaveAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> EmailExistsAsync(string email, int? id = null)
        {
            if (id is null)
            {
                return _context.Users.AnyAsync(u => u.Email == email);
            }

            return _context.Users.AnyAsync(u => u.Email == email && u.UserId != id);
        }

        public async Task<CoreUser> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return new CoreUser(user);
        }

        public Task<bool> PhoneNumberExistsAsync(string phoneNumber, int? id = null)
        {
            if (id is null)
            {
                return _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
            }

            return _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber && u.UserId != id);
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
