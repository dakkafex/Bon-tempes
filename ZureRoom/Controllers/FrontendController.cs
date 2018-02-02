using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZureRoom.Models;

namespace ZureRoom.Controllers
{
    public class FrontendController : Controller
    {
        //Create view maken
        //Foreach Menu 

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Frontend
        public ActionResult Home()
        {
            var menu = from a in db.Menus
                       select a;
            return View(menu.ToList());
        }

        public ActionResult Reserveren()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserveren([Bind(Include ="ID,Name,Email,Phone,Size,Message,Date,MenuName,Amount,Price")]Reservation reservation )
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View();
        }
    }
}