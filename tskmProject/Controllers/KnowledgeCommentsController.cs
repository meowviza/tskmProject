using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tskmProject.Models;

namespace tskmProject.Controllers
{
    public class KnowledgeCommentsController : Controller
    {
        private tskmContainer db = new tskmContainer();

        // GET: KnowledgeComments
        public ActionResult Index()
        {
            var knowledgeCommentSet = db.KnowledgeComments.Include(k => k.Knowledgebase).Include(k => k.User);
            return View(knowledgeCommentSet.ToList());
        }

        // GET: KnowledgeComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeComment knowledgeComment = db.KnowledgeComments.Find(id);
            if (knowledgeComment == null)
            {
                return HttpNotFound();
            }
            return View(knowledgeComment);
        }

        // GET: KnowledgeComments/Create
        public ActionResult Create()
        {
            ViewBag.knowledgeID = new SelectList(db.Knowledgebases, "knowledgeID", "knowledgeTitle");
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname");
            return View();
        }

        // POST: KnowledgeComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "commentID,commentDetail,commentDate,knowledgeID,userID")] KnowledgeComment knowledgeComment)
        {
            if (ModelState.IsValid)
            {
                db.KnowledgeComments.Add(knowledgeComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.knowledgeID = new SelectList(db.Knowledgebases, "knowledgeID", "knowledgeTitle", knowledgeComment.knowledgeID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", knowledgeComment.userID);
            return View(knowledgeComment);
        }

        // GET: KnowledgeComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeComment knowledgeComment = db.KnowledgeComments.Find(id);
            if (knowledgeComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.knowledgeID = new SelectList(db.Knowledgebases, "knowledgeID", "knowledgeTitle", knowledgeComment.knowledgeID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", knowledgeComment.userID);
            return View(knowledgeComment);
        }

        // POST: KnowledgeComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "commentID,commentDetail,commentDate,knowledgeID,userID")] KnowledgeComment knowledgeComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledgeComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.knowledgeID = new SelectList(db.Knowledgebases, "knowledgeID", "knowledgeTitle", knowledgeComment.knowledgeID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", knowledgeComment.userID);
            return View(knowledgeComment);
        }

        // GET: KnowledgeComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeComment knowledgeComment = db.KnowledgeComments.Find(id);
            if (knowledgeComment == null)
            {
                return HttpNotFound();
            }
            return View(knowledgeComment);
        }

        // POST: KnowledgeComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KnowledgeComment knowledgeComment = db.KnowledgeComments.Find(id);
            db.KnowledgeComments.Remove(knowledgeComment);
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
    }
}
