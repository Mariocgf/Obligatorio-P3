using Microsoft.AspNetCore.Mvc;

namespace MVC.Filter
{
    public class IsAuthenticated : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("Rol") != null)
                context.Result = new RedirectResult("/");
        }
    }
    {
    }
}
