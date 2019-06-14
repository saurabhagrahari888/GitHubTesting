using AandA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AandA.Controllers
{
    public class SessionWorkController : Controller
    {
        SaurabhEntities objdata = new SaurabhEntities();
        // GET: SessionWork
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(SessionClass objclass)
        {
            bool isValid = objdata.Sessionnns.Any(x => x.username == objclass.UserName && x.password == objclass.Password);
            if(isValid == true)
            {
                Session["Name"] = objclass.UserName;
                if(Session["Name"].ToString() != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult testpage()
        {
            return Content("This is Only For Testing the Url");
        }


    }
}