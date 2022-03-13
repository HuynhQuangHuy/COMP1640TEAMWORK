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
    public class FileClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FileClasses
        public ActionResult Index()
        {
            return View(db.Fileclasses.ToList());
        }

        // GET: FileClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileClass fileClass = db.Fileclasses.Find(id);
            if (fileClass == null)
            {
                return HttpNotFound();
            }
            return View(fileClass);
        }

        // GET: FileClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileClassId,Name,File")] FileClass fileClass, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    int filelength = upload.ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload.InputStream.Read(Myfile, 0, filelength);
                    fileClass.File = Myfile;
                    db.Fileclasses.Add(fileClass);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(fileClass);
        }

        // GET: FileClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileClass fileClass = db.Fileclasses.Find(id);
            if (fileClass == null)
            {
                return HttpNotFound();
            }
            return View(fileClass);
        }

        // POST: FileClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileClassId,Name,File")] FileClass fileClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileClass);
        }

        // GET: FileClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileClass fileClass = db.Fileclasses.Find(id);
            if (fileClass == null)
            {
                return HttpNotFound();
            }
            return View(fileClass);
        }

        // POST: FileClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileClass fileClass = db.Fileclasses.Find(id);
            db.Fileclasses.Remove(fileClass);
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
