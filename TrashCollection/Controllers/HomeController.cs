﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;
using TrashCollection.Models.TrashCollector;

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
        public ActionResult TimeSheet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TimeSheet(Customer customer)
        {
            ViewBag.Message = "Thank you - Your hours have been submitted!";
            return View("RedirectToHome");
        }

        public ActionResult PTORequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PTORequest(CustomersController customer)
        {
            ViewBag.Vacation = "Your request has been received and you will receive confirmation if your request is approved.";
            return View("RedirectToHome");
        }



        public ActionResult Billing()
        {
            return View();
        }
    }
}