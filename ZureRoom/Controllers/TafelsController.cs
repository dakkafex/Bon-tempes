using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZureRoom.Models;

namespace ZureRoom.Controllers
{
    //Stoelen die over zijn opslaan bij id = 1 of tafel = tafel 0
    //Combineren oude tafels word verwijdert en in de tafel namen in Combine gezet
    //de stoelen van de gecombineerde tafels die verwijdert worden, worden naar tafel 0 verplaatst


    public class TafelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tafels
        public ActionResult Index()
        {
            return View(db.Tafels.ToList());
        }

        // GET: Tafels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tafels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TableNmr,Chairs,Combined")] Tafel tafel)
        {
            if (ModelState.IsValid)
            {
                db.Tafels.Add(tafel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tafel);
        }

        // GET: Tafels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tafel tafel = db.Tafels.Find(id);
            if (tafel == null)
            {
                return HttpNotFound();
            }
            return View(tafel);
        }

        // POST: Tafels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Chairs")] Tafel tafel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tafel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["Error"] = e;
                    return RedirectToAction("Error");
                }
            }
            return View(tafel);
        }

        public ActionResult Details(int? id)
        {
            ViewBag.TafelNmr = db.Tafels.Where(s => s.Id == id).Select(x => x.TableNmr).FirstOrDefault();
            ViewBag.Stoelen = db.Tafels.Where(s => s.Id == id).Select(x => x.Chairs).FirstOrDefault();

            return View(db.Reservations.ToList());
        }

        [HttpPost]
        public ActionResult Details(string Reservation, int TafelNmr)
        {
            int ID = int.Parse(Reservation);

            var query =
                from T in db.Reservations
                where T.ID == ID
                select T;
            foreach (Reservation T in query)
            {
                T.Tafel = TafelNmr;
            }
            db.SaveChanges();
            return RedirectToAction("Details", "Tafels");
        }
        public ActionResult Delete(int id)
        {
            var query = from t in db.Reservations
                        where t.ID == id
                        select t;
            foreach (Reservation T in query)
            {
                T.Tafel = 0;
            }
            db.SaveChanges();
            return RedirectToAction("index","Tafels");
        }
    }
}
