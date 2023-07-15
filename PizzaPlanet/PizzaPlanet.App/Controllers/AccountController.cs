using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPlanet.App.App_Code.BLL;
using PizzaPlanet.App.App_Code.CoreModels;
using PizzaPlanet.App.App_Code.ViewModels;
using System.Security.Claims;

namespace PizzaPlanet.App.Controllers
{
    public class AccountController : ControllerHelper
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public static string PhoneNumberExistsMessage { get; } = "Phone number already exists";

        public static string EmailExistsMessage { get; } = "Email address already exists";

        public static string IncorrectEmailMessage { get; } = "Incorrect email";

        public static string PasswordRequirementsErrorMessage { get; } = "Password does not meet our requirements";

        public AccountController(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (await _userService.EmailExistsAsync(model.Email))
                {
                    return SetError(EmailExistsMessage, model);
                }

                if (await _userService.PhoneNumberExistsAsync(model.PhoneNumber))
                {
                    return SetError(PhoneNumberExistsMessage, model);
                }

                if (!_passwordService.PasswordMeetsRequirements(model.Password))
                {
                    return SetError(PasswordRequirementsErrorMessage, model);
                }

                var coreUser = new CoreUser(model)
                {
                    Password = _passwordService.HashPassword(model.Password)
                };

                if (await _userService.CreateUserAsync(coreUser))
                {
                    SetTempSuccess("Account has been created!");                    
                }

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                return SetError(e, model);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            GetTempSuccess();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (!await _userService.EmailExistsAsync(model.Email))
                {
                    return SetError(IncorrectEmailMessage, model);
                }                

                var user = await _userService.GetUserByEmailAsync(model.Email);

                if (!_passwordService.ValidatePassword(model.Password, user.Password))
                {
                    return SetError("Incorrect password", model);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim("LastName", user.LastName),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception e)
            {
                return SetError(e, model);
            }
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
