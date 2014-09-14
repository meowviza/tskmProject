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
    public class TicketRepliesController : Controller
    {
        private tskmContainer db = new tskmContainer();

        // GET: TicketReplies
        public ActionResult Index()
        {
            var ticketReplySet = db.TicketReplies.Include(t => t.Ticket).Include(t => t.User);
            return View(ticketReplySet.ToList());
        }

        // GET: TicketReplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReply ticketReply = db.TicketReplies.Find(id);
            if (ticketReply == null)
            {
                return HttpNotFound();
            }
            return View(ticketReply);
        }

        // GET: TicketReplies/Create
        public ActionResult Create()
        {
            ViewBag.ticketID = new SelectList(db.Tickets, "ticketID", "ticketTitle");
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname");
            return View();
        }

        // POST: TicketReplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "replyID,replyDetail,replyDate,ticketID,userID")] TicketReply ticketReply)
        {
            if (ModelState.IsValid)
            {
                db.TicketReplies.Add(ticketReply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ticketID = new SelectList(db.Tickets, "ticketID", "ticketTitle", ticketReply.ticketID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", ticketReply.userID);
            return View(ticketReply);
        }

        // GET: TicketReplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReply ticketReply = db.TicketReplies.Find(id);
            if (ticketReply == null)
            {
                return HttpNotFound();
            }
            ViewBag.ticketID = new SelectList(db.Tickets, "ticketID", "ticketTitle", ticketReply.ticketID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", ticketReply.userID);
            return View(ticketReply);
        }

        // POST: TicketReplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "replyID,replyDetail,replyDate,ticketID,userID")] TicketReply ticketReply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketReply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ticketID = new SelectList(db.Tickets, "ticketID", "ticketTitle", ticketReply.ticketID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", ticketReply.userID);
            return View(ticketReply);
        }

        // GET: TicketReplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReply ticketReply = db.TicketReplies.Find(id);
            if (ticketReply == null)
            {
                return HttpNotFound();
            }
            return View(ticketReply);
        }

        // POST: TicketReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketReply ticketReply = db.TicketReplies.Find(id);
            db.TicketReplies.Remove(ticketReply);
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
