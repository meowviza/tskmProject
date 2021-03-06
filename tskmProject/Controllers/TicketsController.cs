﻿using System;
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
    [Authorize]
    public class TicketsController : Controller
    {
        private tskmContainer db = new tskmContainer();

        // GET: Tickets
        //public class UploadController : TicketsController
        //{
        //    public ActionResult UploadDocument()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public ActionResult Upload(HttpPostedFileBase file)
        //    {
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
        //            file.SaveAs(path);
        //        }

        //        return RedirectToAction("UploadDocument");
        //    }
        //}
        public ActionResult Index()
        {
            int userID = CurrentUser.GetUserID().Value;
            
            IEnumerable<Ticket> ticketList;
            if (CurrentUser.GetRoles().Any(x => x.Name == "Admin"))
            {
                ticketList = from Ticket in db.Tickets
                             select Ticket;
            }else
            {
                ticketList = from Ticket in db.Tickets
                             where Ticket.AssigneeID == userID || Ticket.userID == userID
                             select Ticket;
            }       
            return View(ticketList.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName");
            return View();
        }


        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                int userID = CurrentUser.GetUserID().Value;

                ticket.userID = userID;
                ticket.CreatedDate = DateTime.Now;
                ticket.UpdatedDate = DateTime.Now;
                ticket.Status = db.Status.Single(x => x.statusName == "Opened");

                #region File Upload
                List<File> fileList = new List<Models.File>();
                for (int i = 0; i < Request.Files.Count; ++i)
                {
                    File fileUpload = FileHelper.Save(Request.Files[i], Server.MapPath("~/App_Data/uploads"));
                    fileList.Add(fileUpload);
                }

                var dbFiles = from dbFile in db.Files.ToList()
                             join file in fileList on dbFile.fileID equals file.fileID
                             select dbFile;
                ticket.Files = dbFiles.ToList();
                #endregion

                db.Tickets.Add(ticket);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName", ticket.catagoryID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusName", ticket.statusID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", ticket.userID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName", ticket.catagoryID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusName", ticket.statusID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", ticket.userID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ticketID,ticketTitle,contractChannel,ticketDetail,ticketDate,catagoryID,statusID,userID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                int? userID = CurrentUser.GetUserID();

                if (userID != null)
                {
                    ticket.userID = userID.Value;
                    db.Entry(ticket).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.catagoryID = new SelectList(db.Catagories, "catagoryID", "catagoryName", ticket.catagoryID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusName", ticket.statusID);
            ViewBag.userID = new SelectList(db.Users, "userID", "userFname", ticket.userID);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
        public ActionResult Assign(int id)
        {
            ViewBag.NewAssigneeID = new SelectList(db.Users, "userID", "userFname");
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(new TicketHistory
            {
                TicketID = ticket.ticketID,
                OldAssigneeID = ticket.AssigneeID,
            });
        }

        [HttpPost]
        public ActionResult Assign(TicketHistory ticketHistory)
        {
            ticketHistory.CreatedByID = CurrentUser.GetUserID().Value;
            ticketHistory.CreatedDateTime = DateTime.Now;
            db.TicketHistories.Add(ticketHistory);

            Ticket ticket = db.Tickets.Find(ticketHistory.TicketID);
            ticket.AssigneeID = ticketHistory.NewAssigneeID;
            ticket.UpdatedDate = DateTime.Now;
            ticket.Status = db.Status.Single(x => x.statusName == "In Progress");

            db.SaveChanges();

            return RedirectToAction("Details", new { id = ticketHistory.TicketID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply(TicketReply reply)
        {
            if (ModelState.IsValid)
            {
                reply.userID = CurrentUser.GetUserID().Value;
                reply.replyDate = DateTime.Now;
                db.TicketReplies.Add(reply);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = reply.ticketID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CloseTicket(Ticket ticket)
        {
            Ticket dbTicket = db.Tickets.Find(ticket.ticketID);
            ticket.UpdatedDate = DateTime.Now;

            if (CurrentUser.GetUserID().Value == dbTicket.userID)
            {
                dbTicket.Status = db.Status.Single(x=> x.statusName == "Closed");
            }
            else if (CurrentUser.GetRoles().Any(x => x.Name == "Admin" || x.Name == "IT User"))
            {
                dbTicket.Status = db.Status.Single(x => x.statusName == "Waiting for closing");
            }
            db.SaveChanges();
            return RedirectToAction("Details", new { id = ticket.ticketID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReopenTicket(Ticket ticket)
        {
            Ticket dbTicket = db.Tickets.Find(ticket.ticketID);
            ticket.UpdatedDate = DateTime.Now;

            if (dbTicket.AssigneeID != null)
            {
                dbTicket.Status = db.Status.Single(x => x.statusName == "In Progress");
            }
            else
            {
                dbTicket.Status = db.Status.Single(x => x.statusName == "Opened");
            }

            db.SaveChanges();

            return RedirectToAction("Details", new { id = ticket.ticketID });
        }
    }
}
