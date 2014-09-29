using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using tskmProject.Models;

namespace tskmProject
{
    public static class CurrentUser
    {
        #region Field
        private static User _user;
        #endregion
        #region Constructor
        static CurrentUser()
        {
            RefreshCache();
        }
        #endregion

        #region Utility
        public static void RefreshCache()
        {
            using (tskmContainer db = new tskmContainer())
            {
                if (HttpContext.Current.User != null)
                {
                    _user = db.Users.SingleOrDefault(x => x.username == HttpContext.Current.User.Identity.Name);
                }
            }
        }
        #endregion

        #region Properties
        public static User User
        {
            get
            {
                return _user;
            }
        }
        #endregion

        #region Method
        public static int? GetUserID()
        {
            return _user != null ? (int?)_user.userID : null;
        }
        public static string GetUserName()
        {
            return _user != null ? _user.username : null;
        }
        public static string GetFirstName()
        {
            return _user != null && !String.IsNullOrEmpty(_user.userFname) ? _user.userFname : null;
        }
        public static string GetFullName()
        {
            return _user != null && !String.IsNullOrEmpty(_user.userFname) && !String.IsNullOrEmpty(_user.userLname) ?
            String.Format("{0} {1}", _user.userFname, _user.userLname) :
            null;
        }
        public static List<Role> GetRoles()
        {
            return _user != null ? _user.Roles.ToList() : null;
        }
        #endregion
    }
}