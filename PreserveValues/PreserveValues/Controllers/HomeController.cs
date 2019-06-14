using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PreserveValues.Models;

namespace PreserveValues.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
         return RedirectToAction("TestValues");
           // return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult TestValues()
        {
            TestClass objget = new TestClass();
            List<string> LstName = new List<string>();
            LstName.Add("Name 1");
            LstName.Add("Name 2");
            LstName.Add("Name 3");
            LstName.Add("Name 4");
            List<string> LstEmail = new List<string>();
            LstEmail.Add("Email 1");
            LstEmail.Add("Email 2");
            LstEmail.Add("Email 3");
            LstEmail.Add("Email 4");
            objget.Name = LstName;
            objget.EmailId = LstEmail;
            return View(objget);
        }
        [HttpPost]
        public ActionResult TestValues(TestClass objclass)
        {
            TestClass objpost = new TestClass();
            objpost.Name = objclass.Name;
            objpost.EmailId = objclass.EmailId;
            return View(objpost);
        }
    }
}