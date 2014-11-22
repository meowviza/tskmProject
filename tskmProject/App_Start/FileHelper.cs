using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using tskmProject.Models;

namespace tskmProject
{
    public static class FileHelper
    {
        public static Models.File Save(HttpPostedFileBase fileUpload, string targetPath)
        {
            using (tskmContainer db = new tskmContainer())
            {
                Models.File file = new Models.File();
                file.fileName = Guid.NewGuid().ToString();
                file.ContentType = fileUpload.ContentType;

                fileUpload.SaveAs(Path.Combine(targetPath, file.fileName));

                db.Files.Add(file);
                db.SaveChanges();

                return file;
            }
        }
    }
}