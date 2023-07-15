using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPlanet.App.App_Code.BLL;
using PizzaPlanet.App.App_Code.CoreModels;
using PizzaPlanet.App.App_Code.ViewModels;

namespace PizzaPlanet.App.Controllers
{
    public class AccountController : ControllerHelper
    {
        private readonly IUserService _userService;

        public static string PhoneNumberExistsMessage { get; } = "Phone number already exists";

        public static string EmailExistsMessage { get; } = "Email address already exists";

        public AccountController(IUserService userService)
        {
            _userService = userService;
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

                if (await _userService.EamilExists(model.Email))
                {
                    return SetError(EmailExistsMessage, model);
                }

                if (await _userService.PhoneNumberExists(model.PhoneNumber))
                {
                    return SetError(PhoneNumberExistsMessage, model);
                }

                var coreUser = new CoreUser(model);

                if (await _userService.CreateUserAsync(coreUser))
                {
                    SetTempSuccess("Account has been created!");                    
                }

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                return SetError(e.Message, model);
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
        public ActionResult LoginAsync(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
