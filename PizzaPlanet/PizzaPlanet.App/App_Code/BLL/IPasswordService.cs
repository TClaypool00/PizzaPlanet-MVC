namespace PizzaPlanet.App.App_Code.BLL
{
    public interface IPasswordService
    {
        bool PasswordMeetsRequirements(string password);

        string HashPassword(string password);

        bool ValidatePassword(string password, string hash);
    }
}
