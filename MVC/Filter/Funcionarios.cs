using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filter
{
    public class Funcionarios : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.GetString("Rol") == "Cliente")
                context.Result = new RedirectResult("/Home/Index");
        }
    }
}
