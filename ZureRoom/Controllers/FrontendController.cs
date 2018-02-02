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
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Frontend
        public ActionResult Home()
        {
            var menu = from a in db.Menus
                       select a;
            return View(menu.ToList());
        }
    }
}