using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filter
{
    public class Admin_Func : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.GetString("Rol") == "Cliente")
                context.Result = new RedirectResult("/Home/Index");
        }
    }
}
