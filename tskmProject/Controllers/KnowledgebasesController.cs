using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tskmProject.Models;
using System.Web.Security;

namespace tskmProject.Controllers
{
    public class KnowledgebasesController : Controller
    {
        private tskmContainer db = new tskmContainer();

        // GET: Knowledgebases
        public ActionResult Index()
        {
            var knowledgebaseSet = db.Knowledgebases.Include(k => k.Catagory);
            return View(knowledgebaseSet.ToList());
        }

        // GET: Knowledgebases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledgebase knowledgebase = db.Knowledgebases.Find(id);
            if (knowledgebase == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebase);
        }

        // GET: Knowledgebases/Create
        public ActionResult Create()
        {
            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName");
            return View();
        }

        // POST: Knowledgebases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "knowledgeID,knowledgeTitle,knowledgeDetail,knowledgeDate,catagoryID")] Knowledgebase knowledgebase)
        {
            if (ModelState.IsValid)
            {
                int? userID = CurrentUser.GetUserID();

                if (userID != null)
                {
                    knowledgebase.userID = userID.Value;
                    knowledgebase.knowledgeDate = DateTime.Now;
                    db.Knowledgebases.Add(knowledgebase);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName", knowledgebase.catagoryID);
            return View(knowledgebase);
        }

        // GET: Knowledgebases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledgebase knowledgebase = db.Knowledgebases.Find(id);
            if (knowledgebase == null)
            {
                return HttpNotFound();
            }
            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName", knowledgebase.catagoryID);
            return View(knowledgebase);
        }

        // POST: Knowledgebases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "knowledgeID,knowledgeTitle,knowledgeDetail,knowledgeDate,catagoryID")] Knowledgebase knowledgebase)
        {

            if (ModelState.IsValid)
            {
                int? userID = CurrentUser.GetUserID();

                if (userID != null)
                {
                    knowledgebase.userID = userID.Value;

                    db.Entry(knowledgebase).State = EntityState.Modified;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName", knowledgebase.catagoryID);
            return View(knowledgebase);
        }

        // GET: Knowledgebases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledgebase knowledgebase = db.Knowledgebases.Find(id);
            if (knowledgebase == null)
            {
                return HttpNotFound();
            }
            return View(knowledgebase);
        }

        // POST: Knowledgebases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knowledgebase knowledgebase = db.Knowledgebases.Find(id);
            db.Knowledgebases.Remove(knowledgebase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Comment Part
        public ActionResult Comment(int id)
        {
            return View(new KnowledgeComment() { knowledgeID = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(KnowledgeComment comment)
        {
            if (ModelState.IsValid)
            {
                int? userID = CurrentUser.GetUserID();
                if (userID.HasValue)
                {
                    comment.userID = userID.Value;
                    comment.commentDate = DateTime.Now;

                    db.KnowledgeComments.Add(comment);
                    db.SaveChanges();
                }

                return RedirectToAction("Details", new { id = comment.knowledgeID });
            }

            return View(comment);
        }
        #endregion
    }
}
