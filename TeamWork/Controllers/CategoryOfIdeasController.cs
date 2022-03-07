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
    public class CategoryOfIdeasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoryOfIdeas
        public ActionResult Index()
        {
            return View(db.CategoryOfIdeas.ToList());
        }

        // GET: CategoryOfIdeas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfIdeas categoryOfIdeas = db.CategoryOfIdeas.Find(id);
            if (categoryOfIdeas == null)
            {
                return HttpNotFound();
            }
            return View(categoryOfIdeas);
        }

        // GET: CategoryOfIdeas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryOfIdeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryOfIdeaID,Description")] CategoryOfIdeas categoryOfIdeas)
        {
            if (ModelState.IsValid)
            {
                db.CategoryOfIdeas.Add(categoryOfIdeas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryOfIdeas);
        }

        // GET: CategoryOfIdeas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfIdeas categoryOfIdeas = db.CategoryOfIdeas.Find(id);
            if (categoryOfIdeas == null)
            {
                return HttpNotFound();
            }
            return View(categoryOfIdeas);
        }

        // POST: CategoryOfIdeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryOfIdeaID,Description")] CategoryOfIdeas categoryOfIdeas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryOfIdeas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryOfIdeas);
        }

        // GET: CategoryOfIdeas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfIdeas categoryOfIdeas = db.CategoryOfIdeas.Find(id);
            if (categoryOfIdeas == null)
            {
                return HttpNotFound();
            }
            return View(categoryOfIdeas);
        }

        // POST: CategoryOfIdeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryOfIdeas categoryOfIdeas = db.CategoryOfIdeas.Find(id);
            db.CategoryOfIdeas.Remove(categoryOfIdeas);
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
