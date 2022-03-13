using Microsoft.AspNet.Identity;
using TeamWork.Models;
using TeamWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;

namespace TeamWork.Controllers
{
    public class IdeasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ideas
        public ActionResult Index()
        {
            var ideas = db.Ideas.Include(i => i.Item);
            return View(ideas.ToList());
        }

        // GET: Ideas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // GET: Ideas/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemId,Description,CreatedAt,File,UrlFile,NameOfFile")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Ideas.Add(idea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", idea.ItemId);
            return View(idea);
        }

        // GET: Ideas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", idea.ItemId);
            return View(idea);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemId,Description,CreatedAt,File,UrlFile,NameOfFile")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", idea.ItemId);
            return View(idea);
        }

        // GET: Ideas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idea idea = db.Ideas.Find(id);
            db.Ideas.Remove(idea);
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

        //Email
        public bool SendEmail(string toEmail, string emailSubject, string emailBody)
        {

            var senderEmail = ConfigurationManager.AppSettings["SenderEmail"].ToString();
            var senderPassword = ConfigurationManager.AppSettings["SenderPassword"].ToString();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            MailMessage mailMessage = new MailMessage(senderEmail, toEmail, emailSubject, emailBody);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;

            smtpClient.Send(mailMessage);

            return true;


        }

        public ActionResult SendEmailToUser()
        {
            bool result = false;

            var currentUser = User.Identity.GetUserId();
            var getUserName = User.Identity.GetUserName();


            //Get current Coordinator Email
            var CourseClass = (from c in db.Ideas
                               where c.UserId.Contains(currentUser)
                               join cl in db.Items
                               on c.ItemId equals cl.Id
                               select cl.CoordinatorId).ToList();
            var CoorId = "081de30f-8ccd-427f-9adf-6fe8a4a9adac";

            var coordinator = db.Users.Where(m => m.Id.Contains(CoorId)).Select(m => m.Email).ToList();
            var coordinatorEmail = coordinator[0];

            //Get current Idea description
            var course = db.Ideas.Where(m => m.UserId.Contains(currentUser)).Select(m => m.Description).ToList();
            var courseName = course[0];


            result = SendEmail($"{coordinatorEmail}", "Notification Email", $"Staff: {getUserName} <br> Ideas: {courseName} <br> Already submit a post");


            Json(result, JsonRequestBehavior.AllowGet);
            return View();
        }

    }
}
