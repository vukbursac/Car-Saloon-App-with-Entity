using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomaciSalonAutomobila.Models;
using DomaciSalonAutomobila.ViewModels;

namespace DomaciSalonAutomobila.Controllers
{
    public class SalonsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Salons
        public ActionResult Index()
        {
            return View(db.Salons.ToList());
        }

        // GET: Salons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // GET: Salons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PIB,Name,Country,City,Address")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Salons.Add(salon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salon);
        }

        // GET: Salons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: Salons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PIB,Name,Country,City,Address")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salon);
        }

        // GET: Salons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: Salons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salon salon = db.Salons.Find(id);
            db.Salons.Remove(salon);
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

        public ActionResult List(int id)
        {
            List<Automobile> listAutomobiles = new List<Automobile>();
            foreach (Automobile automobile in db.Automobiles.ToList())
            {
                if (automobile.SalonId == id)
                {
                    listAutomobiles.Add(automobile);
                }
            }
            return View(listAutomobiles);
        }

        public ActionResult Add(int id)
        {
            SalonManufacturersAuto SMA = new SalonManufacturersAuto();
            //List<Connection> listKonekcija = new List<Connection>();
            List<Manufacturer> listaProizvodjaca = new List<Manufacturer>();
            foreach (Connection connection in db.Connections.ToList())
            {
                if (connection.SalonId == id)
                {
                    //listKonekcija.Add(connection);
                    listaProizvodjaca.Add(db.Manufacturers.Find(connection.ManufacturerId));
                }
            }
            ViewBag.ManufacturerId = new SelectList(listaProizvodjaca, "Id", "Name");
            ViewBag.SalonId = new SelectList(db.Salons, "Id", "Name");
            SMA.Manufacturers = listaProizvodjaca;
            SMA.Automobile = new Automobile();
            SMA.Salon = db.Salons.Find(id);
            return View(SMA);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Model,Year,Power,Color,ManufacturerId,SalonId")] Automobile automobile)
        {
            List<Automobile> listAutomobiles = new List<Automobile>();
            foreach (Automobile a in db.Automobiles.ToList())
            {
                if (a.SalonId == automobile.SalonId)
                {
                    listAutomobiles.Add(a);
                }
            }
            if (ModelState.IsValid)
            {
                db.Automobiles.Add(automobile);
                db.SaveChanges();
                return RedirectToAction("Index");
                //return View("List", listAutomobiles);
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", automobile.ManufacturerId);
            ViewBag.SalonId = new SelectList(db.Salons, "Id", "Name", automobile.SalonId);

            SalonManufacturersAuto SMA = new SalonManufacturersAuto();
            List<Manufacturer> listaProizvodjaca = new List<Manufacturer>();
            foreach (Connection connection in db.Connections.ToList())
            {
                if (connection.SalonId == automobile.SalonId)
                {
                    listaProizvodjaca.Add(db.Manufacturers.Find(connection.ManufacturerId));
                }
            }
            SMA.Manufacturers = listaProizvodjaca;
            SMA.Automobile = automobile;
            SMA.Salon = db.Salons.Find(automobile.SalonId);

            return View(SMA);
        }
    }
}
