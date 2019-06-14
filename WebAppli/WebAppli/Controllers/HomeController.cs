using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppli.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {
            string url = "http://localhost:58857/api/apinew";

            return Redirect(url);
         //  return  Content("Test Saurabh Name");
         //  return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult ListValues()
        {
            List<Testclass> objtestclasslist = new List<Testclass>();
            objtestclasslist.Add(new Testclass(1, "TestName1", "TestAddress1"));
            objtestclasslist.Add(new Testclass(2, "TestName2", "TestAddress2"));
            objtestclasslist.Add(new Testclass(3, "TestName3", "TestAddress3"));
            objtestclasslist.Add(new Testclass(4, "TestName4", "TestAddress4"));
            objtestclasslist.Add(new Testclass(5, "TestName5", "TestAddress5"));
            objtestclasslist.Add(new Testclass(6, "TestName6", "TestAddress6"));
            objtestclasslist.Add(new Testclass(7, "TestName7", "TestAddress7"));
            return View(objtestclasslist);
        }
        [HttpGet]
        public ActionResult ListValueEdit(int? id)
        {
            List<Testclass> objtestclasslist = new List<Testclass>();
            objtestclasslist.Add(new Testclass(1, "TestName1", "TestAddress1"));
            objtestclasslist.Add(new Testclass(2, "TestName2", "TestAddress2"));
            objtestclasslist.Add(new Testclass(3, "TestName3", "TestAddress3"));
            objtestclasslist.Add(new Testclass(4, "TestName4", "TestAddress4"));
            objtestclasslist.Add(new Testclass(5, "TestName5", "TestAddress5"));
            objtestclasslist.Add(new Testclass(6, "TestName6", "TestAddress6"));
            objtestclasslist.Add(new Testclass(7, "TestName7", "TestAddress7"));
            var data = objtestclasslist.Where(x => x.Id == id).FirstOrDefault();
           
            Testclass objclass = new Testclass(data.Id,data.Name,data.Address);
            objclass.Id = data.Id;
            objclass.Name= data.Name;
            objclass.Address = data.Address;
            return View(objclass);
        }
        [HttpPost]
        public ActionResult ListValueEdit(Testclass objtstcls)
        {

            return View();
        }
        //[HttpPost]
        //public ActionResult ListValueEdit()
        //{

        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Model Class Should be Inserted here only for test--
        
        public class Testclass
        {
            private int id;
            private string name;
            private string address;

            public Testclass()
            {
                

            }
            public Testclass(int id,string name,string address)
            {
                this.id = id;
                this.name = name;
                this.address = address;

            }
            public int Id { get { return id;} set { id = value; } }
            public string  Name { get { return name; } set { name = value; } }
            public string Address { get { return address; } set { address = value;} }
        }


    }
}