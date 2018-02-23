using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class RouteViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RouteView
        public ActionResult Index()
        {
            var routeViewModels = db.RouteViewModels.Include(r => r.Customer);
            return View(routeViewModels.ToList());
        }

        // GET: RouteView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteViewModel routeViewModel = db.RouteViewModels.Find(id);
            if (routeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(routeViewModel);
        }

        // GET: RouteView/Create
        public ActionResult Create()
        {
            ViewBag.Customerid = new SelectList(db.Customers, "CustomerId", "FirstName");
            //ViewBag.Employeeid = new SelectList(db.Employee, "EmployeeId", FirstName);
            return View();
        }

        // POST: RouteView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Customerid,Employeeid")] RouteViewModel routeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RouteViewModels.Add(routeViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customerid = new SelectList(db.Customers, "CustomerId", "FirstName", routeViewModel.CustomerId);
            return View(routeViewModel);
        }

        // GET: RouteView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteViewModel routeViewModel = db.RouteViewModels.Find(id);
            if (routeViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customerid = new SelectList(db.Customers, "CustomerId", "FirstName", routeViewModel.CustomerId);
            return View(routeViewModel);
        }

        // POST: RouteView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Customerid,Employeeid")] RouteViewModel routeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customerid = new SelectList(db.Customers, "CustomerId", "FirstName", routeViewModel.CustomerId);
            return View(routeViewModel);
        }

        // GET: RouteView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteViewModel routeViewModel = db.RouteViewModels.Find(id);
            if (routeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(routeViewModel);
        }

        // POST: RouteView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteViewModel routeViewModel = db.RouteViewModels.Find(id);
            db.RouteViewModels.Remove(routeViewModel);
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
