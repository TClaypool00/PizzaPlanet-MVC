using Microsoft.AspNetCore.Mvc;
using PizzaPlanet.App.App_Code.ViewModels;

namespace PizzaPlanet.App.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
