using Microsoft.AspNetCore.Mvc;

namespace PizzaPlanet.App.Controllers
{
    public class ControllerHelper : Controller
    {
        protected void SetTempError(string error)
        {
            TempData["Error"] = error;
        }

        protected void SetTempSuccess(string message)
        {
            TempData["Success"] = message;
        }

        protected void GetTempError()
        {
            if (TempData["Error"] is not null)
            {
                ViewBag.error = TempData["Error"];
            }
        }

        protected void GetTempSuccess()
        {
            if (TempData["success"] is not null)
            {
                ViewBag.success = TempData["success"];
            }
        }

        protected ActionResult SetError(string error, object model)
        {
            ViewBag.error = error;

            return View(model);
        }

        protected ActionResult SetError(Exception exception, object model)
        {
            ViewBag.error = exception.Message;

            return View(model);
        }
    }
}
