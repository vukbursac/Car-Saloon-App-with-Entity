using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomaciSalonAutomobila.Models;

namespace DomaciSalonAutomobila.Controllers
{
    public class AutomobilesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Automobiles
        public ActionResult Index()
        {
            var automobiles = db.Automobiles.Include(a => a.Manufacturer).Include(a => a.Salon);
            return View(automobiles.ToList());
        }

        // GET: Automobiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            return View(automobile);
        }

        // GET: Automobiles/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");
            ViewBag.SalonId = new SelectList(db.Salons, "Id", "Name");
            return View();
        }

        // POST: Automobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Year,Power,Color,ManufacturerId,SalonId")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                db.Automobiles.Add(automobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", automobile.ManufacturerId);
            ViewBag.SalonId = new SelectList(db.Salons, "Id", "Name", automobile.SalonId);
            return View(automobile);
        }

        // GET: Automobiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", automobile.ManufacturerId);
            ViewBag.SalonId = new SelectList(db.Salons, "Id", "PIB", automobile.SalonId);
            return View(automobile);
        }

        // POST: Automobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Year,Power,Color,ManufacturerId,SalonId")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", automobile.ManufacturerId);
            ViewBag.SalonId = new SelectList(db.Salons, "Id", "PIB", automobile.SalonId);
            return View(automobile);
        }

        // GET: Automobiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            return View(automobile);
        }

        // POST: Automobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automobile automobile = db.Automobiles.Find(id);
            db.Automobiles.Remove(automobile);
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
