using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxFormPost.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult postform()
        {
            return View();
        }
        [HttpPost]
        public ActionResult postform(FormCollection formData)
        {
            string AjaxName = formData["Name"];
            string AjaxEmail = formData["Email"];
            string AjaxAddress = formData["Address"];

            return View();
        }
    }
}