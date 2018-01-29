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
            ViewBag.StoelenOver = db.Tafels.Where(i => i.Id == 1).Select(d => d.Chairs).FirstOrDefault();
            return View(db.Tafels.ToList());
        }

        // GET: Tafels/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Edit([Bind(Include = "Id,TableNmr,Chairs,Combined")] Tafel tafel)
        {
            int stoelen = db.Tafels.Where(d => d.Id == tafel.Id).Select(i => i.Chairs).FirstOrDefault();

            if (ModelState.IsValid && stoelen <= tafel.Id )
            {
                ViewBag.OverStoel = ViewBag.OverStoel + stoelen - tafel.Id;

                db.Entry(tafel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if(stoelen > tafel.Id)
            {
                TempData["Error"] = "Geef minder stoelen aan dan aangegeven";
                return RedirectToAction("Error");
            }
            return View(tafel);
        }

        // GET: Tafels/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Tafels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tafel tafel = db.Tafels.Find(id);
            db.Tafels.Remove(tafel);
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
