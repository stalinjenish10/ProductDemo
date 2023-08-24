using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ProductDemo.Utilities
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;

            if (ctx.Session.GetString("LoginId") != null)
            {
                return;
            }
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                                { "Controller", "Login" },
                                { "Action", "Index" }
                            });

        }
    }
}
