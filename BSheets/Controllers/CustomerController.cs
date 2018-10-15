using BSheets.Models;
using BSheets.Models.Custom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BSheets.Controllers
{
    public class CustomerController : Controller
    {
        private BSheetsEntities _db = new BSheetsEntities();
        private ViewModel _vm = new ViewModel();

        // GET: Customer
        public ActionResult Index(string search)
        {
            _vm.Companies = _db.Companies.ToList();
            _vm.Customers = _db.Customers.ToList();

            if (string.IsNullOrEmpty(search))
            {
                AllResults();
            }
            else
            {
                FilteredResults(search);
            }

            return View();
        }

        public PartialViewResult AllResults()
        {
            return PartialView(_vm);
        }

        public PartialViewResult FilteredResults(string search)
        {
            return PartialView(_vm);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDb customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Customer/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include =
            "Id,Company_Id,Customer_Name,Customer_Company,"
            + "Primary_Phone,Alternate_Phone,Fax,Emails,Terms,"
            + "Billing_Address,Shipping_Address,Delivery_Preference,Payment_Preference,Exemptions")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerDb customerDb = new CustomerDb();
                var objData = new
                {
                    Company_Id = customer.Company_Id,
                    Customer_Name = customer.Customer_Name,
                    Customer_Company = customer.Customer_Company,
                    Primary_Phone = customer.Primary_Phone,
                    Alternate_Phone = customer.Alternate_Phone,
                    Fax = customer.Fax,
                    Website = customer.Website,
                    Emails = customer.Emails,
                    Terms = customer.Terms,
                    Billing_Address = customer.Billing_Address,
                    Shipping_Address = customer.Shipping_Address,
                    Delivery_Preference = customer.Delivery_Preference,
                    Payment_Preference = customer.Payment_Preference,
                    Exemptions = customer.Exemptions
                };

                customerDb.Obj_Data = JsonConvert.SerializeObject(objData);
                _db.Customers.Add(customerDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Clients/Update/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDb customerDb = _db.Customers.Find(id);
            if (customerDb == null)
            {
                return HttpNotFound();
            }

            Customer customer = JsonConvert.DeserializeObject<Customer>(customerDb.Obj_Data);
            customer.Id = (int)id;
            return View(customer);
        }

        // POST: Clients/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include =
            "Id,Company_Id,Customer_Name,Customer_Company,"
            + "Primary_Phone,Alternate_Phone,Fax,Emails,Terms,"
            + "Billing_Address,Shipping_Address,Delivery_Preference,Payment_Preference,Exemptions")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerDb customerDb = new CustomerDb();
                customerDb.Id = customer.Id;
                var objData = new
                {
                    Company_Id = customer.Company_Id,
                    Customer_Name = customer.Customer_Name,
                    Customer_Company = customer.Customer_Company,
                    Primary_Phone = customer.Primary_Phone,
                    Alternate_Phone = customer.Alternate_Phone,
                    Fax = customer.Fax,
                    Website = customer.Website,
                    Emails = customer.Emails,
                    Terms = customer.Terms,
                    Billing_Address = customer.Billing_Address,
                    Shipping_Address = customer.Shipping_Address,
                    Payment_Preference = customer.Payment_Preference,
                    Delivery_Preference = customer.Delivery_Preference,
                    Exemptions = customer.Exemptions
                };

                customerDb.Obj_Data = JsonConvert.SerializeObject(objData);
                _db.Entry(customerDb).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Clients/Remove/5
        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDb customerDb = _db.Customers.Find(id);
            if (customerDb == null)
            {
                return HttpNotFound();
            }

            Customer customer = JsonConvert.DeserializeObject<Customer>(customerDb.Obj_Data);
            customer.Id = (int)id;
            return View(customer);
        }

        // POST: Clients/Remove/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            CustomerDb customerDb = _db.Customers.Find(id);
            _db.Customers.Remove(customerDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}