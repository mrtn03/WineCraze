using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WineCraze.Core.Services;

namespace WineCraze.Attributes
{
    public class NotMustBeAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IUserService? userService = context.HttpContext.RequestServices.GetService<IUserService>();

            if (userService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (userService != null
                && userService.IsUser(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}