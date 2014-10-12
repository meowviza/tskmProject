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

            using (tskmContainer db = new tskmContainer())
            {
                if (!db.Catagories.Any())
                {
                    db.Catagories.Add(new Catagory
                    {
                        catagoryName = "Hardware"
                    });
                    db.Catagories.Add(new Catagory
                    {
                        catagoryName = "Software"
                    });
                    db.Catagories.Add(new Catagory
                    {
                        catagoryName = "Others"
                    });
                }

                if (!db.Roles.Any())
                {
                    db.Roles.Add(new Role
                    {
                        Name = "Admin",
                        Description = "ผู้ดูแลระบบ"
                    });

                    db.Roles.Add(new Role
                    {
                        Name = "IT Manager",
                        Description = "ผู้จัดการแผนก IT"
                    });

                    db.Roles.Add(new Role
                    {
                        Name = "IT User",
                        Description = "เจ้าหน้าที่ IT"
                    });

                    db.Roles.Add(new Role
                    {
                        Name = "User",
                        Description = "ผู้ใช้งาน"
                    });
                }

                if (!db.Departments.Any())
                {
                    db.Departments.Add(new Department
                    {
                        departmentName = "Admin"
                    });
                }

                if (!db.Status.Any())
                {
                    db.Status.Add(new Status
                    {
                        statusName = "Opened"
                    });

                    db.Status.Add(new Status
                    {
                        statusName = "In Progress"
                    });

                    db.Status.Add(new Status
                    {
                        statusName = "Waiting for closing"
                    });

                    db.Status.Add(new Status
                    {
                        statusName = "Closed"
                    });
                }

                db.SaveChanges();

                if (!db.Users.Any())
                {
                    User user = new User
                    {
                        userFname = "Admin",
                        userLname = "Admin",
                        username = "admin",
                        password = "admin",
                        userTel = "1111",
                        userEmail = "admin@admin.com",
                        Department = db.Departments.First(),
                        userCode = "1111",
                        userPosition = "Admin"
                    };
                    user.Roles.Add(db.Roles.Single(x=>x.Name == "Admin"));

                    db.Users.Add(user);
                }

                db.SaveChanges();
            }
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
