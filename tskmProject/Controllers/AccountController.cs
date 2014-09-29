using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tskmProject.Models;
using MvcCheckBoxList;
using System.Web.Security;
namespace tskmProject.Controllers
{
    public class AccountController : Controller
    {
        tskmContainer db = new tskmContainer();
        // GET: Account
        public ActionResult Index()
        {
            return View(db.Users);
        }
        public ActionResult Create()
        {
            ViewBag.departmentID = new SelectList(db.Departments, "departmentID", "departmentName");
            User user = new User();
            user.Roles = (from role in db.Roles
                          select role).ToList();
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            var r = from role in db.Roles
                    join userRole in user.SelectedRoleIDs on role.roleID equals userRole
                    select role;
            user.Roles = r.ToList();
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            if (CurrentUser.GetUserID() != null)
            {
                return RedirectToAction("Menu");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var u = (from us in db.Users
                     where us.username == user.username && us.password == user.password
                     select us).SingleOrDefault();
            if (u != null)
            {
                FormsAuthentication.SetAuthCookie(user.username, true);
                return RedirectToAction("Menu");
            }
            else
            {
                ModelState.AddModelError("", "");
            }
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Roles = db.Roles.ToList();
            ViewBag.DepartmentList = db.Departments;
            User m_user = db.Users.SingleOrDefault(x => x.userID == id);
            if (m_user != null)
            {
                return View(m_user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            User m_dbUser = db.Users.Single(x => x.userID == user.userID);
            m_dbUser.userFname = user.userFname;
            m_dbUser.userLname = user.userLname;
            m_dbUser.userTel = user.userTel;
            m_dbUser.userEmail = user.userEmail;
            m_dbUser.userPosition = user.userPosition;
            var r = from role in db.Roles
                    join userRole in user.SelectedRoleIDs on role.roleID equals userRole
                    select role;
            m_dbUser.Roles.Clear();
            m_dbUser.Roles = r.ToList();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Menu()
        {
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Unauthorized()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}