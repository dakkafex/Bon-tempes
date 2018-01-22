using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using ZureRoom.Models;
using System.Diagnostics;

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
            string[] columnNames = new string[] { "ID","Name", "Number", "Message"};

            ApplicationDbContext db = new ApplicationDbContext();

            var csvQry = from c in db.Contacts
                         select c;

            string csv = string.Empty;

            foreach (string columnName in columnNames)
            {
                csv += columnName + ",";
            }

            csv += "\r\n";

            foreach(var qry in csvQry)
            {
                csv += qry.ID + ",";
                csv += qry.Name.Replace(",", ";") + ",";
                csv += qry.Phone.Replace(",", ";") + ",";
                csv += qry.Message.Replace(",", ";") + ",";

                csv += "\r\n";
            }

            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            return File(bytes, "application/text", "Customer.csv");
        }

    }
}