using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamWork.Models;

namespace TeamWork.Controllers
{
    public class IdeaUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdeaUsers
        public ActionResult Index()
        {
            return View(db.IdeaUser.ToList());
        }

        // GET: IdeaUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUsers = db.IdeaUser.Find(id);
            if (ideaUsers == null)
            {
                return HttpNotFound();
            }
            return View(ideaUsers);
        }

        // GET: IdeaUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IdeaUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdeaId,CommentId,IsThumbUp")] IdeaUser ideaUsers)
        {
            if (ModelState.IsValid)
            {
                db.IdeaUser.Add(ideaUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ideaUsers);
        }

        // GET: IdeaUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUsers = db.IdeaUser.Find(id);
            if (ideaUsers == null)
            {
                return HttpNotFound();
            }
            return View(ideaUsers);
        }

        // POST: IdeaUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdeaId,CommentId,IsThumbUp")] IdeaUser ideaUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ideaUsers);
        }

        // GET: IdeaUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUsers = db.IdeaUser.Find(id);
            if (ideaUsers == null)
            {
                return HttpNotFound();
            }
            return View(ideaUsers);
        }

        // POST: IdeaUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdeaUser ideaUsers = db.IdeaUser.Find(id);
            db.IdeaUser.Remove(ideaUsers);
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
