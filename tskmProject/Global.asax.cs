using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using tskmProject.Models;
using System.Security.Principal;

namespace tskmProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            PostAuthenticateRequest += Application_PostAuthenticateRequest;
        }
        protected void Application_PostAuthenticateRequest(object serder, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (tskmContainer db = new tskmContainer())
                {
                    var roles = (from us in db.Users
                    where us.username == User.Identity.Name
                    select us).SingleOrDefault().Roles.Select(x => x.Name);

                    GenericIdentity Identity = new GenericIdentity(User.Identity.Name);
                    GenericPrincipal Principal = new GenericPrincipal(Identity, roles.ToArray());
                    Context.User = Principal;
                    System.Threading.Thread.CurrentPrincipal = Principal;
                }
            }

            // Udpate CurrentUser
            CurrentUser.RefreshCache();
        }
    }
}
