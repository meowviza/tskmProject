using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tskmProject.Models;

namespace tskmProject.Controllers
{
    public class FileController : Controller
    {
        public FileResult Get(long id)
        {
            using (tskmContainer db = new tskmContainer())
            {
                File file = db.Files.Find(id);
                return new FilePathResult(System.IO.Path.Combine(Server.MapPath("~/App_Data/uploads"), file.fileName), file.ContentType);
            }
        }
    }
}