using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        protected List<string> DisplayErrors()
        {
            var errorList = new List<string>();

            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            for (int i = 0; i < errors.Count; i++)
            {
                var errorCollection = errors[i];

                for (int j = 0; j < errorCollection.Count; j++)
                {
                    errorList.Add(errorCollection[j].ErrorMessage);
                }
            }

            return errorList;
        }
    }
}
