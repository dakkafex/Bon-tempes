using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZureRoom.Models;

namespace ZureRoom.Controllers
{
    [Authorize (Roles = "Admin, Cook")]
    public class MenusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Menus
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: Menus/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        public ActionResult MaakReservering()
        {

            return View();
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MenuImage,Description,Nuts,Shellfish,Soy,Eggs,Milk,Price")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Nuts,Shellfish,Soy,Eggs,Milk,Price")] Menu menu, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                Menu storedMenu =  db.Menus.SingleOrDefault(p => p.ID == menu.ID);

                storedMenu.Name = menu.Name;
                storedMenu.Description = menu.Description;
                storedMenu.Nuts = menu.Nuts;
                storedMenu.Shellfish = menu.Shellfish;
                storedMenu.Soy = menu.Soy;
                storedMenu.Eggs = menu.Eggs;
                storedMenu.Milk = menu.Milk;
                storedMenu.Price = menu.Price;

                // afbeelding verwerken
                if (ImageUpload != null && ImageUpload.ContentLength > 0)
                {
                    // directory aanmaken
                    var uploadPath = Path.Combine(Server.MapPath("~/Content/Uploads"), storedMenu.ID.ToString());
                    Directory.CreateDirectory(uploadPath);

                    // TODO: oude afbeelding verwijderen

                    // bestandsnaam maken
                    string fileGuid = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    string newFilename = fileGuid + extension;

                    // bestand opslaan
                    ImageUpload.SaveAs(Path.Combine(uploadPath, newFilename));

                    // opslaan in database
                    //MenuImg pic = new MenuImg { MenuImgPlace = newFilename };
                    //storedMenu.MenuImg = pic;
                }
                //db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
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
