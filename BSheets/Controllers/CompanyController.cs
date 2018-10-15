using BSheets.Models;
using BSheets.Models.Custom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BSheets.Controllers
{
    public class CompanyController : Controller
    {
        private BSheetsEntities _db = new BSheetsEntities();
        private ViewModel _vm = new ViewModel();

        // GET: Company
        public ActionResult Index(string search)
        {
            _vm.Companies = _db.Companies.ToList();

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
            return PartialView(Json(_vm));
        }

        public PartialViewResult FilteredResults(string search)
        {
            return PartialView(Json(_vm));
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Company/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Company/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Companies.Add(company);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Clients/Update/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Clients/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "ID,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(company).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Clients/Remove/5
        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Clients/Remove/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            Company company = _db.Companies.Find(id);
            _db.Companies.Remove(company);
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