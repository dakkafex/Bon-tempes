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

        public ActionResult Export()
        {
            //var Max = i.Contacts.OrderByDescending(u => u.ID).Select(i => i.ID).FirstOrDefault();

            //var All = i.Contacts.Select(u => u).ToString();
            //SELECT* FROM permlog ORDER BY id DESC LIMIT 0, 1

            var csvQry = (from c in i.Contacts
                          select c);

            string csv = string.Concat(
                         csvQry.Select(
                                Con => string.Format("{0},{1},{2},{3},{4}\n", Con.ID, Con.Name, Con.Phone, Con.Message, Con.Resolved)));

            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "Customers.csv");
        }

        public ActionResult Download()
        {
            //string[] columnNames = new string[] { "CustomerId", "ContactName", "City", "Country" };
            string[] columnNames = new string[] { "Name", "Number", "Message"};

            //NorthwindEntities entities = new NorthwindEntities();
            ApplicationDbContext db = new ApplicationDbContext();

            //var customers = from customer in entities.Customers.Take(10)
            //                select customer;
            var csvQry = from c in db.Contacts
                         select c;

            ////Build the CSV file data as a Comma separated string.
            //string csv = string.Empty;
            string csv = string.Empty;

            //foreach (string columnName in columnNames)
            //{
            //    //Add the Header row for CSV file.
            //    csv += columnName + ',';
            //}
            foreach (string columnName in columnNames)
            {
                csv += columnName + ",";
            }

            ////Add new line.
            //csv += "\r\n";
            csv += "\r\n";

            //foreach (var customer in customers)
            //{
            //    //Add the Data rows.
            //    csv += customer.CustomerID.Replace(",", ";") + ',';
            //    csv += customer.ContactName.Replace(",", ";") + ',';
            //    csv += customer.City.Replace(",", ";") + ',';
            //    csv += customer.Country.Replace(",", ";") + ',';

            //    //Add new line.
            //    csv += "\r\n";
            //}
            foreach(var qry in csvQry)
            {
                csv += qry.Name.Replace(",", ";");
                csv += qry.Phone.Replace(",", ";");
                csv += qry.Message.Replace(",", ";");

                csv += "\r\n";
            }

            ////Download the CSV file.
            //byte[] bytes = Encoding.ASCII.GetBytes(csv);
            //return File(bytes, "application/text", "Grid.csv");
            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            return File(bytes, "application/text", "Customer.csv");
        }

    }
}