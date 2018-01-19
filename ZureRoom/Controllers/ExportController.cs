using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZureRoom.Models;

namespace ZureRoom.Controllers
{
    public class ExportController : Controller
    {
        private ApplicationDbContext i = new ApplicationDbContext();
        // GET: Export
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download()
        {
            //var Max = i.Contacts.OrderByDescending(u => u.ID).Select(i => i.ID).FirstOrDefault();

            //var All = i.Contacts.Select(u => u).ToString();
            //SELECT* FROM permlog ORDER BY id DESC LIMIT 0, 1

            string csv = string.Concat(from C in i.Contacts
                                       select string.Format("{0},{1},{2},{3},{4},{5}", C.ID, C.Name, C.Email, C.Phone, C.Message, C.Resolved));
            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "Customers.csv");
        }
    }
}