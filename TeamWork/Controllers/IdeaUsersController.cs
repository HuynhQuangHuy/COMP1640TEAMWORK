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
            var ideaUsers = db.IdeaUsers.Include(i => i.Comment).Include(i => i.Idea);
            return View(ideaUsers.ToList());
        }

        // GET: IdeaUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUser = db.IdeaUsers.Find(id);
            if (ideaUser == null)
            {
                return HttpNotFound();
            }
            return View(ideaUser);
        }

        // GET: IdeaUsers/Create
        public ActionResult Create()
        {
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description");
            ViewBag.IdeaId = new SelectList(db.Ideas, "Id", "Description");
            return View();
        }

        // POST: IdeaUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdeaId,CommentId,IsThumbUp,IsThumbDown")] IdeaUser ideaUser)
        {
            if (ModelState.IsValid)
            {
                db.IdeaUsers.Add(ideaUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description", ideaUser.CommentId);
            ViewBag.IdeaId = new SelectList(db.Ideas, "Id", "Description", ideaUser.IdeaId);
            return View(ideaUser);
        }

        // GET: IdeaUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUser = db.IdeaUsers.Find(id);
            if (ideaUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description", ideaUser.CommentId);
            ViewBag.IdeaId = new SelectList(db.Ideas, "Id", "Description", ideaUser.IdeaId);
            return View(ideaUser);
        }

        // POST: IdeaUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdeaId,CommentId,IsThumbUp,IsThumbDown")] IdeaUser ideaUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description", ideaUser.CommentId);
            ViewBag.IdeaId = new SelectList(db.Ideas, "Id", "Description", ideaUser.IdeaId);
            return View(ideaUser);
        }

        // GET: IdeaUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUser = db.IdeaUsers.Find(id);
            if (ideaUser == null)
            {
                return HttpNotFound();
            }
            return View(ideaUser);
        }

        // POST: IdeaUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdeaUser ideaUser = db.IdeaUsers.Find(id);
            db.IdeaUsers.Remove(ideaUser);
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
