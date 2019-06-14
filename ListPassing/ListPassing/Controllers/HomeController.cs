using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListPassing.Models;

namespace ListPassing.Controllers
{
    public class HomeController : Controller
    {
        person objperson = new person();
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
        public ActionResult Task1()
        {
            ////Case 1 - For Code Side Data Validation
            //objperson.FName = "A";
            //objperson.MName = "B";
            //if((objperson.FName != null && objperson.LName != "" ) && (objperson.MName != null && objperson.MName != ""))
            //{
            //    objperson.LName = "Test Last Value";
            //} 


            return View();
        }
        [HttpPost]
        public ActionResult Task1(person objpost)
        {
            //Case 1 - For Code Side Data Validation
            objperson.FName = objpost.FName;
            objperson.MName = objpost.MName;
            if ((objperson.FName != null && objperson.LName != "") && (objperson.MName != null && objperson.MName != ""))
            {
                string a = objperson.FName.Trim();
                string b = objperson.MName.Trim();
                if (a == b)
                    objperson.LName = "Test Last Value";
                else
                    objperson.LName = objpost.LName;
            }
            if (ModelState.IsValid)
            {
                ViewBag.Text = "Inserted Data Successfully";
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Task2()
        {

            IList<person> person1 = new List<person>();
            person _person = new person
            {
                ID = 1,
                FName = "SHISHIR1",
                MName = "HAJARI1",
                LName = "MAJHI1"
            };
            person1.Add(_person);
            _person = new person
            {
                ID = 2,
                FName = "SHISHIR2",
                MName = "HAJARI2",
                LName = "MAJHI2"
            };
            person1.Add(_person);
            _person = new person
            {
                ID = 3,
                FName = "SHISHIR3",
                MName = "HAJARI3",
                LName = "MAJHI3"
            };
            person1.Add(_person);
            PersonMUL personMUL = new PersonMUL

            {

                PersonList = person1

            };



            //List<tstclass> objtestclasslist = new List<tstclass>();
            //objtestclasslist.Add(new tstclass(1, "TestName1", "TestAddress1","LName1"));
            //objtestclasslist.Add(new tstclass(2, "TestName2", "TestAddress2", "LName2"));
            //objtestclasslist.Add(new tstclass(3, "TestName3", "TestAddress3", "LName3"));
            //objtestclasslist.Add(new tstclass(4, "TestName4", "TestAddress4", "LName4"));
            //objtestclasslist.Add(new tstclass(5, "TestName5", "TestAddress5", "LName5"));
            //objtestclasslist.Add(new tstclass(6, "TestName6", "TestAddress6", "LName6"));
            //objtestclasslist.Add(new tstclass(7, "TestName7", "TestAddress7", "LName7"));
            //return View(objtestclasslist);
           return View(person1);
        }

        [HttpPost]
        public ActionResult Task2(IEnumerable<PersonMUL> objcls, IEnumerable<person> obj)
        {
            return View();
        }
        public class tstclass
        {

            private int id;//private int id;
            private string fname;//private string name;
            private string mname;
            //private string address;
            private string lname;
            public tstclass()
            {

            }    
                
            //public tstclass()
            //{


            //}
            //public tstclass(int id, string name, string address)
            //{
            //    this.id = id;
            //    this.name = name;
            //    this.address = address;

            //}
            public tstclass(int id, string fname, string mname,string lname)
            {
                this.Id = id;
                this.FName = fname;
                this.MName = mname;
                this.LName = lname;

            }
            public int Id { get ; set ; }
            public string FName { get ;  set ; }
            public string MName { get ;  set ;}
            public string LName { get; set; }
            //public IEnumerable<tstclass> abc { get; set; }
        }

        public class NewlistClass
        {
             public IEnumerable<tstclass> abc { get; set; }
        }

    }
}