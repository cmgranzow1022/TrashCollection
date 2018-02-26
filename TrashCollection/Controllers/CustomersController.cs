using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;
using TrashCollection.Models.TrashCollector;

namespace TrashCollection.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers;
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Customers/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,PhoneNumber,EmailAddress,PickUpDay,Street,State,ZipCode,UserId,VacationStart,VacationEnd")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.UserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName");
            return View(customer);
        }

        // POST: Customers/Edit/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,PhoneNumber,EmailAddress,PickUpDay,Street,City,State,ZipCode,UserId,VacationStart,VacationEnd")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName");
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //GET : Customers/AddVacation
        public ActionResult AddVacation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVacation([Bind(Include = "CustomerId,FirstName,LastName,PhoneNumber,EmailAddress,Street,City,State,ZipCode,PickUpDay,UserId,VacationStart,VacationEnd")] Customer customer)
        {

            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Message = "Your vacation dates have been submitted. Enjoy your time away!";
            return View("RedirectToHome");
        }

        //GET : Customers/Profile
        public ActionResult ProfileAccount()
        {
            string userProfile= User.Identity.GetUserId();
            Customer customer = (from cust in db.Customers where cust.UserId == userProfile select cust).FirstOrDefault();
            if(customer == null)
            {
                return View();
            }
            return View(customer);
        }

        //POST : Customers/Profile
        [HttpPost]
        public ActionResult ProfileAccount([Bind(Include = "CustomerId,FirstName,LastName,PhoneNumber,EmailAddress,Street,City,State,ZipCode,PickUpDay,UserId,VacationStart,VacationEnd")] Customer customer)
        {
        
                db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges();
                return View("RedirectToHome");
    
        }
        public ActionResult ChangePickUpDay()
        {

            ViewBag.Message = "We understand that life is busy and routines can change.";
            return View();
        }

        [HttpPost]
        public ActionResult ChangePickUpDay([Bind(Include = "CustomerId,FirstName,LastName,PhoneNumber,EmailAddress,Street,City,State,ZipCode,PickUpDay,UserId,VacationStart,VacationEnd")] Customer customer)
        {
         
                db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges()  ;
                return View("RedirectToHome");
        
        }

        public ActionResult ScheduleVacation()
        {
            ViewBag.Message = "Going out of town? Save us a trip and we'll save you some money!";
            return View();
        }
        [HttpPost]
        public ActionResult ScheduleVacation(CustomersController customer)
        {
            ViewBag.Vacation = "Your vacation time has been saved. You will not be charged for pickups during this time.";
            return View("RedirectToHome");
        }

        public ActionResult GetZipForRoute()
        {
            return View();
        }

       [HttpPost, ActionName("GetZipForRoute")]
       public ActionResult GetZipForRoute([Bind(Include = "ZipCode")]Customer customer)
        {
            return RedirectToAction("DailyRouteMap", customer);
        }

        public ActionResult DailyRouteMap(Customer customer)
        {
            var today = DateTime.Now;
            string zipCode = customer.ZipCode;

            string getToday = today.DayOfWeek.ToString();
            var addressList = (from cust in db.Customers where cust.ZipCode == zipCode select cust).ToList();
            var todaysPickUps = (from p in db.Customers where p.PickUpDay == getToday select p).ToList();

            List<Customer> todaysCustomerPickUps = new List<Customer>();

            for (int a = 0; a < addressList.Count; a++)
            {
                for (int c = 0; c < todaysPickUps.Count; c++)
                {
                    if (addressList[a].CustomerId == todaysPickUps[c].CustomerId)
                    {
                        todaysCustomerPickUps.Add(addressList[a]);
                        break;
                    }
                }
            }
            return View(todaysCustomerPickUps);
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
