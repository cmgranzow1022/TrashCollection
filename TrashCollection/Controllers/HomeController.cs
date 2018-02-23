using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This company does amazing things.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Have Questions? Please contact us.";

            return View();
        }


        [HttpPost]
        public ActionResult Contact(string message)
        {
            //TODO : send message to HQ
            ViewBag.Message = "Your message has been received. We will get back to you within 48 hours.";

                return View();
        }

        public ActionResult RatesAndServices()
        {
            ViewBag.Message = "We do great things - check it out!";
            return View();
        }

        public ActionResult ChangePickUpDay()
        {

            ViewBag.Message = "Life is busy and routines change, but we are flexible.";
            return View();
        }

        public ActionResult ScheduleVacation()
        {
            ViewBag.Message = "Going out of town? Save us a trip and we'll save you some money!";
            return View();
        }

        public ActionResult Billing()
        {
            return View();
        }
    }
}