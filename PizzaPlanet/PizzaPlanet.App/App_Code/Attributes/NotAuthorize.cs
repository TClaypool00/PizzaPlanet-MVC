using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PizzaPlanet.App.App_Code.Attributes
{
    public sealed class NotAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedObjectResult("You cannot access this page if you are logged");

                return;
            }
        }
    }
}
