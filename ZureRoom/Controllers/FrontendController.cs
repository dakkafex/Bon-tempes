using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZureRoom.Controllers
{
    public class FrontendController : Controller
    {
        // GET: Frontend
        public ActionResult Home()
        {
            return View();
        }
    }
}