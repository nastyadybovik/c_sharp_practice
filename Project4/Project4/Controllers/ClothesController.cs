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
    public class ClothesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clothes
        public ActionResult Index()
        {
            return View(db.Clothes.Include(nameof => nameof.Designer).ToList());
        }

        // GET: Clothes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        [Authorize(Roles = "admin")]
        // GET: Clothes/Create
        public ActionResult Create()
        {
            ViewBag.ClothesTypes = Enum.GetNames(typeof(Clothes.ClothesType));
            ViewBag.Materials = Enum.GetNames(typeof(Clothes.Material));
            ViewBag.Sizes = Enum.GetNames(typeof(Clothes.Size));
            ViewBag.Countries = Enum.GetNames(typeof(Clothes.Country));
            ViewBag.Designers = db.Designers.ToList();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Clothes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,SizeName,MaterialName,Price,CountryName,Description")] Clothes clothes, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                
                if (image != null)
                {
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    image.SaveAs(Server.MapPath("~/Files/" + fileName));
                    clothes.FileName = fileName;
                }
                db.Clothes.Add(clothes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clothes);
        }

       

        [Authorize(Roles = "admin")]
        // GET: Clothes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        [Authorize(Roles = "admin")]
        // POST: Clothes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,SizeName,MaterialName,Price,CountryName,Description")] Clothes clothes, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Clothes oldClothes = db.Clothes.Find(clothes.Id);
                oldClothes.Type = clothes.Type;
                oldClothes.SizeName = clothes.SizeName;
                oldClothes.MaterialName = clothes.MaterialName;
                oldClothes.Price = clothes.Price;
                oldClothes.CountryName = clothes.CountryName;
                oldClothes.Description = clothes.Description;

                if (image != null)
                {
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    image.SaveAs(Server.MapPath("~/Files/" + fileName));
                    oldClothes.FileName = fileName;
                }
                
                db.Entry(oldClothes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clothes);
        }

        [Authorize(Roles = "admin")]
        // GET: Clothes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        [Authorize(Roles = "admin")]
        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothes clothes = db.Clothes.Find(id);
            db.Clothes.Remove(clothes);
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
