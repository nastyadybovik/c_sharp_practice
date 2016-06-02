using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project4.Models;

namespace Project4.Controllers
{
    public class DesignersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Designers
        public ActionResult Index()
        {
            return View(db.Designers.ToList());
        }

        // GET: Designers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        [Authorize(Roles = "admin")]
        // GET: Designers/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Designers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                db.Designers.Add(designer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designer);
        }

        [Authorize(Roles = "admin")]
        // GET: Designers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        [Authorize(Roles = "admin")]
        // POST: Designers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designer);
        }

        [Authorize(Roles = "admin")]
        // GET: Designers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        [Authorize(Roles = "admin")]
        // POST: Designers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designer designer = db.Designers.Find(id);
            db.Designers.Remove(designer);
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
