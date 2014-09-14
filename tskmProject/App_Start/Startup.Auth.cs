using System;
using tskmProject.Models;

namespace tskmProject
{
    partial class Startup
    {

    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute 
    {
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("~/Account/Unauthorized");
            }
            else
            {
                 base.HandleUnauthorizedRequest(filterContext);   
            }            
        }
    }
}